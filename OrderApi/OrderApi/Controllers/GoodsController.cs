using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderApi.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly OrderContext orderDb;

        public GoodsController(OrderContext context)
        {
            this.orderDb = context;
        }
        // GET: api/goods
        [HttpGet]
        public ActionResult<List<Goods>> GetGoodslist()
        {
            var query=orderDb.Goods.ToList();
            return query;
        }

        // GET api/goods/5
        [HttpGet("{id}")]
        public ActionResult<Goods> GetGoods(string id)
        {
            var goods = orderDb.Goods.FirstOrDefault(c=>c.GoodsId==id);
            if (goods == null)
                return NotFound();
            return goods;
        }

        // POST api/goods
        [HttpPost]
        public ActionResult<Goods> PostGoods(Goods goods)
        {
            try
            {
                orderDb.Goods.Add(goods);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return goods;
        }

        // PUT api/goods/5
        [HttpPut("{id}")]
        public ActionResult<Goods> PutGoods(string id,Goods goods)
        {
            if (goods.GoodsId != id)
                return BadRequest("Id is wrong!");
            try
            {
                orderDb.Entry(goods).State = EntityState.Modified;
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

        // DELETE api/goods/5
        [HttpDelete("{id}")]
        public ActionResult DeleteGoods(string id)
        {
            try
            {
                var goods = orderDb.Goods.FirstOrDefault(o => o.GoodsId == id);
                if (goods != null)
                {
                    orderDb.Goods.Remove(goods);
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
