using CarPooling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling
{
    public class Display
    {
        public static void OfferRide(Ride ride)
        {
            Console.Clear();
            Console.WriteLine(ride.Id);
            Console.WriteLine(Constant.CarDetail);
            Console.WriteLine(Constant.CarNumber + ride.Car.Number);
            Console.WriteLine(Constant.CarModel + ride.Car.Model);
            Console.WriteLine(Constant.VacantSeat + ride.Car.VacantSeat);
            Console.WriteLine(Constant.CarCapacity + ride.Car.MaxSeatCapacity);
            Console.WriteLine(Constant.JourneyDetail);
            Console.WriteLine(Constant.Source + ride.SourceCityName);
            Console.WriteLine(Constant.ViaCities+ "  : "+ ride.Points.Count);
            foreach (var city in ride.Points)
            {
                Console.WriteLine(Constant.City + city.City);
            }
            Console.WriteLine(Constant.Destination + ride.DestinationCityName);
            Console.WriteLine(Constant.Date + ride.Date);
            Console.WriteLine(Constant.Pincode + ride.Pincode);
            Console.WriteLine(Constant.LandMark + ride.LandMark);
            Console.ReadKey();
        }

        public static void BookingRequest(Booking booking)
        {
            Console.Clear();
            Console.WriteLine(booking.Id);
            Console.WriteLine(Constant.JourneyDetail);
            Console.WriteLine(Constant.Source+ booking.SourceCityName);
            Console.WriteLine(Constant.Destination + booking.DestinationCityName);
            Console.WriteLine(Constant.Date + booking.Date);
            Console.WriteLine(Constant.Pincode + booking.Pincode);
            Console.WriteLine(Constant.LandMark + booking.LandMark);
            Console.ReadKey();
        }
    }
}
