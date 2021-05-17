using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext orderDb;

        public OrderController(OrderContext context)
        {
            this.orderDb = context;
        }

    
        // GET: api/order/cname=xxx
        [HttpGet]
        public ActionResult<List<Order>> GetOrders(string cname)
        {
            var query = orderDb.Orders.Include("Customer").Where(o => true);
            if (cname != null)
                query = query.Where(o => o.Customer.CustomerName == cname);
            return query.ToList();
        }

        // GET api/order/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
            var order = orderDb.Orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
                return NotFound();
            return order;
        }

        // POST api/order
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        // PUT api/order/5
        [HttpPut("{id}")]
        public ActionResult<Order> PutOrder(string id, Order order)
        {
            if (order.OrderId != id)
                return BadRequest("Id is wrong!");
            try
            {
                orderDb.Entry(order).State = EntityState.Modified;
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

        // DELETE api/order/5
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(string id)
        {
            try
            {
                var order = orderDb.Orders.FirstOrDefault(o => o.OrderId == id);
                if (order != null)
                {
                    orderDb.Orders.Remove(order);
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
