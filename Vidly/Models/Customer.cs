using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First name")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}