using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Added date")]
        public DateTime AddedDate { get; set; }

        [Required]
        [Display(Name = "Stock")]
        public int Stock { get; set; }


        [Required]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}