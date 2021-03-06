﻿using System;
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

        public Guid RequestedRide { get; set; }

        public string SourceCityName { get; set; }

        public string DestinationCityName { get; set; }

        public int Pincode { get; set; }

        public string LandMark { get; set; }

        public BookingStatus Status { get; set; }

        public DateTime Date { get; set; }
    }
}
