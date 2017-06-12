using System.Collections.Generic;
using System.Linq;
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

            var customers = GetCustomers();

            var model = new CustomerIndexViewModel
            {
                Customers = customers
            };

            return View(model);
        }

        // GET: Customers/Details/123
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var model = new CustomerDetailsViewModel
            {
                Id = customer.Id,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname
            };

            return View(model);
        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Firstname = "Marius", Lastname = "Riis Haugan" },
                new Customer { Id = 2, Firstname = "Julia", Lastname = "Skjelbred" },
                new Customer { Id = 3, Firstname = "Fauna", Lastname = "Riis Skjelbred" },
                new Customer { Id = 4, Firstname = "Katrin", Lastname = "Skjelbred" }
            };
        }
    }
}