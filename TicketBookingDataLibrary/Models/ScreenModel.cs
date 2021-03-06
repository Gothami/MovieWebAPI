﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingDataLibrary.Models
{
    public class ScreenModel
    {
        public int ScreenID { get; set; }
        public string ScreenName { get; set; }
        public string ScreenLayoutLocation { get; set; }
        public byte[] screenLayout { get; set; }
        public string[] seatZones { get; set; }
    }
}
