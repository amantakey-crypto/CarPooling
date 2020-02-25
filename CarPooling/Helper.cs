using CarPooling.Models;
using CarPooling.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling
{
    public class Helper
    {
        public static string ValidString()
        {
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine(Constant.InvalidValue);
                str = ValidString();
            }

            return str;
        }

        public static int ValidInteger()
        {
            if (!Int32.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine(Constant.InvalidValue);
                number = ValidInteger();
            }

            return number;
        }

        public static DateTime ValidDate()
        {
            if(!DateTime.TryParse(Console.ReadLine(),out DateTime date))
            {
                Console.WriteLine(Constant.InValidDate);
                date = ValidDate();
            }

            return date;
        }

        public static string GetValidCity()
        {
            string cityName = Console.ReadLine();
            CitiesRecord citiesRecord = new CitiesRecord();
            if (!citiesRecord.CheckValidCity(cityName))
            {
                Console.WriteLine(Constant.InvalidValue);
                cityName = GetValidCity();
                return cityName;
            }

            return cityName;
        }
    }
}
