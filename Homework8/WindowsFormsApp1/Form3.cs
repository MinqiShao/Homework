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
            if (flag == 1)  //添加明细
            {
                form2.newOrder.Details.Add(form2.newOrderDetails);
            }
            else if(flag == 2){   //修改明细
                OrderDetails details = form2.newOrder.Details.Where(_details => _details.GoodsName==form2.newOrderDetails.GoodsName).FirstOrDefault();
                form2.newOrder.Details.Remove(details);
                form2.newOrder.Details.Add(form2.newOrderDetails);
            }
            else if(flag==3){   //删除明细
                OrderDetails details = form2.newOrder.Details.Where(_details => _details.GoodsName == RemoveName).FirstOrDefault();
                form2.newOrder.Details.Remove(details);
            }

            form2.orderSource.DataSource = form2.form1.service.List[form2.newOrder.ID-1];
            form2.itemSource.DataSource = form2.orderSource;
            form2.itemSource.DataMember = "Details";
            this.Close();
        }
    }
}
