using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketBookingDataLibrary.BusinessLogic;
using TicketBookingDataLibrary.DataAccess;
using TicketBookingDataLibrary.Models;

namespace MovieWebAPI.Controllers
{
    public class MovieController : ApiController
    {
        public IEnumerable<MovieModel> Get()
        {
            return MovieProcessor.RetrieveData();

        }
    }
}
