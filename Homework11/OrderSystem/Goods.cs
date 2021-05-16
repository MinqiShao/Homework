using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrderSystem
{
    
        public class Goods
        {
            [Key]
            public string GoodsName { get; set; }
            public double GoodsPrice { get; set; }
            public Goods() { }
            public Goods(string name, double price)
            {
                GoodsName = name;
                GoodsPrice = price;
            }
            public override string ToString()
            {
                return "商品名称为：" + GoodsName + ",价格为：" + GoodsPrice;
            }
        }
    
}
