using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = 0, b = 0;
            if (comboBox1.Text == "+")
            {
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                textBox3.Text = Convert.ToString(a + b);
            }
            else if (comboBox1.Text == "-")
            {
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                textBox3.Text = Convert.ToString(a - b);
            }
            else if (comboBox1.Text == "*")
            {
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                textBox3.Text = Convert.ToString(a * b);
            }
            else if (comboBox1.Text == "/")
            {
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                textBox3.Text = Convert.ToString(a / b);
            }
        }
    }
}
