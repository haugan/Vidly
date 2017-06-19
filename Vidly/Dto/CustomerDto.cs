using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "First name is required.")]
        public string Firstname { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Last name is required.")]
        public string Lastname { get; set; }

        [MinimumAgeValidation]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required(ErrorMessage = "Membership type is required.")]
        public byte MembershipTypeId { get; set; }
    }
}