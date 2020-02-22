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

        public bool CreateBooking(Booking booking)
        {
            booking.Id = Guid.NewGuid();
            booking.Owner = this.CurrentUser;
            booking.Type = UserType.Owner;

            this.CurrentUser.Bookings.Add(booking);

            return true;
        }

        public List<Booking> ViewRideOffer(Journey journey)
        {
            var bookings = AppDataServices.Users.SelectMany(a => a.Bookings)
                .Where(a=>a.Journey.StatingPlace==journey.StatingPlace&&a.Journey.EndPlace==journey.EndPlace&&a.Journey.Date==journey.Date&&a.Type==UserType.Owner)
                .Select(a => a).ToList();

            return bookings;
        }

        public bool DeleteRideOffer(Booking booking)
        {
            if (booking.Traveller.Count == 0)
            {
                this.CurrentUser.Bookings.Remove(booking);
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

        public bool ModifyBooking(Booking newBooking,Booking oldBooking)
        {
            newBooking.Id = oldBooking.Id;
            oldBooking = newBooking;
            return true;
        }

        public bool RequestBooking(Booking booking)
        {
            if (this.CurrentUser != booking.Owner)
            {
                booking.Status = BookingStatus.Pending;
                booking.Type = UserType.Traveller;
                this.CurrentUser.Bookings.Add(booking);
                Booking ownerBooking = AppDataServices.Users.SelectMany(a => a.Bookings).FirstOrDefault(a => a.Id == booking.Id);
                booking.Type = UserType.Owner;
                ownerBooking.Traveller.Add(this.CurrentUser);
                return true;
            }

            return false;
        }

        public List<Booking> ViewCreatedBookingStatus()
        {
            var bookings = this.CurrentUser.Bookings.SelectMany(a => a.Traveller)
                               .SelectMany(a => a.Bookings)
                               .Where(a => a.Status == BookingStatus.Pending)
                               .Select(a => a).ToList();

            return bookings;
        }

        public bool SeatBookingConfirm(Booking booking)
        {
            if (booking.Car.VacantSeat > 0)
            {
                booking.Status = BookingStatus.Confirm;
                booking.Car.VacantSeat--;
                return true;
            }
            else
            {
                booking.Status = BookingStatus.Rejected;
                return false;
            }
        }

        public void SeatBookingReject(Booking booking)
        {
            booking.Status = BookingStatus.Rejected;
        }

        public List<Booking> ViewSeatBookingRequestStatus()
        {
            var bookings = this.CurrentUser.Bookings.Where(a=>a.Type==UserType.Traveller).Select(a => a).ToList();

            return bookings;
        }

        public List<Booking> ViewOfferStatus()
        {
            var bookings = this.CurrentUser.Bookings.Where(a => a.Type == UserType.Owner).Select(a => a).ToList();

            return bookings;
        }
    }
}
