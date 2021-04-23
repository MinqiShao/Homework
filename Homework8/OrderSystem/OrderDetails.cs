using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsSpace;

namespace OrderDetailsSpace
{
    public class OrderDetails
    {
        private Goods goods=new Goods();
        private int number;

        /*public Goods Goods
        {
            get => goods;
            set { goods = value; }
        }*/
        public string GoodsName
        {
            get => goods.GoodsName;
            set { goods.GoodsName = value; }
        }

        public double GoodsPrice
        {
            get => goods.GoodsPrice;
            set { goods.GoodsPrice = value; }
        }
        public int Number
        {
            get => number;
            set { number = value; }
        }

        public OrderDetails() { }
        public OrderDetails(Goods _goods, int num)
        {
            goods = _goods;
            number = num;
        }

        

        public override string ToString()
        {
            return "商品名称为" + goods.GoodsName + ",价格为" + goods.GoodsPrice + ",数量为" + number + "。";
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   GoodsName == details.GoodsName &&
                   GoodsPrice == details.GoodsPrice;
        }

        public override int GetHashCode()
        {
            int hashCode = 1438261328;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodsName);
            hashCode = hashCode * -1521134295 + GoodsPrice.GetHashCode();
            return hashCode;
        }
    }
}
