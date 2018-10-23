using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsForTest
{
    public class OrderService
    {

        public List<Order> orders = new List<Order>();
        public void setList(Order a)
        {
            orders.Add(a);
        }
        public void showList(int i)
        {
            Console.WriteLine("商品名称，数量，价格，买家姓名，订单号分别为： " + orders[i].thing + " " + orders[i].amount + " " + orders[i].price + " " + orders[i].name + " " + orders[i].number);
        }

        public void removeList(int i)
        {
            try
            {
                removeOrder(i);
            }
            catch (MyException e) { e.outputerror(); }
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
        public void findOrder(string a)

        {
            int i = -1;
            foreach (Order order in orders)
            {

                if (order.name == a || order.number == a || order.thing == a)
                {
                    i = orders.IndexOf(order);
                    Console.WriteLine("the location is: " + i);
                }


            }
            if (i == -1)
            {
                Console.WriteLine("Nothing");
            }
        }
    }
}
