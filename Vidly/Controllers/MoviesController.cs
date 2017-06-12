using System.Collections.Generic;
using System.Linq;
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
            var movies = GetMovies();

            var model = new MovieIndexViewModel
            {
                Movies = movies
            };

            return View(model);
        }

        // GET: Movies/Details/123
        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var model = new MovieDetailsViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre
            };

            return View(model);
        }

        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Title = "The Raid", Genre = "Action" },
                new Movie { Id = 2,Title = "Memento", Genre = "Thriller" },
                new Movie { Id = 3,Title = "Cloud Atlas", Genre = "Sci-Fi" },
                new Movie { Id = 4,Title = "The Babadook", Genre = "Horror" },
                new Movie { Id = 5,Title = "Step Brothers", Genre = "Comedy" },
                new Movie { Id = 6,Title = "Manchester by the Sea", Genre = "Drama" }
            };
        }
    }
}