using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies
                .Include(m => m.Genre)
                .ToList();

            var model = new MoviesIndexViewModel
            {
                Movies = movies
            };

            return View(model);
        }

        // GET: Movies/Details/123
        public ActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var model = new MovieDetailsViewModel
            {
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                AddedDate = movie.AddedDate,
                Stock = movie.Stock,
                Genre = movie.Genre
            };


            return View(model);
        }

    }
}