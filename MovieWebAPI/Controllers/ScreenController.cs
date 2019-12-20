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
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            byte[] inputStream = new byte[httpRequest.InputStream.Length + 1];
            httpRequest.InputStream.Read(inputStream, 0, inputStream.Length);
            ContentDisposition contentDisposition = new ContentDisposition(httpRequest.Headers["Content-Disposition"]);

            if(ScreenProcessor.UploadScreenLayout(contentDisposition.FileName, inputStream) == 1)
                result = Request.CreateResponse(HttpStatusCode.Created);            
            else            
                result = Request.CreateResponse(HttpStatusCode.BadRequest);            

            return result;
        }
    }
}