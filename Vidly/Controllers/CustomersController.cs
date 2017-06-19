using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

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
            var dbCustomers = _context.Customers
                .Include(c => c.MembershipType)
                .ToList();

            var model = new CustomersIndexViewModel
            {
                Customers = dbCustomers
            };

            return View(model);
        }

        // GET: Customers/Details/777
        public ActionResult Details(int id)
        {
            var dbCustomer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (dbCustomer == null)
                return HttpNotFound();

            var model = new CustomerDetailsViewModel
            {
                Firstname = dbCustomer.Firstname,
                Lastname = dbCustomer.Lastname,
                BirthDate = dbCustomer.BirthDate,
                MembershipType = dbCustomer.MembershipType
            };

            return View(model);
        }

        // GET: Customers/Edit/777
        public ActionResult Edit(int id)
        {
            var dbCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (dbCustomer == null)
                return HttpNotFound($"Could not find customer with id {id} in database.");

            var model = new CustomerFormViewModel()
            {
                Customer = dbCustomer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("Form", model);
        }

        // GET: Customers/New
        public ActionResult New()
        {
            var dbMembershipTypes = _context.MembershipTypes.ToList();
            var model = new CustomerFormViewModel
            {
                Customer = new Customer(), // Removes implicit CustomerId validation in form (initializes default model values)
                MembershipTypes = dbMembershipTypes,
            };

            return View("Form", model);
        }

        // POST: Customers/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer) // Model binding 
        {
            // VALIDATION OK
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("Form", viewModel);
            }

            // ID DEFAULTS TO 0 AND INHERENTLY REQUIRED (FIX)
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var dbCustomer = _context.Customers.Single(c => c.Id == customer.Id);
                dbCustomer.Firstname = customer.Firstname;
                dbCustomer.Lastname = customer.Lastname;
                dbCustomer.BirthDate = customer.BirthDate;
                dbCustomer.MembershipTypeId = customer.MembershipTypeId;
                dbCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            
            // SAVE TO DB AND RETURN
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}