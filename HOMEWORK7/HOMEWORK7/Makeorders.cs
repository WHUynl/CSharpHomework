using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HOMEWORK7
{
    public partial class Makeorders : Form
    {
        public  OrderService one = null;
        
        public Makeorders(OrderService one)
        {
            InitializeComponent();
            this.one = one;
            
        }

        private void  button1_Click(object sender, EventArgs z)
        {
            try
            {
                string a = textBox1.Text;
                double b = double.Parse(textBox2.Text);
                double c = double.Parse(textBox3.Text);
                string d = textBox4.Text;
                string f = textBox5.Text;
                if (!BoolPhone(d))
                {
                    textBox4.Text = "error";
                }
                
                  
                else if (!BoolNumber(f))
                {
                    textBox5.Text = "error";
                }
                else
                {
                    Order exm = new Order(a, b, c, d, f);

                    one.setList(exm);

                    Dispose();
                }
            }
            catch (Exception e) {
                if (MessageBox.Show(e.Message, "错误") == DialogResult.Yes) { }
                 
      
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        bool BoolNumber(string f)
        {
            
                
              Regex regex =new Regex("^20[0-9]{2}[01][0-9][0123][0-9][0-9]{3}$");
            
            Match m1 = regex.Match(f);
            bool m2=true;
            bool m3 = (m1.Length == f.Length);
            foreach (Order o in one.orders)
            {
                if (o.number == f)
                {
                    m2 = false;
                }
            }
            if (m1.Success&&m2&&m3)
            {
                return true;
            }
            return false;
        }
        bool BoolPhone(string d)
        {
            Regex regex = new Regex("1[0-9]{9}[0123456789]");
            Match m = regex.Match(d);
            bool m2 = (m.Length == d.Length);
            if(m.Success&&m2)
            {
                return true;
            }
            return false;
        }
    }
}
