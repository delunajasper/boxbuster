using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BoxBuster.Dtos;
using BoxBuster.Models;
using System.Data.Entity;

namespace BoxBuster.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _BbDbContext;

        public CustomersController()
        {
            _BbDbContext = new ApplicationDbContext();
        }
        //GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _BbDbContext.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);

        }

        //GET /api/single customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _BbDbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            //automap: <source, destination>(sourceobjct)
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _BbDbContext.Customers.Add(customer);
            _BbDbContext.SaveChanges();

            //get customer id created by DB and assign to customrDTo
            customerDto.Id = customer.Id;

            //return URI newly created object(httpactionresult)
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
           
        [HttpPut]
        [Authorize(Roles = "ManageDb")]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerDb = _BbDbContext.Customers.SingleOrDefault(c => c.Id == id);

            if(customerDb == null)
               return NotFound();

            //autompap:(sourceobjct, desctinationobjct)
            Mapper.Map(customerDto, customerDb);
            //customerDb.Name = customerDto.Name;
            //customerDb.DoB = customerDto.DoB;
            //customerDb.Subscription = customerDto.Subscription;
            //customerDb.MembershipTypeId = customerDto.MembershipTypeId;

            _BbDbContext.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        [Authorize(Roles = "ManageDb")]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerDb = _BbDbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
                return NotFound();

            _BbDbContext.Customers.Remove(customerDb);
            _BbDbContext.SaveChanges();

            return Ok();
        }
    }
}
