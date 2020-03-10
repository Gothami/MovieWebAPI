using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TicketBookingDataLibrary.BusinessLogic;
using TicketBookingDataLibrary.DataAccess;
using TicketBookingDataLibrary.Models;

namespace MovieWebAPI.Controllers
{
    public class MovieController : ApiController
    {
        IMovieModelContext movieProcessor = new MovieProcessor();

        public MovieController() { }

        public MovieController(IMovieModelContext movieModelContext)
        {
            movieProcessor = movieModelContext;
        }

        public IEnumerable<MovieModel> Get()
        {
            return movieProcessor.RetrieveData();
        }

        public async Task<int> Post([FromBody] string json)
        {
            var jsonString = String.Empty;
            var request = HttpContext.Current.Request;
            request.InputStream.Position = 0;
            using (var inputStream = new StreamReader(request.InputStream))
            {
                jsonString = inputStream.ReadToEnd();
            }

            var movieObject = JsonConvert.DeserializeObject<MovieModel>(jsonString);

            return movieProcessor.CreateMovie(movieObject.MovieName, movieObject.MovieDescription, movieObject.MovieTheatres);
        }               
    }
}
