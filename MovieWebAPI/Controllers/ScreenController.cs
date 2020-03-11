using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Web;
using System.Web.Http;
using TicketBookingDataLibrary.BusinessLogic;
using TicketBookingDataLibrary.Models;

namespace MovieWebAPI.Controllers
{
    public class ScreenController : ApiController
    {
        public IEnumerable<MovieLocationsModel> GetScreenNames(string movieName)
        {
            return ScreenProcessor.RetrieveScreensAccordingToMovie(movieName);
        }

        //GET: Screen
        public IHttpActionResult Get(string screenName)
        {
            var stream = File.OpenRead(Path.Combine("E:\\Visual Studio Files\\MovieWebAPI\\CustomerScreenLayouts", screenName + ".png"));
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            response.Content.Headers.ContentLength = stream.Length;
            return ResponseMessage(response);
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