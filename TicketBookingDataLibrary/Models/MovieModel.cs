using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingDataLibrary.Models
{
    public class MovieModel
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public List<string> MovieTheatres = new List<string>();
        public Dictionary<string, List<DateTime>> MovieLocations { get; set; }
    }
}
