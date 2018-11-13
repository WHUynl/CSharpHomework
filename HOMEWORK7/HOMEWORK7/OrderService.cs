using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
namespace HOMEWORK7
{
    [Serializable]
    public class OrderService:OrderDetails
    {
        public OrderService()
        {
        }

        public List<Order> orders = new List<Order>();
        public void setList(Order a)
        {
            orders.Add(a);
        }
        public string showList(int i)
        {
            return "商品名称，数量，价格，买家姓名，订单号分别为： " + orders[i].thing + " " + orders[i].amount + " " + orders[i].price + " " + orders[i].name + " " + orders[i].number;
        }
        public string showList2(int i)
        {
            return orders[i].thing + " " + orders[i].amount + " " + orders[i].price + " " + orders[i].name + " " + orders[i].number;
        }
        public void removeList(int i)
        {
            try
            {
                removeOrder(i);
            }
            catch (Exception e)
            {
                if (MessageBox.Show(e.Message, "错误") == DialogResult.Yes) { }


            }
        }
        public void removeOrder(int i)
        {
            if (i >= orders.Count || i < 0)
            {
                throw new MyException();
            }


            orders.RemoveAt(i);


        }

        public void changeOrdername(int i, string a)
        {
            orders[i].name = a;
        }
        public void changeOrdernumber(int i, string a)
        {
            orders[i].number = a;
        }
        public void changeOrderthing(int i, string a)
        {
            orders[i].thing = a;
        }
        public void changeOrderamount(int i, double a)
        {
            orders[i].amount = a;
        }
        public void changeOrderprice(int i, double a)
        {
            orders[i].price = a;
        }
        public string findOrder(string a)

        {
            int i = -1;
            foreach (Order order in orders)
            {

                if (order.name == a || order.number == a || order.thing == a)
                {
                    i = orders.IndexOf(order);
                    return "the location is: " + i;
                }


            }
            if (i == -1)
            {
                return "Nothing";
            }
            return "wrong";
        }
        public XmlSerializer Export(List<Order> od)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("s.xml", FileMode.Create))
            {
                xml.Serialize(fs, od);
            }
            return xml;
        }
    }
}
