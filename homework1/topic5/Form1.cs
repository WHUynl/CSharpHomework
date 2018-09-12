using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace topic5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a;
            double b;
            double c;
            string A = textBox1.Text;
            string B = textBox2.Text;
            a = double.Parse(A);
            b = double.Parse(B);
            c = a * b;
            label3.Text = "" + c;
        }
    }
}
