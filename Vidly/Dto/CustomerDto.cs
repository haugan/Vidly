using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        //[MinimumAgeValidation] See custom validation class..
        public DateTime? BirthDate { get; set; } 

        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }

        // AVOID COUPLING WITH DOMAIN OBJECT
        public MembershipTypeDto MembershipType { get; set; }
    }
}