using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace topic2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (graphics == null) graphics = this.CreateGraphics();
            output();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);

        }
        private Graphics graphics;

        double th1;
        double th2;
        double per1;
        double per2;
        double k;
        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double x2 = x0 + leng * k * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double y2 = y0 + leng * k * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            try
            {
                graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
            }
            catch (Exception e) { Console.WriteLine("input error: " + e.Message); }
        }
        void output()
        {
            try
            {
                string a = textBox1.Text;
                string b = textBox2.Text;
                string c = textBox3.Text;
                string d = textBox4.Text;
                string e = textBox5.Text;

                double A = double.Parse(a);
                double B = double.Parse(b);
                double C = double.Parse(c);
                double D = double.Parse(d);
                double E = double.Parse(e);

                k = E;
                th1 = A * Math.PI / 180;
                th2 = B * Math.PI / 180;
                per1 = C;
                per2 = D;
            }
            catch (Exception e) { Console.WriteLine("input error: " + e.Message); }
        }


    }
}
