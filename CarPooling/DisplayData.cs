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
        public static void OfferRide(Booking booking)
        {
            Console.WriteLine(Constant.CarDetail);
            Console.WriteLine(Constant.CarNumber + booking.Car.Number);
            Console.WriteLine(Constant.CarModel + booking.Car.Model);
            Console.WriteLine(Constant.VacantSeat + booking.Car.VacantSeat);
            Console.WriteLine(Constant.CarCapacity + booking.Car.MaxSeatCapacity);
            Console.WriteLine(Constant.JourneyDetail);
            Console.WriteLine(Constant.Begining + booking.Journey.StatingPlace);
            Console.WriteLine(Constant.Ending + booking.Journey.EndPlace);
            Console.WriteLine(Constant.Date + booking.Journey.Date);
        }

        public static void RideRequest(Booking booking)
        {
            Console.WriteLine(Constant.JourneyDetail);
            Console.WriteLine(Constant.Begining + booking.Journey.StatingPlace);
            Console.WriteLine(Constant.Ending + booking.Journey.EndPlace);
            Console.WriteLine(Constant.Date + booking.Journey.Date);
            Console.WriteLine(Constant.Pincode + booking.Journey.Pincoode);
            Console.WriteLine(Constant.LandMark + booking.Journey.LandMark);
        }
    }
}
