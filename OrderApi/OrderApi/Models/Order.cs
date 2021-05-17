using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderApi.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public string CustomerName { get => Customer != null ? Customer.CustomerName : ""; }
        public DateTime CreateTime { get; set; }

        public List<OrderDetails> Details { get; set; }

        public double TotalPrice { get => Details != null ? Details.Sum(details => details.TotalPrice) : 0.0; }
        public Order()
        {
            OrderId = Guid.NewGuid().ToString();
            Details = new List<OrderDetails>();
            CreateTime = DateTime.Now;
        }

        public Order(Customer customer) : this()
        {
            Customer = customer;
        }

        public void addDetails(OrderDetails orderDetails)
        {
            if(Details.Contains(orderDetails))
                throw new ApplicationException($"添加错误：订单项已经存在!");
            Details.Add(orderDetails);
        }

        public void removeDetails(OrderDetails orderDetails)
        {
            Details.Remove(orderDetails);
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"Id:{OrderId}, customer:{Customer},orderTime:{CreateTime},totalPrice：{TotalPrice}");
            Details.ForEach(od => strBuilder.Append("\n\t" + od));
            return strBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   OrderId == order.OrderId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderId);
        }
    }
}
