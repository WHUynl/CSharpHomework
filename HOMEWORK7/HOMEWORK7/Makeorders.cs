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
    public partial class Makeorders : Form
    {
        public  OrderService one = null;
        
        public Makeorders(OrderService one)
        {
            InitializeComponent();
            this.one = one;
            
        }

        private void button1_Click(object sender, EventArgs z)
        {
            try
            {
                string a = textBox1.Text;
                double b = double.Parse(textBox2.Text);
                double c = double.Parse(textBox3.Text);
                string d = textBox4.Text;
                string f = textBox5.Text;

                
                Order exm = new Order(a, b, c, d, f);
                
                one.setList(exm);
             
                Dispose();
            }
            catch (Exception e) {
                if (MessageBox.Show(e.Message, "错误") == DialogResult.Yes) { }
                 
      
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
