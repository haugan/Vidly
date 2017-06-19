using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
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

        private Customer GetSingleFromDB(int id)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == id);
        }

        // GET: api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET: api/customers/777
        public Customer GetCustomer(int id)
        {
            var customer = GetSingleFromDB(id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        // POST: api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        // PUT: api/customers/777
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var dbCustomer = GetSingleFromDB(id);

            if (dbCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // CONSIDER USING AUTO-MAPPER
            dbCustomer.Firstname = customer.Firstname;
            dbCustomer.Lastname = customer.Lastname;
            dbCustomer.BirthDate = customer.BirthDate;
            dbCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            dbCustomer.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        // DELETE: api/customers/777
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var dbCustomer = GetSingleFromDB(id);

            if (dbCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(dbCustomer);
            _context.SaveChanges();
        }
    }
}
