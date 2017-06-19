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

        public DateTime AddedDate { get; set; }

        [StockRangeValidation]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}