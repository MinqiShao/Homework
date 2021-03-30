using System;
using System.Collections.Generic;
using System.Text;

namespace GoodsSpace
{
    class Goods
    {
        public string GoodsName { get; set; }
        public double GoodsPrice { get; set; }
        public Goods(string name,double price)
        {
            GoodsName = name;
            GoodsPrice = price;
        }
        public override string ToString()
        {
            return "商品名称为："+GoodsName+",价格为："+GoodsPrice;
        }
    }
}
