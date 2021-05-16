using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OrderSystem
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }  //主键

       
        public Client Client { get; set; }  //客户
        public int ClientID { get => Client.ClientID; set { Client.ClientID = value; } }
        

        public List<OrderDetails> OrderDetails { get; set; }  //订单明细


        public string ClientName
        {
            get => Client.ClientName;
            set { Client.ClientName = value; }
        }

        public double Sum
        {
            get
            {
                double sum = 0;
                if (OrderDetails != null)
                {
                    foreach (OrderDetails details in OrderDetails)
                    {
                        sum += details.Goods.GoodsPrice * details.Number;
                    }
                    return sum;
                }
                else
                    return sum;
            }
            set { }
        }
        
        public Order() {
            Client = new Client();
        }
        public Order(int _id, Client _client)
        {
            OrderID = _id;
            Client = _client;
            OrderDetails = new List<OrderDetails>();
        }
        public bool isDetailsRepeat(List<OrderDetails> _orderDetails)
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < _orderDetails.Count; i++)
            {
                if (ht.Contains(_orderDetails[i].GoodsName))
                    return true;
                else
                {
                    ht.Add(_orderDetails[i].GoodsName, _orderDetails[i].GoodsName);
                }
            }
            return false;
        }
        
        public void addDetail(OrderDetails detail)
        {
            if (!OrderDetails.Contains(detail))
            {
                OrderDetails.Add(detail);
            }
        }

        public void removeDetail(OrderDetails detail)
        {
            OrderDetails.Remove(detail);
        }

        public override string ToString()
        {
            StringBuilder list = new StringBuilder();
            foreach (OrderDetails details in OrderDetails)
            {
                list.Append(details.ToString());
            }
            return "订单编号：" + OrderID + ",客户信息：" + Client.ToString() + ",订单明细：" + list.ToString() + ",订单总金额：" + Sum;
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   OrderID == order.OrderID;
        }

        public override int GetHashCode()
        {
            return 1213502048 + OrderID.GetHashCode();
        }
    }
}

