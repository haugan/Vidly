using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private readonly ApplicationDbContext _db;

        public RentalsController()
        {
            _db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        // POST: api/rentals
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto dto)
        {
            var customer = _db.Customers.Single(c => c.Id == dto.CustomerId);

            // SELECT * FROM Movies IN (1,2,3,4)
            var movies = _db.Movies.Where(m => dto.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.AmountAvailable == 0)
                    return BadRequest("No more available movies!");

                movie.AmountAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    RentedDate = DateTime.Now
                };

                _db.Rentals.Add(rental);
            }

            _db.SaveChanges();
            return Ok();
        }
    }
}
