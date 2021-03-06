﻿using System;
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
            AmountInStock = movie.AmountInStock;
            GenreId = movie.GenreId;
        }

        // DYNAMIC PAGE HEADER
        public string PageHeader
        {
            get
            {
                return (Id != 0) ? "Edit existing movie" : "Register new movie";
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
        [Display(Name = "Amt. in stock")]
        public int? AmountInStock { get; set; } // Nullable type initializes to null (default: 0)

        // GENRE ID
        public byte? GenreId { get; set; } // Nullable type initializes to null (default: 0)

        // GENRE LIST
        public IEnumerable<Genre> Genres { get; set; }
    }
}