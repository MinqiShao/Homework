using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderSystem;
using System.Xml.Serialization;
using System.IO;

namespace WindowsFormsApp1
{ 
    public partial class Form1 : Form
    {
        public string KeyWord1 { get; set; }
        public string KeyWord2 { get; set; }
        public string KeyWord3 { get; set; }


        public Goods pen;
        public Goods book;
        public Goods paper;

        public Client c1;
        public Client c2;
        public Client c3;

        public OrderDetails details1;
        public OrderDetails details2;
        public OrderDetails details3;

        public Order order1;
        public Order order2;

        public OrderService orderService=new OrderService();
 
        public Form1()
        {
            InitializeComponent();

            pen = new Goods("pen", 9.9);
            book = new Goods("book", 5.9);
            paper = new Goods("paper", 0.9);


            c1 = new Client(1,"张三");
            c2 = new Client(2,"李四");
            c3 = new Client(3, "王五");


            order1 = new Order(1, c1);
            order2 = new Order(2, c2);

            details1 = new OrderDetails(1,pen, 2);
            details2 = new OrderDetails(2,book, 1);
            details3 = new OrderDetails(3,paper, 2);


            using (var db = new OrderContext())
            {
                db.Goods.Add(pen);
                db.Goods.Add(book);
                db.Goods.Add(paper);

                db.Clients.Add(c1);
                db.Clients.Add(c2);
                db.Clients.Add(c3);

                db.Orders.Add(order1);
                db.Orders.Add(order2);
                order1.addDetail(details1);
                order1.addDetail(details2);
                order2.addDetail(details3);

                db.SaveChanges();

                orderBingSource.DataSource = db.Orders.ToList();
                itemBindingSource.DataSource = orderBingSource;
                itemBindingSource.DataMember = "OrderDetails";
            }

        
            queryBox.DataBindings.Add("Text", this, "KeyWord1");
            detailsBox.DataBindings.Add("Text", this, "KeyWord2");
            changeBox.DataBindings.Add("Text", this, "KeyWord3");
        }

        private void queryByID_Click(object sender, EventArgs e)
        {
            using (var db = new OrderContext())
            {
                if (KeyWord1 == "" || KeyWord1 == null)
                    orderBingSource.DataSource = db.Orders.Include("Orderdetails").ToList();
                else
                {
                    int id = Convert.ToInt32(KeyWord1);
                    orderBingSource.DataSource = db.Orders.Include("Orderdetails").FirstOrDefault(o => o.OrderID == id);
                }
                    
            }
        }


        private void exportButton_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
            using (FileStream fs = new FileStream("order.xml", FileMode.Create))
            {
                using (var db = new OrderContext())
                {
                    xmlSerializer.Serialize(fs, db.Orders.Include("Orderdetails").ToArray());
                }
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("order.xml", FileMode.Open))
            {
                using (var db = new OrderContext())
                {
                    List<Order> _list = (List<Order>)xmlSerializer.Deserialize(fs);
                    _list.ForEach(order =>
                    {
                        if (!db.Orders.Include("Orderdetails").ToList().Contains(order))
                            db.Orders.Include("Orderdetails").ToList().Add(order);
                    });
                }
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (KeyWord3 != null && KeyWord3 != "")
            {
                Form2 form2 = new Form2(Convert.ToInt32(KeyWord3), this);
                form2.Show();
            }
            else
            {
                MessageBox.Show("输入要修改的订单编号！");
            }
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(KeyWord2);

            int flag = 0;
            using (var db = new OrderContext())
            {
                db.Orders.ToList().ForEach(order =>
                {
                    if (order.OrderID == i)
                        flag = 1;
                });

                
                if (flag == 0)
                    throw new Exception("订单不存在！");

                itemBindingSource.DataSource = db.OrderDetails.Where(d => d.OrderID == i).ToList();
            }
        }
    
       
    }
}
