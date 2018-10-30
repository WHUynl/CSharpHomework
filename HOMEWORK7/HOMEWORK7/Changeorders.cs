using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOMEWORK7
{
    public partial class Changeorders : Form
    {
        private   OrderService one=null;
        public Changeorders(OrderService one)
        {
            InitializeComponent();
            this.one = one;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(textBox1.Text);
                if (radioButton1.Checked == true)
                {
                    one.changeOrdername(a, textBox2.Text);
                }
                else if (radioButton2.Checked == true)
                {
                    double b = double.Parse(textBox2.Text);
                    one.changeOrderamount(a, b);
                }
                else if (radioButton3.Checked == true)
                {
                    double b = double.Parse(textBox2.Text);
                    one.changeOrderprice(a, b);
                }
                else if (radioButton4.Checked == true)
                {
                    one.changeOrdername(a, textBox2.Text);
                }
                else
                {
                    one.changeOrdernumber(a, textBox2.Text);
                }
                Dispose();
            }
            catch (Exception z)
            {
                if (MessageBox.Show(z.Message, "错误") == DialogResult.Yes) { }
            }
        }
    }
}
