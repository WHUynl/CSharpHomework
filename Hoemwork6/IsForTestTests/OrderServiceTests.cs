using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsForTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsForTest.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        Order A = new Order("1", 1, 1, "2", "3");
        Order B = new Order("1", 1, 1, "2", "4");
        [TestMethod()]
        public void setListTest()
        {
            OrderService a = new OrderService();


            List<Order> INF = new List<Order> { new Order("1", 1, 1, "2", "3") };
            a.orders.Add(A);

            Assert.AreSame(INF, INF);

        }



        [TestMethod()]
        public void removeOrderTest()
        {
            OrderService b = new OrderService();
            b.orders.Add(A);
            b.orders.Add(B);
            b.removeOrder(0);
            Assert.AreEqual<Order>(b.orders[0], B);//正确的


        }

        [TestMethod()]
        public void changeOrdernameTest()
        {
            OrderService c = new OrderService();
            c.orders.Add(A);
            string a = c.orders[0].name;
            Assert.AreEqual<string>(a, "3");//错误的


        }

        [TestMethod()]
        public void changeOrdernumberTest()
        {
            OrderService c = new OrderService();
            c.orders.Add(A);
            string a = c.orders[0].number;
            Assert.AreEqual<string>(a, "3");//正确的
        }

        [TestMethod()]
        public void changeOrderthingTest()
        {
            OrderService c = new OrderService();
            c.orders.Add(A);
            string a = c.orders[0].thing;
            Assert.AreEqual<string>(a, "2");//错误的
        }

        [TestMethod()]
        public void changeOrderamountTest()
        {
            OrderService c = new OrderService();
            c.orders.Add(A);
            double a = c.orders[0].amount;
            Assert.AreEqual<double>(a, 1);//正确的
        }

        [TestMethod()]
        public void changeOrderpriceTest()
        {
            OrderService c = new OrderService();
            c.orders.Add(A);
            double a = c.orders[0].price;
            Assert.AreEqual<double>(a, 2);//错误的
        }
    }
}