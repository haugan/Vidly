using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Display(Name = "Release date")]
        [Required(ErrorMessage = "Release date is required.")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Added date")]
        [Required(ErrorMessage = "Added date is required.")]
        public DateTime AddedDate { get; set; }

        [StockRangeValidation]
        [Required(ErrorMessage = "Stock is required.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}