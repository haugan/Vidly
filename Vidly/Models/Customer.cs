using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "First name")]
        [StringLength(255)]
        [Required(ErrorMessage = "First name is required.")]
        public string Firstname { get; set; }

        [Display(Name = "Last name")]
        [StringLength(255)]
        [Required(ErrorMessage = "Last name is required.")]
        public string Lastname { get; set; }

        [Display(Name = "Date of Birth")]
        [MinimumAgeValidation]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required(ErrorMessage = "Membership type is required.")]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}