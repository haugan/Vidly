using System;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? BirthDate { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}