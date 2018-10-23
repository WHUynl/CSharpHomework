using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsForTest
{
    class Program
    {
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
