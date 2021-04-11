using System;
using System.Collections.Generic;
using System.Text;
using GoodsSpace;

namespace OrderDetailsSpace
{
    public class OrderDetails
    {
        private Goods goods;
        private int number;

        public Goods Goods
        {
            get => goods;
            set { goods = value; }
        }
        public int Number
        {
            get => number;
            set { number = value; }
        }

        public OrderDetails() { }
        public OrderDetails(Goods _goods,int num)
        {
            goods = _goods;
            number = num;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   EqualityComparer<Goods>.Default.Equals(goods, details.goods) &&
                   number == details.number;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(goods, number);
        }

        public override string ToString()
        {
            return "商品名称为" + goods.GoodsName + ",价格为" + goods.GoodsPrice + ",数量为" + number+"。";
        }
        
    }
}
