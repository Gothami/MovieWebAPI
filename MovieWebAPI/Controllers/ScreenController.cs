using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using TicketBookingDataLibrary.BusinessLogic;
using TicketBookingDataLibrary.Models;

namespace MovieWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:16955", headers: "*", methods: "*")]
    public class ScreenController : ApiController
    {
        //GET: Return all screen names for the given movie name
        public IEnumerable<MovieLocationsModel> GetScreenNames(string movieName)
        {
            return ScreenProcessor.RetrieveScreensAccordingToMovie(movieName);
        }

        //GET: Screen
        public IHttpActionResult Get(string screenName)
        {
            var stream = File.OpenRead(Path.Combine("C:\\Goth Documents\\Documents\\Visual Studio 2015\\Projects\\Ticket Booking\\CustomerScreenLayouts", screenName + ".png"));
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            response.Content.Headers.ContentLength = stream.Length;
            return ResponseMessage(response);
        }

        //GET: Return screen zones for the given screen name
        [HttpGet]
        public IEnumerable<string> GetScreenZones(string z_screenName)
        {
            return ScreenProcessor.RetrieveScreenZones(z_screenName);
        }

        // POST: Screen
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.NotAcceptable);
                var jsonString = String.Empty;
                var request = HttpContext.Current.Request;
                request.InputStream.Position = 0;
                using (var inputStream = new StreamReader(request.InputStream))
                {
                    jsonString = inputStream.ReadToEnd();
                }

                var screenLayoutObject = JsonConvert.DeserializeObject<ScreenModel>(jsonString);
                if (ScreenProcessor.UploadScreenLayout(screenLayoutObject.ScreenName, screenLayoutObject.screenLayout, screenLayoutObject.seatZones) == 1)
                    result = Request.CreateResponse(HttpStatusCode.Created);
                else
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);

            return result;
        }
    }
}