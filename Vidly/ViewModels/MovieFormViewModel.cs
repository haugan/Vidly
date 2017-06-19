using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        // GENRE LIST
        public IEnumerable<Genre> Genres { get; set; }

        // MOVIE ID
        public int? Id { get; set; } // Nullable type initializes to null (default: 0)

        // MOVIE TITLE
        [StringLength(255)]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        // MOVIE RELEASE DATE
        [Display(Name = "Release date")]
        [Required(ErrorMessage = "Release date is required.")]
        public DateTime? ReleaseDate { get; set; } // Nullable type initializes to null (default: 01-01-2001)

        // MOVIE STOCK AMOUNT
        [Display(Name = "Stock amount")]
        [Range(1, 20, ErrorMessage = "Stock amount must be between 1 and 20.")]
        [Required(ErrorMessage = "Stock amount is required.")]
        public int? Stock { get; set; } // Nullable type initializes to null (default: 0)

        // GENRE ID
        [Required(ErrorMessage = "Genre is required.")]
        public byte? GenreId { get; set; } // Nullable type initializes to null (default: 0)

        // DYNAMIC PAGE HEADER
        public string PageHeader
        {
            get
            {
                return (Id != 0) ? "Edit movie" : "New movie";
            }
        }

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
    }
}