using CarPooling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarPooling.Models.Enum;

namespace CarPooling.Services
{
    public class BookingServices
    {
        public User CurrentUser { get; set; }

        public BookingServices(string userId)
        {
            this.CurrentUser = AppDataServices.GetUser(userId);
        }

        public bool CreateBooking(Ride booking)
        {
            booking.Id = Guid.NewGuid();
            this.CurrentUser.Rides.Add(booking);

            return true;
        }

        public List<Ride> ViewRideOffer(Booking booking)
        {
            var rides = AppDataServices.Users.SelectMany(a => a.Rides)
                .Where(a=>a.SourceCityName== booking.SourceCityName&&a.DestinationCityName== booking.DestinationCityName && a.Date==a.Date&&a.Car.VacantSeat>0)
                .Select(a => a).ToList();
            int count = 0;

           if (rides.Count<=0)
            {
                var availableRides = AppDataServices.Users.SelectMany(a => a.Rides).Where(a => a.Date == a.Date && a.Car.VacantSeat > 0).Select(a => a);

                foreach(var ride in availableRides)
                {
                    if (ride.DestinationCityName == booking.DestinationCityName)
                    {
                        count++;
                        if (count == 2)
                        {
                            rides.Add(ride);
                            break;
                        }
                    }
                        
                    else if (ride.SourceCityName == booking.SourceCityName)
                        count++;
                    else
                    {
                        foreach(var city in ride.Points)
                        {
                            if (city.City == booking.DestinationCityName)
                            {
                                count++;
                                if (count == 2)
                                {
                                    rides.Add(ride);
                                    break;
                                }
                            }
                            else if (city.City == booking.SourceCityName)
                                count++;
                        }
                    }

                    
                }

                //var places = AppDataServices.Users
                //     .SelectMany(a => a.Rides).Where(a => a.Date == a.Date && a.Car.VacantSeat > 0)
                //     .SelectMany(a => a.Points)
                //     .Where(a => a.City==booking.SourceCityName && a.City==booking.DestinationCityName).Select(a => a).ToList();

                //rides = AppDataServices.Users.SelectMany(a => a.Rides).Where(a => a.Points == places).Select(a => a).ToList();
            }

            return rides;
        }

        public bool DeleteRideOffer(Ride ride)
        {
            if (ride.AcceptedBookerId.Count == 0)
            {
                this.CurrentUser.Rides.Remove(ride);
                return true;
            }

            return false;
        }

        public bool DeleteRideRequest(Booking booking)
        {
            if (booking.Status == BookingStatus.Pending)
            {
                this.CurrentUser.Bookings.Remove(booking);
                return true;
            }

            return false;
        }

        public bool ModifyRide(Ride newRide,Ride oldRide)
        {
            newRide.Id = oldRide.Id;
            oldRide = newRide;
            return true;
        }

        public bool RequestBooking(Booking booking,Guid bookingId)
        {

            if (this.CurrentUser.Rides?.FirstOrDefault(a => a.Id == bookingId) == null)
            {
                booking.Id=Guid.NewGuid();
                booking.Status = BookingStatus.Pending;
                this.CurrentUser.Bookings.Add(booking);
                Ride ownerBooking = AppDataServices.Users.SelectMany(a => a.Rides).FirstOrDefault(a => a.Id == bookingId);
                ownerBooking.RequestBookerId.Add(booking.Id);
                return true;
            }

            return false;
        }

        public List<Ride> ViewCreatedRideStatus()
        {
            var rides = this.CurrentUser.Rides.Where(a => a.RequestBookerId.Count != 0).Select(a => a).ToList();

            return rides;
        }

        public bool SeatBookingConfirm(Guid bookingId)
        {
            Ride ride = this.CurrentUser.Rides.FirstOrDefault(a=>a.RequestBookerId.Contains(bookingId));
            Booking booking = AppDataServices.GetBooking(bookingId);
            if (ride.Car.VacantSeat > 0)
            {
                ride.AcceptedBookerId.Add(bookingId);
                ride.RequestBookerId.Remove(bookingId);
                booking.Status = BookingStatus.Confirm;
                ride.Car.VacantSeat--;
                return true;
            }
            else
            {
                booking.Status = BookingStatus.Rejected;
                return false;
            }
        }

        public void SeatBookingReject(Guid bookingId)
        {
            Ride ride = this.CurrentUser.Rides.FirstOrDefault(a => a.RequestBookerId.Contains(bookingId));
            Booking booking = AppDataServices.GetBooking(bookingId);
            booking.Status = BookingStatus.Rejected;
            ride.RequestBookerId.Remove(bookingId);
        }

        public List<Booking> ViewSeatBookingRequestStatus()
        {
            var bookings = this.CurrentUser.Bookings.Select(a => a).ToList();

            return bookings;
        }

        public List<Ride> ViewOfferStatus()
        {
            var bookings = this.CurrentUser.Rides.Select(a => a).ToList();

            return bookings;
        }
    }
}
