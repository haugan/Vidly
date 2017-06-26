using System.Collections.Generic;

namespace Vidly.ViewModels
{

    public class ManageConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}