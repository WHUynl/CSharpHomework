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
    public partial class Form1 : Form
    {
        
        private static Makeorders newForm;
        private static Changeorders changeorders;
        public static OrderService one = new OrderService();
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {



            if (newForm == null || newForm.IsDisposed)
            {
                newForm = new Makeorders(one);
                newForm.Show();
            }
            else
            {
                newForm.WindowState = FormWindowState.Normal;
                newForm.Activate();
            }
            
        }



        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                int a = int.Parse(textBox1.Text);
                string b = one.showList(a);
                textBox1.Text = b;
            }
            catch (Exception z)
            {
                if (MessageBox.Show(z.Message, "错误") == DialogResult.Yes) { }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = one.findOrder(textBox2.Text);
            textBox2.Text = a;
          
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(textBox3.Text);
                one.removeList(a);
                textBox3.Text = "";
            }
            catch (Exception z)
            {
                if (MessageBox.Show(z.Message, "错误") == DialogResult.Yes) { }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (changeorders == null || changeorders.IsDisposed)
            {
                changeorders = new Changeorders(one);
                changeorders.Show();
            }
            else
            {
                changeorders.WindowState = FormWindowState.Normal;
                changeorders.Activate();
            }
        }

        public void button6_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            for
                 (int i = 0; i < one.orders.Count; i++) {
                string a = one.showList2(i);
                listBox1.Items.Add(a);
                
        }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
