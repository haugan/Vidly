using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class ManageAddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}