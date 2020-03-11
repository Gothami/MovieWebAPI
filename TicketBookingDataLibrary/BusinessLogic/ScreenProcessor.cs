using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using TicketBookingDataLibrary.DataAccess;
using TicketBookingDataLibrary.Models;

namespace TicketBookingDataLibrary.BusinessLogic
{
    public static class ScreenProcessor
    {
        public static string ScreenLayoutFilePath = HostingEnvironment.ApplicationPhysicalPath + Path.DirectorySeparatorChar + "ScreenLayouts";

        public static int UploadScreenLayout(string m_screenName,byte[] file, string[] screenZones)
        {
            List<ScreenZone> data2 = new List<ScreenZone>();
            var path = string.Empty;
            var fileName = m_screenName;

            if (!Directory.Exists(ScreenLayoutFilePath))
                System.IO.Directory.CreateDirectory(ScreenLayoutFilePath);

            path = Path.Combine(ScreenLayoutFilePath, m_screenName);

            ScreenModel data = new ScreenModel
            {
                ScreenName = m_screenName,
                ScreenLayoutLocation = path.ToString(),
                seatZones = screenZones
            };

            foreach(string zone in screenZones)
            {
                ScreenZone screenZone = new ScreenZone
                {
                    ScreenName = m_screenName,
                    SeatZone = zone
                };
                data2.Add(screenZone);
            }

            try
            {
                System.IO.File.WriteAllBytes(path, file);
            }
            catch (Exception e)
            {
                return 0;
            }

            string sql = @"insert into dbo.Screens(ScreenName, ScreenLayoutLocation) values (@ScreenName, @ScreenLayoutLocation);";
            string sql2 = @"insert into dbo.SeatZones(ScreenName, SeatZone) values (@ScreenName, @SeatZone);";

            int result = SQLDataAccess.SaveData(sql2, data2);

            if (result == data2.Count)
                return SQLDataAccess.SaveData(sql, data);
            else
                return 0;
        }

        //Return all screens in DB
        public static List<ScreenModel> RetrieveAllScreens()
        {
            string sql = "select * from dbo.Screens";
            return SQLDataAccess.LoadData<ScreenModel>(sql).ToList();
        }

        //Return specific screen according to requested movie
        public static List<MovieLocationsModel> RetrieveScreensAccordingToMovie(string movieName)
        {
            string sql2= "select dbo.Screens.ScreenID, dbo.MovieLocations.MovieName, dbo.MovieLocations.ScreenName from dbo.MovieLocations inner join dbo.Screens on dbo.Screens.ScreenName = dbo.MovieLocations.ScreenName where dbo.MovieLocations.MovieName='" + movieName + "'";
            return SQLDataAccess.LoadData<MovieLocationsModel>(sql2).ToList();
        }

        public static List<ScreenModel> RetrieveScreenLayout()
        {
            string sql = "select * from dbo.Screens";
            return SQLDataAccess.LoadData<ScreenModel>(sql).ToList();            
        }

        public static Image RetrieveScreenLayout(string screenName)
        {
            Image screenLayout = Image.FromFile(Path.Combine(ScreenLayoutFilePath, screenName + ".png"));
            return screenLayout;
        }
    }
}
