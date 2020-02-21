using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingDataLibrary.Models;

namespace TestMovieWebAPI
{
    class TestMovieModelDbSet : TestDbSet<MovieModel>
    {
        public override MovieModel Find(params object[] keyValues)
        {
            return this.SingleOrDefault(movie => movie.MovieID == (int)keyValues.Single());
        }
    }
}
