using CarPooling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Services
{
    public class CitiesRecord
    {
        public static List<Places> Cities { get; set; }

        static CitiesRecord()
        {
            Cities = new List<Places>()
            {
                new Places()
                {
                    City="HYD",
                    Pincode=12345,
                },
                new Places()
                {
                    City="Bhilai",
                    Pincode=490023,
                },
                new Places()
                {
                    City="Ranchi",
                    Pincode=834001,
                },
                new Places()
                {
                    City="Delhi",
                    Pincode=000001,
                },
                new Places()
                {
                    City="Gaya",
                    Pincode=12345,
                },
                new Places()
                {
                    City="Mumbai",
                    Pincode=490023,
                },
                new Places()
                {
                    City="Bokaro",
                    Pincode=834001,
                },
                new Places()
                {
                    City="Jamshedpur",
                    Pincode=000001,
                },
                new Places()
                {
                    City="Ambikapur",
                    Pincode=12345,
                },
                new Places()
                {
                    City="Bero",
                    Pincode=490023,
                },
                new Places()
                {
                    City="Manendragarh",
                    Pincode=834001,
                },
                new Places()
                {
                    City="Raipur",
                    Pincode=000001,
                },
            };
        }

        public bool CheckValidCity(string cityName)
        {
            var city = Cities?.FirstOrDefault(a => a.City == cityName);
            if (city != null)
                return true;

            else
                return false;   
        }
    }
}
