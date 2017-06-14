using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            // EAGER LOADING OF CUSTOMERS & LINKED MEMBERSHIP TYPE
            var customers = _context.Customers
                .Include(c => c.MembershipType)
                .ToList();

            var model = new CustomersIndexViewModel
            {
                Customers = customers
            };

            return View(model);
        }

        // GET: Customers/Details/123
        public ActionResult Details(int id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var model = new CustomerDetailsViewModel
            {
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                BirthDate = customer.BirthDate,
                MembershipType = customer.MembershipType
            };

            return View(model);
        }
    }
}