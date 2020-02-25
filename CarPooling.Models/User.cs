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

        public string Email { get; set; }

        public string Address { get; set; }

        public string DrivingLicence { get; set; }

        public string IdProofNumber { get; set; }

        public List<Ride> Rides { get; set; }

        public List<Booking> Bookings { get; set; }

        public List<Rating> Ratings { get; set; }

        public User()
        {
            Ratings = new List<Rating>();

            Rides = new List<Ride>();

            Bookings = new List<Booking>();
        }
    }
}
