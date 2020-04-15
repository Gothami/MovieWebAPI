using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingDataLibrary.Models
{
    public class ReservationModel
    {
        public int locationID { get; set; }
        public int noOfTickets { get; set; }
        public string seatZone { get; set; }
        public int movieID { get; set; }
        public string dateOnly { get; set; }
        public int availableTickets { get; set; }
        public DateTime movieDate { get; set; }
        public string movieName { get; set; }
        public string selectedLocationText { get; set; } //Location Text
    }
}
