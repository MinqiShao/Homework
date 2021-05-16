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
    public partial class Form3 : Form
    {
        Form2 form2;
        public int flag = 1;
        public string RemoveName { get; set; }
        public string ChangeName { get; set; }
     

        public Form3(Form2 _form2,string str)    //增加明细  修改明细
        {
            InitializeComponent();
            form2 = _form2;


            nameBox.DataBindings.Add("Text", form2.newOrderDetails, "GoodsName");
            priceBox.DataBindings.Add("Text", form2.newOrderDetails, "GoodsPrice");
            numberBox.DataBindings.Add("Text", form2.newOrderDetails, "Number");
 
            
        }


        public Form3(Form2 _form2)  //删除明细
        {
            InitializeComponent();
            form2 = _form2;
            priceBox.Visible = false;
            numberBox.Visible = false;
            priceLabel.Visible = false;
            numberLabel.Visible = false;

            nameBox.DataBindings.Add("Text", this, "RemoveName");
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            using (var db = new OrderContext())
            {
                Order neworder = db.Orders.Include("OrderDetails").FirstOrDefault(o => o.OrderID == form2.newOrder.OrderID);
                if (flag == 1)  //添加明细
                {
                    form2.newOrderDetails.OrderDetailsID = db.OrderDetails.Count() + 1;
                    if (!form2.newOrder.OrderDetails.Contains(form2.newOrderDetails))
                    {
                        neworder.addDetail(form2.newOrderDetails);
                    }
                    else
                    {
                        MessageBox.Show("明细重复！");
                        this.Close();
                    }
                 }
            else if(flag == 2){   //修改明细
                    var details = db.OrderDetails.FirstOrDefault(d => d.OrderID == neworder.OrderID && d.GoodsName == form2.newOrderDetails.GoodsName);
                    neworder.removeDetail(details);
                    neworder.addDetail(form2.newOrderDetails);
            }
            else if(flag==3){   //删除明细
                    var details = db.OrderDetails.FirstOrDefault(d => d.OrderID == form2.newOrder.OrderID&&d.GoodsName==RemoveName );
                    //neworder.removeDetail(details);
                    db.OrderDetails.Remove(details);
                }
                

                form2.orderSource.DataSource = db.Orders.Include("OrderDetails").FirstOrDefault(o => o.OrderID == neworder.OrderID);
                form2.form1.orderBingSource.DataSource = db.Orders.Include("OrderDetails").ToList();
                form2.itemSource.DataSource = form2.orderSource;
                form2.itemSource.DataMember = "OrderDetails";
                form2.orderSource.ResetBindings(true);
                form2.itemSource.ResetBindings(true);
                db.SaveChanges();
            }
            this.Close();
        }
    }
}
