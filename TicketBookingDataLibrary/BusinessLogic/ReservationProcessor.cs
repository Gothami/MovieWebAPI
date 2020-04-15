using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingDataLibrary.DataAccess;
using TicketBookingDataLibrary.Models;

namespace TicketBookingDataLibrary.BusinessLogic
{
    public class ReservationProcessor
    {
        public int ReserveTickets(ReservationModel reservationModel)
        {
            int locationID = reservationModel.locationID;
            string movieName = reservationModel.movieName;
            int noOfTickets = reservationModel.noOfTickets;
            string seatZone = reservationModel.seatZone;
            DateTime date = reservationModel.movieDate;
            int totalTickets = 0;
            string dateOnly = date.ToShortDateString();
            string screenName = reservationModel.selectedLocationText;

            string movieIDsql = @"SELECT MovieID FROM dbo.Movies WHERE MovieName = '" + movieName + "'";            
            int movieID = SQLDataAccess.ExecuteQuery(movieIDsql).FirstOrDefault().MovieID;

            if (movieID > 0)
            {
                string sql = @"UPDATE dbo.Reservations SET AvailableTickets = AvailableTickets - " + noOfTickets +
                " WHERE (ShowMovieID = " + movieID + " AND ShowTheatreID = " + locationID + " AND SeatZone = '" + seatZone + "' AND MovieTime = '" + dateOnly + "')";

                int result = SQLDataAccess.UpdateNoOfTickets(sql);

                if (result <= 0)
                {
                    string NewSql = @"SELECT TotalTickets from dbo.SeatZones WHERE ScreenName = '" + screenName + "' AND SeatZone= '" + seatZone + "'";
                    totalTickets = SQLDataAccess.GetTotalTickets(NewSql);

                    int availableTickets = totalTickets - noOfTickets;
                    ReservationModel data = new ReservationModel
                    {
                        movieID = movieID,
                        locationID = locationID,
                        dateOnly = dateOnly,
                        seatZone = seatZone,
                        noOfTickets = noOfTickets,
                        availableTickets = availableTickets
                    };

                    string sqlUpdate = @"INSERT INTO dbo.Reservations (ShowMovieID, ShowTheatreID, MovieTime, SeatZone, NoOfTickets, AvailableTickets) 
                                        values (@movieID, @locationID,@dateOnly, @seatZone, @noOfTickets, @availableTickets)";

                    return SQLDataAccess.SaveData(sqlUpdate, data);
                }

                return result;
            }
            else
            {
                return -1;
            }
        }
    }
}
