using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _db;

        public CustomersController()
        {
            _db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        // GET: api/customers
        public IHttpActionResult GetAllCustomers()
        {
            // EAGER LOAD HIERARCHICAL TYPE ("INCLUDE") FOR DATATABLE CONSUMPTION THROUGH WEB API
            var dtos = _db.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(dtos);
        }

        // GET: api/customers/123
        public IHttpActionResult GetSingleCustomer(int id)
        {
            var dbCustomer = _db.Customers.SingleOrDefault(c => c.Id == id);

            if (dbCustomer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(dbCustomer));
        }

        // POST: api/customers
        [HttpPost]
        [Authorize(Roles = RoleName.CustomerManager)]
        public IHttpActionResult CreateCustomer(CustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // AUTOMAP: <SourceType, DestinationType>(SourceObject)
            var customer = Mapper.Map<CustomerDto, Customer>(dto);

            _db.Customers.Add(customer);
            _db.SaveChanges();

            // GET CUSTOMER ID CREATED BY DATABASE & ASSIGN TO DTO
            dto.Id = customer.Id;

            // RETURN URI OF NEWLY CREATED OBJECT (HttpActionResult)
            return Created(
                new Uri($"{Request.RequestUri}/{customer.Id}"), // URI
                dto); // Object
        }

        // PUT: api/customers/123
        [HttpPut]
        [Authorize(Roles = RoleName.CustomerManager)]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
           
            var dbCustomer = _db.Customers.SingleOrDefault(c => c.Id == id);

            if (dbCustomer == null)
                return NotFound();

            // AUTOMAP: (SourceObject, DestinationObject)
            Mapper.Map(dto, dbCustomer);

            _db.SaveChanges();
            return Ok();
        }

        // DELETE: api/customers/123
        [HttpDelete]
        [Authorize(Roles = RoleName.CustomerManager)]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var dbCustomer = _db.Customers.SingleOrDefault(c => c.Id == id);

            if (dbCustomer == null)
                return NotFound();

            _db.Customers.Remove(dbCustomer);
            _db.SaveChanges();
            return Ok();
        }
    }
}
