using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class AccountForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
