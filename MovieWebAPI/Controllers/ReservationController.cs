using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TicketBookingDataLibrary.BusinessLogic;
using TicketBookingDataLibrary.Models;

namespace MovieWebAPI.Controllers
{
    public class ReservationController : ApiController
    {
        ReservationProcessor reservationProcessor = new ReservationProcessor();

        public int Post()
        {
            var jsonString = String.Empty;
            var request = HttpContext.Current.Request;
            request.InputStream.Position = 0;
            using (var inputStream = new StreamReader(request.InputStream))
            {
                jsonString = inputStream.ReadToEnd();
            }

            var reservationObject = JsonConvert.DeserializeObject<ReservationModel>(jsonString);

            return reservationProcessor.ReserveTickets(reservationObject);            
        }
    }
}
