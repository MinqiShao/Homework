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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public OrderDetails newOrderDetails=new OrderDetails();
        public Order newOrder = new Order();
        public Form1 form1;
        int flag = 0;

        public string Id { get; set; }
        public string Clientname{ get; set; }

        public Form2(int id,Form1 _form1)    //修改订单
        {
            InitializeComponent();
            form1 = _form1;
            orderSource.DataSource = form1.service.List[id-1];
            itemSource.DataSource = orderSource;
            itemSource.DataMember = "Details";
            newOrder= form1.service.List[id - 1]; 
            Id = Convert.ToString(form1.service.List[id - 1].ID);
            Clientname = form1.service.List[id - 1].ClientName;
            IDBox.DataBindings.Add("Text", this, "Id");
            ClientBox.DataBindings.Add("Text", this, "Clientname");
           
        }
        public Form2(Form1 _form1)    //添加新订单
        {
            InitializeComponent();
            form1 = _form1;
            flag = 1;
            IDBox.ReadOnly = false;
            IDBox.DataBindings.Add("Text", newOrder, "ID");
            ClientBox.DataBindings.Add("Text", newOrder, "ClientName");
            newOrder.Details =new List<OrderDetails>();
            
            //form1.service.List.Add(newOrder);

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (!form1.service.List.Contains(newOrder))
            {
                form1.service.List.Add(newOrder);
            }
            else
            {
                MessageBox.Show("订单重复！");
                this.Close();
            }
            form1.orderBingSource.DataSource = form1.service.List;
            form1.itemBindingSource.DataSource = form1.orderBingSource;
            form1.itemBindingSource.DataMember = "Details";
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
