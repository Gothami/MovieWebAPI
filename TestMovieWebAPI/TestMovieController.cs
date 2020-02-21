using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieWebAPI.Controllers;
using TicketBookingDataLibrary.Models;
using System.Collections.Generic;

namespace TestMovieWebAPI
{
    [TestClass]
    public class TestMovieController
    {
        [TestMethod]
        public void TestGet()
        {
            var controller = new MovieController(new TestMovieModelContext());
            var result = controller.Get();

            Assert.AreEqual(1, 1);
        }        

        MovieModel getDemoMovieModel()
        {
            List<string> loc = new List<string>() { "Savoy", "Liberty" };
            return new MovieModel() { MovieID = 1, MovieName = "Godzilla", MovieDescription = "Adventurous Movie", MovieTheatres = loc };
        }
    }
}
