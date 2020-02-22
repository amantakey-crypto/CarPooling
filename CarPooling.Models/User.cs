using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarPooling.Models.Enum;

namespace CarPooling.Models
{
    public class User
    {
        public string Id { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string MobileNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public string DrivingLicence { get; set; }

        public string IdProofNumber { get; set; }

        public List<Booking> Bookings { get; set; }

        public List<Booking> PastBookings { get; set; }

        public List<Rating> Ratings { get; set; }

        public User()
        {
            Bookings = new List<Booking>();

            PastBookings = new List<Booking>();

            Ratings = new List<Rating>();
        }
    }
}
