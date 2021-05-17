using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Models
{
    public class OrderDetails
    {
        public string OrderDetailsId { get; set; }

        public int Index { get; set; }
        public string GoodsId { get; set; }
        [ForeignKey("GoodsId")]
        public Goods Goods { get; set; }
        public string GoodsName { get => Goods != null ? this.Goods.GoodsName : ""; }
        public double GoodsPrice { get=> Goods != null ? this.Goods.GoodsPrice : 0.0; }

        public string OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public int Number { get; set; }

        public double TotalPrice
        {
            get => Goods == null ? 0.0 : Goods.GoodsPrice * Number;
        }
        public OrderDetails()
        {
            OrderDetailsId = Guid.NewGuid().ToString();
        }

        public OrderDetails(int index,Goods goods,int num) : this()
        {
            Index = index;
            Goods = goods;
            Number = num;
        }

        public override string ToString()
        {
            return $"[No.{Index},goods:{GoodsName},number:{Number},totalprice:{TotalPrice}]";
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   OrderDetailsId == details.OrderDetailsId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderDetailsId);
        }
    }
}
