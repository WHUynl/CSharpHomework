using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
namespace HOMEWORK7
{
    [Serializable]
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

        private void button7_Click(object sender, EventArgs e)
        {
            var a = one.Export(one.orders);
            Console.WriteLine(File.ReadAllText("s.xml"));
            using (FileStream fs = new FileStream("s.xml", FileMode.Open))
            {
                List<Order> orders2 = (List<Order>)a.Deserialize(fs);
                foreach (Order mine in orders2)
                {
                    Console.WriteLine(mine);
                }
            }
            bool bFile = File.Exists("s.xml");

            if (bFile)
            {
                textBox1.Text = "成功！";
            }
            else
            {
                textBox1.Text = "失败！";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\Users\YNL\source\repos\Yanshi\HOMEWORK7\HOMEWORK7\bin\Debug\s.xml");

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(@"C:\Users\YNL\source\repos\Yanshi\HOMEWORK7\HOMEWORK7\s.xslt");

                FileStream outFileStream = File.OpenWrite(@"C:\Users\YNL\source\repos\Yanshi\HOMEWORK7\HOMEWORK7\bin\Debug\BoolList.html");
                XmlTextWriter writer =
                    new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                xt.Transform(nav, null, writer);

            }
            catch (XmlException v)
            {
                textBox1.Text = v.ToString();
            }
            catch(XsltException v)
            {
                textBox1.Text = v.ToString();
            }

        }
    }
      
    
}
