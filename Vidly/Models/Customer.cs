using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(255)]
        public string Lastname { get; set; }


        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}