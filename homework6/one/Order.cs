using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClientSpace;
using OrderDetailsSpace;

namespace OrderSpace
{
    public class Order
    {
        //private int id;      //编号
        //private Client client;  //客户
        private OrderDetails[] orderDetails;  //订单明细

        public int ID { get; set; }  //编号
        
        public Client Client { get; set; }  //客户
        
        public double Sum
        {
            get
            {
                double sum = 0;
                foreach (OrderDetails details in orderDetails)
                {
                    sum += details.Goods.GoodsPrice * details.Number;
                }
                return sum;
            }
        }
        public OrderDetails[] Details
        {
            get => orderDetails;
            set { orderDetails = value; }
        }
        public Order() { }
        public Order(int _id,Client _client,OrderDetails[] _orderDetails)
        {
            ID = _id;
            Client = _client;
            if(!isDetailsRepeat(_orderDetails))
                orderDetails = _orderDetails;
            else
                throw new Exception("编号为"+ID+"的订单中明细重复！");
        }
        public bool isDetailsRepeat(OrderDetails[] _orderDetails)
        {
            Hashtable ht = new Hashtable();
            for(int i = 0; i < _orderDetails.Length; i++)
            {
                if (ht.Contains(_orderDetails[i].Goods.GoodsName))
                    return true;
                else
                {
                    ht.Add(_orderDetails[i].Goods.GoodsName, _orderDetails[i].Goods.GoodsName);
                }
            }
            return false;
        }
        /*public void getSum()
        {
            foreach (OrderDetails details in orderDetails)
            {
                sum += details.Goods.GoodsPrice * details.Number;
            }
        }*/
       
        public override string ToString()
        {
            StringBuilder list = new StringBuilder();
            foreach(OrderDetails details in orderDetails)
            {
                list.Append(details.ToString());
            }
            return "订单编号：" + ID + ",客户信息：" + Client.ToString() + ",订单明细：" + list.ToString()+",订单总金额："+Sum;
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   EqualityComparer<OrderDetails[]>.Default.Equals(orderDetails, order.orderDetails) &&
                   ID == order.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(orderDetails, ID);
        }
    }
}
