using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Display(Name = "Employee #")]
        [Required(ErrorMessage = "Phone number is required.")]
        public int EmployeeNumber { get; set; }

        [Display(Name = "Phone #")]
        [Required(ErrorMessage = "Phone number is required.")]
        public string Phone { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
