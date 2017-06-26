using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class ManageVerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone #")]
        public string PhoneNumber { get; set; }
    }
}