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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public OrderDetails newOrderDetails=new OrderDetails();
        public Order newOrder;
        public Form1 form1;
        int flag = 0;

        public Form2(int id,Form1 _form1)    //修改订单
        {
            InitializeComponent();
            form1 = _form1;
            flag = 0;

            using (var db = new OrderContext())
            {
                orderSource.DataSource = db.Orders.Include("OrderDetails").FirstOrDefault(o => o.OrderID == id);
                
                newOrder = db.Orders.Include("OrderDetails").FirstOrDefault(o => o.OrderID == id);
            }

            itemSource.DataSource = orderSource;
            itemSource.DataMember = "OrderDetails";

            IDBox.DataBindings.Add("Text", newOrder, "OrderID");
            ClientBox.DataBindings.Add("Text", newOrder, "ClientName");
           
        }
        public Form2(Form1 _form1)    //添加新订单
        {
            newOrder = new Order();
            InitializeComponent();
            form1 = _form1;
            flag = 1;
            IDBox.ReadOnly = false;
            IDBox.DataBindings.Add("Text", newOrder, "OrderID");
            ClientBox.DataBindings.Add("Text", newOrder, "ClientName");
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            using (var db = new OrderContext())
            {
                if (db.Orders.ToList().Contains(newOrder) && flag == 1)
                {
                    MessageBox.Show("订单重复！");
                    this.Close();
                }
                else if (flag == 1)
                {
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                }
            }
            //form1.refresh();
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this,"增加明细");
            form3.flag = 1;
            form3.Show();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this,"修改明细");
            form3.flag = 2;
            form3.Show();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this);
            form3.flag = 3;
            form3.Show();   
        }

    }
}
