using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class Program
    {
        class MyException : ApplicationException
        {
            private string idnumber = "输入类型错误或输入数值不正确";
            public MyException()
            {

            }
            public void outputerror()
            {
                Console.WriteLine(idnumber);
            }

        }
        public class Order : OrderDetails
        {
            public Order(string a, double b, double c, string d, string f)
            {
                thing = a;
                amount = b;
                price = c;
                name = d;

                number = f;
            }


        }
        public class OrderDetails
        {
            public string thing;
            public double amount;
            public double price;
            public string name;

            public string number;
        }
        public class OrderService
        {

            public List<Order> orders = new List<Order>();
            public List<int> query = new List<int>();

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
                query.Clear();
                for (int k = 0; k < orders.Count; k++)
                {
                    query.Add(k);
                }
                var m = from item in query where orders[item].name.Equals(a) || orders[item].thing.Equals(a) select item;
                foreach (var n in m)
                {
                    i = 1;
                    Console.WriteLine("the location is : " + n);
                }
                if (i == -1)
                {
                    Console.WriteLine("Nothing");
                }
            }
            public void findMoney(int a)

            {
                int i = -1;
                query.Clear();
                for (int k = 0; k < orders.Count; k++)
                {
                    query.Add(k);
                }
                var m = from item in query where orders[item].price > a select item;
                foreach (var n in m)
                {
                    i = 1;
                    Console.WriteLine("the location is : " + n);
                }
                if (i == -1)
                {
                    Console.WriteLine("Nothing");
                }
            }
        }

        static void Main(string[] args)
        {
            OrderService one = new OrderService();
            Order first = new Order("bread", 100, 10000, "yunianlin", "001");//参数依次为：商品名称，数量，价格，买家姓名，订单号
            Order second = new Order("milk", 10, 100000, "yu", "030");
            Order third = new Order("cake", 20, 200000, "wang", "059");

            one.setList(first);//添加订单
            one.setList(second);
            one.setList(third);
            one.showList(1);//输入位置值，展示订单
            one.findOrder("yunianlin");//查询订单,输入买家名得到位置值
            one.findOrder("milk");//查询订单，输入商品名得到位置值
            one.findMoney(10000);//查询订单，输入价格，得到大于该价格的订单的位置值


        }
    }
}
