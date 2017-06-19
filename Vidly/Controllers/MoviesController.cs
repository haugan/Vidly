using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

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
            var dbMovies = _context.Movies
                .Include(m => m.Genre)
                .ToList();

            var model = new MoviesIndexViewModel
            {
                Movies = dbMovies
            };

            return View(model);
        }

        // GET: Movies/Details/777
        public ActionResult Details(int id)
        {
            var dbMovie = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (dbMovie == null)
                return HttpNotFound();

            var model = new MovieDetailsViewModel
            {
                Title = dbMovie.Title,
                ReleaseDate = dbMovie.ReleaseDate,
                AddedDate = dbMovie.AddedDate,
                Stock = dbMovie.Stock,
                Genre = dbMovie.Genre
            };


            return View(model);
        }

        // GET: Movies/Edit/777
        public ActionResult Edit(int id)
        {
            var dbMovie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (dbMovie == null)
                return HttpNotFound($"Could not find movie with id {id} in database.");

            var viewModel = new MovieFormViewModel()
            {
                Movie = dbMovie,
                Genres = _context.Genres.ToList()
            };

            return View("Form", viewModel);
        }

        // GET: Movies/New
        public ActionResult New()
        {
            var dbGenres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(), // Removes implicit MovieId validation in form (initializes default model values)
                Genres = dbGenres
            };

            return View("Form", viewModel);
        }

        // POST: Movies/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie) // Model binding 
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = new Movie(),
                    Genres = _context.Genres.ToList()
                };

                return View("Form", viewModel);
            }

            // ID DEFAULTS TO 0 AND INHERENTLY REQUIRED (FIX)
            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var dbMovie = _context.Movies.Single(m => m.Id == movie.Id);
                dbMovie.Title = movie.Title;
                dbMovie.ReleaseDate = movie.ReleaseDate;
                dbMovie.Stock = movie.Stock;
                dbMovie.GenreId = movie.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}