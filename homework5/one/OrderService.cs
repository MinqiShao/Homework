using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OrderSpace;
using OrderDetailsSpace;
//订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。
//使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
//OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。
//在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
namespace OrderServiceSpace
{
    class OrderService
    {
        private List<Order> list=new List<Order>();
        public List<Order> List
        {
            get => list;
        }
        
        //增删改查
        public void add(Order order)
        {
            //检查是否与list中的order有重复
            foreach(Order m in list)
            {
                if (m.Equals(order))
                    throw new Exception("订单重复，添加失败");
            }
            list.Add(order);
        }
        public void remove(int id)    //根据订单编号id来删改查   remove change中存在异常
        {
            try
            {
                var query = list.Where(s => s.ID == id);
                list.Remove(query.FirstOrDefault());
            }
            catch(Exception e)
            {
                throw new Exception(id + "是错误的订单编号！");
            }
        }
        public void change(params object[] info)    //要修改的编号+修改的信息：客户名，订单明细中的商品数量
        {
            try
            {
                var query = list.Where(s => s.ID == Convert.ToInt32(info[0]));
                Order order = query.FirstOrDefault();
                int length = info.Length;
                if (length == 2&&info[1] is string)  //只修改用户名
                {
                    order.Client.ClientName = Convert.ToString(info[1]);
                }
                if (length == 3)    //只改商品数量 （根据商品名）
                {
                    //在该order中找到该明细
                    OrderDetails detail = order.Details.Where(s => s.Goods.GoodsName == Convert.ToString(info[1])).FirstOrDefault();
                    detail.Number = Convert.ToInt32(info[2]);
                }
                if (length == 4)   //同时改用户名和商品数量
                {
                    order.Client.ClientName = Convert.ToString(info[1]);
                    OrderDetails detail = order.Details.Where(s => s.Goods.GoodsName == Convert.ToString(info[2])).FirstOrDefault();
                    detail.Number = Convert.ToInt32(info[3]);
                }
            }
            catch(Exception e)
            {
                throw new Exception("订单不存在，修改失败！");
            }
        }
        public Order find(int id)
        {
            var query = list.Where(s => s.ID == id);
            return query.FirstOrDefault();
        }

        public void sort()    //默认排序（id）
        {
            list.Sort((p1, p2) => p1.ID - p2.ID);
        }

        
    }
}
