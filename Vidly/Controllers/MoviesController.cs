using System.Collections.Generic;
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
            var movies = new List<Movie>
            {
                new Movie {Name = "The Raid", Genre = "Action" },
                new Movie {Name = "Memento", Genre = "Thriller" },
                new Movie {Name = "Cloud Atlas", Genre = "Sci-Fi" },
                new Movie {Name = "The Babadook", Genre = "Horror" },
                new Movie {Name = "Step Brothers", Genre = "Comedy" },
                new Movie {Name = "Manchester by the Sea", Genre = "Drama" }
            };

            var model = new MovieIndexViewModel
            {
                Movies = movies
            };

            return View(model);
        }
    }
}