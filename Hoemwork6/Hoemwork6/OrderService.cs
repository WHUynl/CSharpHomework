using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Hoemwork6
{
    /// <summary>
    /// OrderService:provide ordering service,
    /// like add order, remove order, query order and so on
    /// 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    /// </summary>
    [Serializable]
    public class OrderService
    {
     
        public  Dictionary<uint, Order> orderDict;
        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }

        /// <summary>
        /// add new order
        /// </summary>
        /// <param name="order">the order will be added</param>
        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.Id))
                throw new Exception($"order-{order.Id} is already existed!");
            orderDict[order.Id] = order;
        }

        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="orderId">id of the order which will be canceled</param> 
        public void RemoveOrder(uint orderId)
        {
            orderDict.Remove(orderId);
        }

        /// <summary>
        /// query all orders
        /// </summary>
        /// <returns>List<Order>:all the orders</returns> 
        public List<Order> QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }

        /// <summary>
        /// query by orderId
        /// </summary>
        /// <param name="orderId">id of the order to find</param>
        /// <returns>List<Order></returns> 
        public Order GetById(uint orderId)
        {
            return orderDict[orderId];
        }

        /// <summary>
        /// query by goodsName
        /// </summary>
        /// <param name="goodsName">the name of goods in order's orderDetail</param>
        /// <returns></returns> 
        public List<Order> QueryByGoodsName(string goodsName)
        {
            var query = orderDict.Values.Where(order =>
                    order.Details.Where(d => d.Goods.Name == goodsName)
                    .Count() > 0
                );
            return query.ToList();

        }

        /// <summary>
        /// query by customerName
        /// </summary>
        /// <param name="customerName">customer name</param>
        /// <returns></returns> 
        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orderDict.Values
                .Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }

        public List<Order> QueryByPrice(double price)
        {
            var query = orderDict.Values
                .Where(order => order.Amount > price);
            return query.ToList();
        }


        /// <summary>
        /// edit order's customer
        /// </summary>
        /// <param name="orderId"> id of the order whoes customer will be update</param>
        /// <param name="newCustomer">the new customer of the order which will be update</param> 
        public void UpdateCustomer(uint orderId, Customer newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
            }
            else
            {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }
        public XmlSerializer Export(List<Order> od)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("s.temp", FileMode.Create))
            {
                xml.Serialize(fs, od);
            }
            return xml;
        }
        public void Import(XmlSerializer xml)
        {
            using (FileStream fs = new FileStream("s.temp", FileMode.Open))
            {
                List<Order> od2 = (List<Order>)xml.Deserialize(fs);
               foreach(Order mine in od2)
                {
                    Console.WriteLine(mine);
                }
            }
            
        }
    }
}
