using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Models
{
    public class Journey
    {
        public string StatingPlace { get; set; }

        public string EndPlace { get; set; }

        public Int32 Pincoode { get; set; }

        public string LandMark { get; set; }

        public List<ViaPoint> Places { get; set; }

        public DateTime Date { get; set; }

    }
}
