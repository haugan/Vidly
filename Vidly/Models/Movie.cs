using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(255)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Release date is required.")]
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Added date is required.")]
        [Display(Name = "Added date")]
        public DateTime AddedDate { get; set; }

        [Required(ErrorMessage = "Stock number is required.")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}