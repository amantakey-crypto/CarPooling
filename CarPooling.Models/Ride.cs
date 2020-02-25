using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Models
{
    public class Ride 
    {
        public Guid Id { get; set; }

        public string SourceCityName { get; set; }

        public string DestinationCityName { get; set; }

        public int Pincode { get; set; }

        public string LandMark { get; set; }

        public DateTime Date { get; set; }

        public Car Car { get; set; }

        public List<Places> Points { get; set; }

        public List<Guid> RequestBookerId { get; set; }

        public List<Guid> AcceptedBookerId { get; set; }

        public Ride()
        {
            RequestBookerId = new List<Guid>();

            AcceptedBookerId = new List<Guid>();

            Points = new List<Places>();
        }
    }
}
