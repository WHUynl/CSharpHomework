﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOMEWORK7
{
    public class Order : OrderDetails
    {
        public Order()
        {

        }
        public Order(string a, double b, double c, string d, string f)
        {
            thing = a;
            amount = b;
            price = c;
            name = d;

            number = f;
        }


    }
}
