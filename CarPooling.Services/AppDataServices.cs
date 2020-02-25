using CarPooling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Services
{
    public class AppDataServices
    {
        public static List<User> Users { get; set; }

        static AppDataServices()
        {
            Users = new List<User>();
        }

        public static bool AddNewUser(User user)
        {
            Users.Add(user);
            return true;
        }

        public static User Authentication(Login credentials)
        {
            User user = Users.FirstOrDefault(a => a.Id == credentials.UserName && a.Password == credentials.Password);

            if (user != null)
                return user;

            return null;
        }

        public static bool DeleteUser(User user)
        {
            if (user != null)
            {
                Users.Remove(user);
                return true;
            }

            return false;
        }

        public static bool UpdateUserDetail(User newDetails,User oldDetails)
        {
            if (oldDetails != null)
            {
                oldDetails = newDetails;
                return true;
            }

            return false;
        }

        public static User GetUser(string userId)
        {
            return Users.FirstOrDefault(a => a.Id == userId);
        }

        public static Booking GetBooking(Guid id)
        {
            return Users.SelectMany(a => a.Bookings).FirstOrDefault(a => a.Id == id);
        }

        public static bool GetUserNameAvailabilty(string Id)
        {
            return Users.Select(a => a.Id).Contains(Id);
        }
    }
}
