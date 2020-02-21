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

        public int CreateMovie(string movieName, string movieDescription)
        {
            MovieModel data = new MovieModel
            {
                MovieName = movieName,
                MovieDescription = movieDescription
            };

            string sql = @"insert into dbo.Movies(MovieName, MovieDescription) values (@MovieName, @MovieDescription);";

            return SQLDataAccess.SaveData(sql, data);
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
