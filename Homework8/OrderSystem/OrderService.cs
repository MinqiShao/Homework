using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OrderSpace;
using OrderDetailsSpace;
using System.Xml.Serialization;
using System.IO;

namespace OrderServiceSpace
{
    public class OrderService
    {
        private List<Order> list = new List<Order>();
        public List<Order> List
        {
            get => list;
        }

        //增删改查
        public void add(Order order)
        {
            //检查是否与list中的order有重复
            foreach (Order m in list)
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
            catch (Exception e)
            {
                throw new Exception(id + "是错误的订单编号！");
            }
        }
        /*public void change(params object[] info)    //要修改的编号+修改的信息：客户名，订单明细中的商品数量
        {
            try
            {
                var query = list.Where(s => s.ID == Convert.ToInt32(info[0]));
                Order order = query.FirstOrDefault();
                int length = info.Length;
                if (length == 2&&info[1] is string&&!(info[1] is int))  //只修改用户名
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
        }*/

        public void changeClient(int id, string cname)  //只改用户名
        {
            try
            {
                var query = list.Where(s => s.ID == id);
                Order order = query.FirstOrDefault();
                order.ClientName = cname;
            }
            catch (Exception e)
            {
                throw new Exception("订单不存在，修改失败！");
            }
        }
        public void changeDetails(int id, string gname, int num)  //修改明细
        {
            try
            {
                var query = list.Where(s => s.ID == id);
                Order order = query.FirstOrDefault();
                OrderDetails detail = order.Details.Where(s => s.GoodsName == gname).FirstOrDefault();
                detail.Number = num;
            }
            catch (Exception e)
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

        public void Export()   //序列化为XML文件
        {
            Console.WriteLine("XML文件：");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
            using (FileStream fs = new FileStream("order.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, list.ToArray());
            }
            Console.WriteLine(File.ReadAllText("order.xml"));
        }

        public List<Order> Import()   //反序列化，从XML载入订单
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("order.xml", FileMode.Open))
            {
                List<Order> _list = (List<Order>)xmlSerializer.Deserialize(fs);
                Console.WriteLine("由XML反序列化得到：");
                _list.ForEach(p => Console.WriteLine(p));
                return _list;
            }
        }
    }
}