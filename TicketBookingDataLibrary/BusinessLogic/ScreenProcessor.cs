using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TicketBookingDataLibrary.DataAccess;
using TicketBookingDataLibrary.Models;

namespace TicketBookingDataLibrary.BusinessLogic
{
    public static class ScreenProcessor
    {
        public static string ScreenLayoutFilePath = "E:\\Visual Studio Files\\MovieWebAPI\\CustomerScreenLayouts";

        public static int UploadScreenLayout(string screenName,byte[] ff)
        {
            //if (File.ContentLength > 0)

            //{
                var fileName = screenName;
                var path = Path.Combine(ScreenLayoutFilePath, screenName);
            //File.SaveAs(path);
            //}
            try
            {
                System.IO.File.WriteAllBytes(path, ff);
                return 1;

            }
            catch(Exception e)
            {
                return 0;
            }

        }

        public static List<ScreenModel> RetrieveAllScreens()
        {
            string sql = "select * from dbo.Screens";
            return SQLDataAccess.LoadData<ScreenModel>(sql).ToList();
        }

        public static List<ScreenLayoutModel> RetrieveScreenLayout()
        {
            string sql = "select * from dbo.Screens";
            return SQLDataAccess.LoadData<ScreenLayoutModel>(sql).ToList();            
        }

        public static Image RetrieveScreenLayout(string screenName)
        {
            Image screenLayout = Image.FromFile(Path.Combine(ScreenLayoutFilePath, screenName + ".png"));
            return screenLayout;
        }
    }
}
