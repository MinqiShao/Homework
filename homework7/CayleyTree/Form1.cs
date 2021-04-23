using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//添加一组控件用以调节树的绘制参数。参数包括递归深度（n）、主干长度（leng）、右分支长度比（per1）、
//左分支长度比（per2）、右分支角度（th1）、左分支角度（th2）、画笔颜色（pen）。

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*private void Form1_Load(object sender, EventArgs e)
        {
            this.trackBar1.SetRange(1, 15);

            this.trackBar2.SetRange(1, 150);

            this.trackBar3.SetRange(0, 1);

            this.trackBar4.SetRange(0, 1);

            this.trackBar5.SetRange(1, (int)Math.PI);

            this.trackBar6.SetRange(1, (int)Math.PI);
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = panel3.CreateGraphics();

            n = Convert.ToInt32(numBox.Text);
            length = Convert.ToInt32(lengBox.Text);

            drawCayleyTree(n, panel3.Width/2, panel3.Height, length, -Math.PI / 2);
        }
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        int n;
        int length;
        Pen pen;
       
        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            per1 = Convert.ToDouble(per1Box.Text);
            per2 = Convert.ToDouble(per2Box.Text);
            th1= Convert.ToDouble(th1Box.Text);
            th2= Convert.ToDouble(th2Box.Text);

            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th -th2);
        }

        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pen[] pens = { Pens.Blue, Pens.Black, Pens.Pink, Pens.Yellow, Pens.Green };
            pen = pens[comboBox1.SelectedIndex];
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numBox.Text = Convert.ToString(trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            lengBox.Text = Convert.ToString(trackBar2.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            double m = (double)trackBar3.Value;
            per1Box.Text = Convert.ToString(m/100);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            double m = (double)trackBar4.Value;
            per2Box.Text = Convert.ToString(m / 100);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            double m = (double)trackBar5.Value;
            th1Box.Text = Convert.ToString(m / 100);
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            double m = (double)trackBar6.Value;
            th2Box.Text = Convert.ToString(m / 100);
        }
    }
}
