using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace OrderSystem
{
    public class OrderService
    {
       
        public List<Order> getAllOrder()
        {
            using(var db=new OrderContext())
            {
                return db.Orders.ToList();
            }
        }

        public void add(Order order)
        {
            try
            {
                using(var db=new OrderContext())
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
            }
            catch(Exception e)
            {
                throw new ApplicationException($"添加错误: {e.Message}");
            }
        }

        public void remove(int id)    //根据订单编号id来删改查   remove change中存在异常
        {
            try
            {
                using(var db=new OrderContext())
                {
                    var order = db.Orders.Include("orderDetails").FirstOrDefault(o => o.OrderID == id);
                    if (order != null)
                    {
                        db.Orders.Remove(order);
                        db.SaveChanges();
                    }
                }
            }
            catch(Exception e)
            {
                throw new ApplicationException($"添加错误: {e.Message}");
            }
        }
        

        public void changeClient(int id, string cname)  //只改用户名
        {
            try
            {
               using(var db=new OrderContext())
                {
                    var order = db.Orders.FirstOrDefault(o => o.OrderID == id);
                    if (order != null)
                    {
                        order.ClientName = cname;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException($"添加错误: {e.Message}");
            }
        }
        public void changeDetails(int id,string gname, double gprice,int num)  //修改明细
        {
            try
            {
                using (var db = new OrderContext())
                {
                    var detail = db.OrderDetails.FirstOrDefault(d => d.GoodsName==gname&&d.OrderID==id);
                    if (detail != null)
                    {
                        detail.GoodsPrice = gprice;
                        detail.Number = num;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException($"添加错误: {e.Message}");
            }
        }
        public Order find(int id)
        {
            using(var db=new OrderContext())
            {
                var order = db.Orders.SingleOrDefault(o => o.OrderID == id);
                if (order != null)
                {
                    return order;
                }
                else
                {
                    throw new Exception("订单不存在！");
                }
            }
        }

        public void sort()    //默认排序（id）
        {
            using(var db=new OrderContext())
            {
                db.Orders.OrderBy(o => o.OrderID);
            }
        }

        public void Export()   //序列化为XML文件
        {
            Console.WriteLine("XML文件：");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
            using (FileStream fs = new FileStream("order.xml", FileMode.Create))
            {
                using (var db = new OrderContext())
                {
                    xmlSerializer.Serialize(fs, db.Orders.ToArray());
                }
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