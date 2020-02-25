using CarPooling.Models;
using CarPooling.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static string GetValidEmail()
        {
            string email = Console.ReadLine();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (string.IsNullOrEmpty(email) || !match.Success)
            {
                Console.WriteLine(Constant.InvalidValue);
                email = GetValidEmail();
            }

            return email;
        }

        public static string GetValidUserName()
        {
            string userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName) || (!AppDataServices.GetUserNameAvailabilty(userName)))
            {
                Console.WriteLine(Constant.UserNameAvailable);
                userName = GetValidUserName();
            }

            return userName;
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
