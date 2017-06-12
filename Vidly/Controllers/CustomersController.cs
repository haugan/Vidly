using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {

            var customers = new List<Customer>
            {
                new Customer { Id = 1, Firstname = "Marius", Lastname = "Riis Haugan" },
                new Customer { Id = 2, Firstname = "Julia", Lastname = "Skjelbred" },
                new Customer { Id = 3, Firstname = "Fauna", Lastname = "Riis Skjelbred" },
                new Customer { Id = 4, Firstname = "Katrin", Lastname = "Skjelbred" }
            };

            var model = new CustomerIndexViewModel
            {
                Customers = customers
            };

            return View(model);
        }
    }
}