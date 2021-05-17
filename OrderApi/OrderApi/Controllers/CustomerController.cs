using Microsoft.AspNetCore.Mvc;
using OrderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly OrderContext orderDb;

        public CustomerController(OrderContext context)
        {
            this.orderDb = context;
        }

        // GET: api/customer
        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers()
        {
            var query=orderDb.Customers.ToList();
            return query;
        }

        // GET api/customer/5
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(string id)
        {
            var customer = orderDb.Customers.FirstOrDefault(c=>c.CustomerId==id);
            if (customer == null)
                return NotFound();
            return customer;
        }

        // POST api/customer
        [HttpPost]
        public ActionResult<Customer> PostCustomer(Customer customer)
        {
            try
            {
                orderDb.Customers.Add(customer);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return customer;
        }

        // PUT api/customer/5
        [HttpPut("{id}")]
        public ActionResult<Customer> PutCustomer(string id,Customer customer)
        {
            if (customer.CustomerId != id)
                return BadRequest("Id is wrong!");
            try
            {
                orderDb.Entry(customer).State = EntityState.Modified;
                orderDb.SaveChanges();
            }
            catch(Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(string id)
        {
            try
            {
                var customer = orderDb.Customers.FirstOrDefault(o => o.CustomerId == id);
                if (customer != null)
                {
                    orderDb.Customers.Remove(customer);
                    orderDb.SaveChanges();
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }
    }
}
