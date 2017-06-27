using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MoviesController()
        {
            _db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        // GET: movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.MovieManager))
                return View("TableFull");

            return View("TableReadOnly");
        }

        // GET: movies/details/777
        public ActionResult Details(int id)
        {
            var dbMovie = _db.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (dbMovie == null)
                return HttpNotFound();

            var model = new MovieDetailsViewModel
            {
                Title = dbMovie.Title,
                ReleaseDate = dbMovie.ReleaseDate,
                AddedDate = dbMovie.AddedDate,
                AmountInStock = dbMovie.AmountInStock,
                Genre = dbMovie.Genre
            };


            return View(model);
        }

        // GET: movies/edit/777
        [Authorize(Roles = RoleName.MovieManager)]
        public ActionResult Edit(int id)
        {
            var dbMovie = _db.Movies.SingleOrDefault(m => m.Id == id);

            if (dbMovie == null)
                return HttpNotFound($"Could not find movie with id {id} in database.");

            var viewModel = new MovieFormViewModel(dbMovie)
            {
                Genres = _db.Genres.ToList()
            };

            return View("Form", viewModel);
        }

        // GET: movies/new
        [Authorize(Roles = RoleName.MovieManager)]
        public ActionResult New()
        {
            var dbGenres = _db.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Genres = dbGenres
            };

            return View("Form", viewModel);
        }

        // POST: movies/save
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.MovieManager)]
        public ActionResult Save(Movie movie) // Model binding 
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _db.Genres.ToList()
                };

                return View("Form", viewModel);
            }

            // ID DEFAULTS TO 0 AND INHERENTLY REQUIRED (FIX)
            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _db.Movies.Add(movie);
            }
            else
            {
                var dbMovie = _db.Movies.Single(m => m.Id == movie.Id);
                dbMovie.Title = movie.Title;
                dbMovie.ReleaseDate = movie.ReleaseDate;
                dbMovie.AmountInStock = movie.AmountInStock;
                dbMovie.GenreId = movie.GenreId;
            }

            _db.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}