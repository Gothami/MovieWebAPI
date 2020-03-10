using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingDataLibrary.DataAccess;
using TicketBookingDataLibrary.Models;

namespace TicketBookingDataLibrary.BusinessLogic
{
    public class MovieProcessor : IMovieModelContext
    {
        public DbSet<MovieModel> movieModel { get; set; }

        public int CreateMovie(string m_movieName, string m_movieDescription, List<string> m_movieTheatres)
        {
            List<MovieLocationsModel> data2 = new List<MovieLocationsModel>();
            MovieModel data = new MovieModel
            {
                MovieName = m_movieName,
                MovieDescription = m_movieDescription
            };

            foreach (string theatre in m_movieTheatres)
            {
                MovieLocationsModel movieTheatre = new MovieLocationsModel
                {
                    movieName = m_movieName,
                    screenName = theatre
                };
                data2.Add(movieTheatre);
            }            

            string sql = @"insert into dbo.Movies(MovieName, MovieDescription) values (@MovieName, @MovieDescription);";
            string sql2 = @"insert into dbo.MovieLocations(MovieName, ScreenName) values (@MovieName, @ScreenName);";
            
            int result = SQLDataAccess.SaveData(sql2, data2);
            if (result == m_movieTheatres.Count)
                return SQLDataAccess.SaveData(sql, data);
            else
                return 0;            
        }

        public List<MovieModel> RetrieveData()
        {
            string sql = @"select * from dbo.Movies;";

            return SQLDataAccess.LoadData<MovieModel>(sql).ToList();
        }        

        public void MarkAsModified(MovieModel item)
        {            
        }

        public void Dispose()
        {

        }

    }
}
