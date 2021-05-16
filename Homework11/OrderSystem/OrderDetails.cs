using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderSystem
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsID { get; set; }

        
        
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
        public int OrderID { get; set; }
       

       
        public  Goods Goods { get; set; }
        public string GoodsName { get=>Goods.GoodsName; set { Goods.GoodsName= value; } }
        
        public double GoodsPrice { get => Goods.GoodsPrice; set { Goods.GoodsPrice = value; } }
        public int Number { get; set; }
        

        public OrderDetails() {
            Goods = new Goods();
        }
        public OrderDetails(int id1,Goods _goods, int num)
        {
            OrderDetailsID = id1;
            Goods = _goods;
            Number = num;
        }

        

        public override string ToString()
        {
            return "商品名称为" + Goods.GoodsName + ",价格为" + Goods.GoodsPrice + ",数量为" + Number + "。";
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   OrderDetailsID == details.OrderDetailsID;
        }

        public override int GetHashCode()
        {
            return -821602366 + OrderDetailsID.GetHashCode();
        }
    }
}
