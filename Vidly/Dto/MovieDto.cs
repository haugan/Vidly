using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime AddedDate { get; set; }

        [Range(1, 20)]
        public int AmountInStock { get; set; }

        public int AmountAvailable { get; set; }

        [Required]
        public byte GenreId { get; set; }

        // AVOID COUPLING WITH DOMAIN OBJECT
        public GenreDto Genre { get; set; }
    }
}