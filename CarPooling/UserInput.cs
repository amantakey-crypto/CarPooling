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
            user.Id = Helper.ValidString();

            Console.Write(Constant.Password);
            user.Password = Helper.ValidString();

            Console.Write(Constant.Name);
            user.Name = Helper.ValidString();

            Console.Write(Constant.MobileNumber);
            user.MobileNumber = Helper.ValidString();

            Console.Write(Constant.EmailAddress);
            user.EmailAddress = Helper.ValidString();

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

        public static Booking GetBooking()
        {
            Console.Clear();
            Booking booking = new Booking
            {
                Car = GetCarDetails(),
                Journey = GetJourney()
            };

            return booking;
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
                Console.WriteLine(Constant.VacantSeatNotCorrect);
            }

            return car;
        }

        public static Journey GetJourney()
        {
            Journey journey = new Journey();

            Console.WriteLine(Constant.JourneyDetail);
            Console.Write(Constant.Date);
            journey.Date = Helper.ValidDate();

            Console.Write(Constant.Begining);
            journey.StatingPlace = Helper.ValidString();

            Console.Write(Constant.Ending);
            journey.EndPlace = Helper.ValidString();

            Console.Write(Constant.Pincode);
            journey.Pincoode = Helper.ValidInteger();

            Console.Write(Constant.LandMark);
            journey.LandMark = Console.ReadLine();
            return journey;
        }

        public static ViaPoint GetPlaces()
        {
            ViaPoint point = new ViaPoint();

            return point;
        }

        public static Journey GetRiderJourney()
        {
            Console.Clear();
            Journey journey = new Journey();

            Console.WriteLine(Constant.JourneyDetail);
            Console.Write(Constant.Date);
            journey.Date = Helper.ValidDate();

            Console.Write(Constant.Begining);
            journey.StatingPlace = Helper.ValidString();

            Console.Write(Constant.Ending);
            journey.EndPlace = Helper.ValidString();

            Console.Write(Constant.Pincode);
            journey.Pincoode = Helper.ValidInteger();

            Console.Write(Constant.LandMark);
            journey.LandMark = Console.ReadLine();
            return journey;
        }

        public static bool RideChoice()
        {
            Console.WriteLine(Constant.RideChoice);

            RideOption option = (RideOption)Helper.ValidInteger();

            if(option== RideOption.Yes)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public static BookingStatus RequestChoice()
        {
            Console.WriteLine(Constant.RequestChoice);

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
                    return BookingStatus.Pending;
            }
        }
    }
}
