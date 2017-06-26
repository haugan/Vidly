using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Display(Name = "Employee #")]
        [Required(ErrorMessage = "Employee # is required.")]
        public int EmployeeNumber { get; set; }

        [Display(Name = "Phone #")]
        [Required(ErrorMessage = "Phone # is required.")]
        public int Phone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
