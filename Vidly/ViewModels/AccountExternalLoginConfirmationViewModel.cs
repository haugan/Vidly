using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class AccountExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Employee #")]
        public int EmployeeNumber { get; set; }

        [Required]
        [Display(Name = "Phone #")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
