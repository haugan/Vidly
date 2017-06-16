﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(255)]
        [Display(Name = "First name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(255)]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        [Display(Name = "Date of Birth")]
        [AgeValidation]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required(ErrorMessage = "Membership type is required.")]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}