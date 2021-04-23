using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoodsSpace;
using ClientSpace;
using OrderDetailsSpace;
using OrderSpace;
using OrderServiceSpace;
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

        public OrderDetails details1;
        public OrderDetails details2;
        public OrderDetails details3;

        public Order order1;
        public Order order2;

        public OrderService service=new OrderService();
        public Form1()
        {
            InitializeComponent();
            pen = new Goods("pen", 9.9);
            book = new Goods("book", 5.9);
            paper = new Goods("paper", 0.9);
            c1 = new Client("张三");
            c2 = new Client("李四");
            details1 = new OrderDetails(pen, 1);
            details2 = new OrderDetails(book, 1);
            details3 = new OrderDetails(paper, 2);
            List<OrderDetails> orderDetails1 = new List<OrderDetails>();
            orderDetails1.Add(details1); orderDetails1.Add(details2);
            List<OrderDetails> orderDetails2 = new List<OrderDetails>();
            orderDetails2.Add(details2); orderDetails2.Add(details3);
            order1 = new Order(1, c1, orderDetails1);
            order2 = new Order(2, c2, orderDetails2);
            service.add(order1);
            service.add(order2);

            orderBingSource.DataSource = service.List;
            itemBindingSource.DataSource = orderBingSource;
            itemBindingSource.DataMember = "Details";

            queryBox.DataBindings.Add("Text", this, "KeyWord1");
            detailsBox.DataBindings.Add("Text", this, "KeyWord2");
            changeBox.DataBindings.Add("Text", this, "KeyWord3");
        }

        private void queryByID_Click(object sender, EventArgs e)
        {
            if (KeyWord1 == "" || KeyWord1 == null)
                orderBingSource.DataSource = service.List;
            else
                orderBingSource.DataSource = service.List.Where(order => order.ID == Convert.ToInt32(KeyWord1));
        }

        private void queryByClientName_Click(object sender, EventArgs e)
        {
            if (KeyWord1 == "" || KeyWord1 == null)
                orderBingSource.DataSource = service.List;
            else
                orderBingSource.DataSource = service.List.Where(order => order.ClientName==KeyWord1);
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
            using (FileStream fs = new FileStream("order.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, service.List.ToArray());
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("order.xml", FileMode.Open))
            {
                List<Order> _list = (List<Order>)xmlSerializer.Deserialize(fs);
                _list.ForEach(order =>
                {
                    if (!service.List.Contains(order))
                        service.List.Add(order);
                });
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            
                Form2 form2 = new Form2(Convert.ToInt32(KeyWord3),this);
                //form2.form1=this;
                form2.Show();
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            //form2.Owner = this;
            form2.Show();
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(KeyWord2);

            int flag = 0;
            service.List.ForEach(order =>
            {
                if (order.ID == i)
                    flag = 1;
            });
            if (flag == 0)
                throw new Exception("订单不存在！");

            itemBindingSource.DataSource = service.List[i - 1].Details;
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            orderBingSource.DataSource = service.List;
            itemBindingSource.DataSource = orderBingSource;
            itemBindingSource.DataMember = "Details";
        }
    }
}
