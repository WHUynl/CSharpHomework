using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace topic2
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
        static void Main(string[] args)
        {
            OrderService one = new OrderService();
            Order first = new Order("bread", 100, 100, "yunianlin", "001");//参数依次为：商品名称，数量，价格，买家姓名，订单号
            Order second = new Order("milk", 10, 10, "yu", "030");
            Order third = new Order("cake", 20, 20, "wang", "059");

            one.setList(first);//添加订单
            one.setList(second);
            one.setList(third);

            one.findOrder("yunianlin");//查询订单，以下三个分别为通过买家，订单号，商品名找到其在List中的序号
            one.findOrder("059");
            one.findOrder("milk");
            one.findOrder("265");//这个是信息不存在与表中的情况

            one.showList(1);//修改前订单状况
            one.changeOrdername(1, "wang");//修改买家姓名，还有其它的数据修改原理相同故不在此列出
            one.showList(1);//修改后

            one.removeList(0);//删除订单

            one.removeList(2);//删除订单时，输入的位置值不正确

        }
    }
}
