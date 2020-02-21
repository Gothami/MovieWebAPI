using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingDataLibrary.Models;

namespace TestMovieWebAPI
{
    public class TestMovieModelContext : IMovieModelContext
    {
        public DbSet<MovieModel> movieModel { get; set; }

        public TestMovieModelContext()
        {
            this.movieModel = new TestMovieModelDbSet();
        }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(MovieModel item) { }

        public void Dispose() { }

        public int CreateMovie(string movieName, string movieDescription)
        {
            MovieModel mModel = new MovieModel();
            mModel.MovieName = movieName;
            mModel.MovieDescription = movieDescription;
            MovieModel mm = movieModel.Add(mModel);

            if (mm != null)
            {
                return 1;
            }
            else
            {
                return -1;
            }

        }

        public List<MovieModel> RetrieveData()
        {
            //var movieObject = JsonConvert.DeserializeObject<MovieModel>(jsonString);
            return new List<TicketBookingDataLibrary.Models.MovieModel>();
        }        
    }
}
