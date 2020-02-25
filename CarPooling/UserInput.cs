using CarPooling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarPooling.Models.Enum;

namespace CarPooling
{
    public class UserInput
    {
        public static User NewUser()
        {
            Console.Clear();
            User user = new User();

            Console.Write(Constant.UserId);
            user.Id = Helper.GetValidUserName();

            Console.Write(Constant.Password);
            user.Password = Helper.ValidString();

            Console.Write(Constant.Name);
            user.Name = Helper.ValidString();

            Console.Write(Constant.MobileNumber);
            user.MobileNumber = Helper.ValidString();

            Console.Write(Constant.Email);
            user.Email = Helper.GetValidEmail();

            Console.Write(Constant.Address);
            user.Address = Helper.ValidString();

            Console.Write(Constant.DrivingLicenceNumber);
            user.DrivingLicence = Console.ReadLine();

            Console.Write(Constant.IdProofNumber);
            user.IdProofNumber = Helper.ValidString();

            return user;
        }

        public static Login GetCredential()
        {
            Console.Clear();
            Login login = new Login();

            Console.Write(Constant.UserId);
            login.UserName = Helper.ValidString();

            Console.Write(Constant.Password);
            login.Password = Helper.ValidString();

            return login;
        }

        public static Ride GetRideDetail()
        {
            Console.Clear();
            Ride ride = new Ride();

            Console.Write(Constant.Date);
            ride.Date = Helper.ValidDate();

            ride.Car = GetCarDetails();

            Console.Write(Constant.Source);
            ride.SourceCityName = Helper.GetValidCity();

            while (true)
            {
                Console.Write(Constant.Destination);
                ride.DestinationCityName = Helper.GetValidCity();
                if (ride.DestinationCityName != ride.SourceCityName)
                    break;
                else
                {
                    Console.WriteLine(Constant.InvalidValue);
                }
            }

            Console.Write(Constant.LandMark);
            ride.LandMark = Console.ReadLine();

            Console.Write(Constant.NoOfViaPlaces);
            int number = Helper.ValidInteger();
            for (int count = 0; count < number; count++)
            {
                var places = GetPlaces();
                var duplicate = ride.Points.FirstOrDefault(a => a.City == places.City);

                if (places.City != ride.DestinationCityName && places.City != ride.SourceCityName && duplicate == null)
                {
                    ride.Points.Add(places);
                }
                else
                {
                    Console.WriteLine(Constant.InvalidValue);
                    count--;
                }   
            }

            return ride;
        }

        public static Car GetCarDetails()
        {
            Car car = new Car();

            Console.WriteLine(Constant.CarDetail);
            Console.Write(Constant.CarNumber);
            car.Number = Helper.ValidString();

            Console.Write(Constant.CarModel);
            car.Model = Helper.ValidString();

            Console.Write(Constant.CarCapacity);
            car.MaxSeatCapacity = Helper.ValidInteger();

            while (true)
            {
                Console.Write(Constant.VacantSeat);
                car.VacantSeat = Helper.ValidInteger();
                if (car.VacantSeat <= car.MaxSeatCapacity)
                    break;
                Console.WriteLine(Constant.InvalidVacantSeat);
            }

            return car;
        }

        public static Booking GetBooking()
        {
            Booking booking = new Booking();
            Console.WriteLine(Constant.JourneyDetail);

            Console.Write(Constant.Date);
            booking.Date = Helper.ValidDate();

            Console.Write(Constant.Source);
            booking.SourceCityName = Helper.GetValidCity(); ;

            while (true)
            {
                Console.Write(Constant.Destination);
                booking.DestinationCityName = Helper.GetValidCity();
                if (booking.DestinationCityName != booking.SourceCityName)
                    break;
                else
                {
                    Console.WriteLine(Constant.InvalidValue);
                }
            }

            Console.Write(Constant.LandMark);
            booking.LandMark = Console.ReadLine();

            return booking;
        }

        public static Places GetPlaces()
        {
            Places point = new Places();

            Console.Write(Constant.City);
            point.City = Helper.GetValidCity();
            return point;
        }

        public static ConfirmationResponse Confirmation()
        {
            Console.WriteLine(Constant.ConfirmOption);

            ConfirmationResponse option = (ConfirmationResponse)Helper.ValidInteger();

            switch (option)
            {
                case ConfirmationResponse.Yes:
                    return ConfirmationResponse.Yes;

                case ConfirmationResponse.No:
                    return ConfirmationResponse.No;

                default:
                    Console.WriteLine(Constant.InvalidValue);
                    option = Confirmation();
                    return option;

            }
        }

        public static ConfirmationResponse Response()
        {
            Console.WriteLine(Constant.Another);

            ConfirmationResponse option = (ConfirmationResponse)Helper.ValidInteger();

            switch (option)
            {
                case ConfirmationResponse.Yes:
                    return ConfirmationResponse.Yes;

                case ConfirmationResponse.No:
                    return ConfirmationResponse.No;

                default:
                    Console.WriteLine(Constant.InvalidValue);
                    option = Confirmation();
                    return option;

            }
        }

        public static BookingStatus BookingChoice()
        {
            Console.WriteLine(Constant.RideRequestChoice);

            BookingStatus option = (BookingStatus)Helper.ValidInteger();

            switch (option)
            {
                case BookingStatus.Confirm:
                    return BookingStatus.Confirm;

                case BookingStatus.Rejected:
                    return BookingStatus.Rejected;

                case BookingStatus.Pending:
                    return BookingStatus.Pending;

                default:
                    Console.WriteLine(Constant.InvalidValue);
                    option = BookingChoice();
                    return option;
            }
        }
    }
}
