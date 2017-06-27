using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
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

        // GET: api/movies
        public IHttpActionResult GetAllMovies()
        {
            // EAGER LOAD HIERARCHICAL TYPE ("INCLUDE") FOR DATATABLE CONSUMPTION THROUGH WEB API
            var dtos = _db.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(dtos);
        }

        // GET: api/movies/123
        public IHttpActionResult GetSingleMovie(int id)
        {
            var dbMovie = _db.Movies.SingleOrDefault(m => m.Id == id);

            if (dbMovie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(dbMovie));
        }

        // POST: api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.MovieManager)]
        public IHttpActionResult CreateMovie(MovieDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is not valid!");

            // AUTOMAP: <SourceType, DestinationType>(SourceObject)
            var movie = Mapper.Map<MovieDto, Movie>(dto);

            _db.Movies.Add(movie);
            _db.SaveChanges();

            // GET MOVIE ID CREATED BY DATABASE & ASSIGN TO DTO
            dto.Id = movie.Id;

            // RETURN URI OF NEWLY CREATED OBJECT (HttpActionResult)
            return Created(
                new Uri($"{Request.RequestUri}/{movie.Id}"), // URI
                dto); // Object
        }

        // PUT: api/movies/123
        [HttpPut]
        [Authorize(Roles = RoleName.MovieManager)]
        public IHttpActionResult UpdateMovie(int id, MovieDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dbMovie = _db.Movies.SingleOrDefault(m => m.Id == id);

            if (dbMovie == null)
                return NotFound();

            // AUTOMAP: (SourceObject, DestinationObject)
            Mapper.Map(dto, dbMovie);

            _db.SaveChanges();

            return Ok();
        }

        // DELETE: api/movies/123
        [HttpDelete]
        [Authorize(Roles = RoleName.MovieManager)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var dbMovie = _db.Movies.SingleOrDefault(m => m.Id == id);

            if (dbMovie == null)
                return NotFound();

            _db.Movies.Remove(dbMovie);
            _db.SaveChanges();

            return Ok();
        }
    }
}