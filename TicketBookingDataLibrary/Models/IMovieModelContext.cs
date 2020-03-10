using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingDataLibrary.Models
{
    public interface IMovieModelContext : IDisposable
    {
        DbSet<MovieModel> movieModel { get; }
        void MarkAsModified(MovieModel item);
        List<MovieModel> RetrieveData();
        int CreateMovie(string movieName, string movieDescription, List<string> movieTheatres);
    }
}

