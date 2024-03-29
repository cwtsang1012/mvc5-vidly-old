﻿using System; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View(GetMovie());
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            //return Action resolved
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>()
            {
                new Customer() { Name = "Customer 1" },
                new Customer() { Name = "Customer 2" } 
            };

            var viewModel = new RandomMovieViewModel() { Movie = movie, Customers = customers };
        
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        [Route("Movies/Released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        private IEnumerable<Movie> GetMovie()
        {
            return new List<Movie>()
            {
                new Movie() { Id = 1, Name = "Shrek!" },
                new Movie() { Id = 2, Name = "Wall-E" }
            };
        }

        
    }
}