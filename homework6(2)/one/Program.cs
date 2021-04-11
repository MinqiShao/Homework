using System;
using GoodsSpace;
using ClientSpace;
using OrderDetailsSpace;
using OrderSpace;
using OrderServiceSpace;
/*写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户、订单金额等进行查询）功能。

提示：主要的类有Order（订单）、OrderDetails（订单明细），OrderService（订单服务），订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。

要求：
（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
（5） OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。*/


namespace one
{
    class Program
    {
        static void Main(string[] args)
        {
            //商品
            Goods g1 = new Goods("衬衫", 99.9);
            Goods g2 = new Goods("牛仔裤", 119.9);
            Goods g3 = new Goods("袜子", 9.9);

            //客户
            Client c1 = new Client("Mary");
            Client c2 = new Client("Jack");
            Client c3 = new Client("Mike");

            //订单明细
            OrderDetails d1 = new OrderDetails(g1, 1);
            OrderDetails d2 = new OrderDetails(g2, 2);
            OrderDetails d3 = new OrderDetails(g3, 1);
            OrderDetails[] details1 = { d1, d2 };
            OrderDetails[] details2 = { d2, d3 };
            OrderDetails[] details3 = { d1, d3 };

            //订单
            Order order1 = new Order(1, c1, details1);
            Order order2 = new Order(2, c2, details2);
            Order order3 = new Order(3, c3, details3);


            //管理订单
            OrderService service = new OrderService();
            service.add(order1);
            service.add(order2);
            service.add(order3);

            //序列化xml
            service.Export();
            service.Import();

            //排序
            Console.WriteLine("默认按照编号ID排序：");
            service.sort();
            foreach(Order m in service.List)
            {
                Console.WriteLine(m.ToString());
            }
            Console.WriteLine();
            //自定义排序
            Console.WriteLine("按照金额排序：");
            service.List.Sort((x, y) => y.Sum.CompareTo(x.Sum));
            foreach (Order m in service.List)
            {
                Console.WriteLine(m.ToString());
            }

            //查询
            Console.WriteLine("输入查询的订单编号：");
            int id = Convert.ToInt32(Console.ReadLine());
            Order order=service.find(id);
            Console.WriteLine(order.ToString());

            //删除
            Console.WriteLine("输入删除的订单编号：");
            id = Convert.ToInt32(Console.ReadLine());
            service.remove(id);
            foreach (Order m in service.List)
            {
                Console.WriteLine(m.ToString());
            }

            //修改
            Console.WriteLine("输入想修改的订单编号及订单明细：[编号 商品名 新数量]");
            object[] info = Console.ReadLine().Split(" ");
            service.changeDetails((int)info[0], (string)info[1], (int)info[2]);
            Console.WriteLine("输入想修改的编号及新用户名：[编号 新用户名]");
            info = Console.ReadLine().Split(" ");
            service.changeClient((int)info[0], (string)info[1]);

            foreach (Order m in service.List)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
}
