using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    // DEMONSTRATING A "PURE" VIEW MODEL
    public class MovieFormViewModel
    {
        // DEFAULT CONSTRUCTOR FOR WHEN CREATING NEW MOVIE
        public MovieFormViewModel()
        {
            Id = 0; // Populate hidden field in Form view to pass validation
        }

        // LOADED CONSTRUCTOR FOR WHEN EDITING EXISTING MOVIE
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenreId = movie.GenreId;
        }

        // DYNAMIC PAGE HEADER
        public string PageHeader
        {
            get
            {
                return (Id != 0) ? "Edit movie" : "New movie";
            }
        }

        // MOVIE ID
        public int? Id { get; set; } // Nullable type initializes to null (default: 0)

        // MOVIE TITLE
        public string Title { get; set; }

        // MOVIE RELEASE DATE
        [Display(Name = "Release date")]
        public DateTime? ReleaseDate { get; set; } // Nullable type initializes to null (default: 01-01-2001)

        // MOVIE STOCK AMOUNT
        [Display(Name = "Stock amount")]
        public int? Stock { get; set; } // Nullable type initializes to null (default: 0)

        // GENRE ID
        public byte? GenreId { get; set; } // Nullable type initializes to null (default: 0)

        // GENRE LIST
        public IEnumerable<Genre> Genres { get; set; }
    }
}