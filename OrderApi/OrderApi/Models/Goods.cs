using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrderApi.Models
{
    public class Goods
    {
        public string GoodsId { get; set; }
        public string GoodsName { get; set; }
        public double GoodsPrice { get; set; }

        public Goods() {
            GoodsId = Guid.NewGuid().ToString();
        }
        public Goods(string name,double price):this()
        {
            GoodsName = name;
            GoodsPrice = price;
        }

        public override bool Equals(object obj)
        {
            return obj is Goods goods &&
                   GoodsId == goods.GoodsId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GoodsId);
        }
    }

}
