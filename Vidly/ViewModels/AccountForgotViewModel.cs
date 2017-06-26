using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class AccountForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
