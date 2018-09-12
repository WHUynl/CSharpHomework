using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            double b = 0;
            double c = 0;
            string s = " ";
            Console.Write("Please input the first number: ");
            s = Console.ReadLine();
            a = double.Parse(s);
            Console.Write("Please input the second number: ");
            s = Console.ReadLine();
            b = double.Parse(s);
            c = a * b;
            Console.WriteLine($"The result is: {c}.");
        }
    }
}
