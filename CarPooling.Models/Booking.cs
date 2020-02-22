using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarPooling.Models.Enum;

namespace CarPooling.Models
{
    public class Booking
    {
        public Guid Id { get; set; }

        public Car Car { get; set; }

        public Journey Journey { get; set; }

        public User Owner { get; set; }

        public BookingStatus Status { get; set; }

        public UserType Type { get; set; }

        public List<User> Traveller { get; set; }

        public Booking()
        {
            Traveller = new List<User>();
        }
    }
}
