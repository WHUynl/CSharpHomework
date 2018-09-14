using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string a;
                Console.Write("Please write the number: ");
                a = Console.ReadLine();
                int A = int.Parse(a);
                int B = A;
                for (int i = 2; i < B / 2;)
                {
                    if (A % i == 0)
                    {
                        Console.Write(i + " ");
                        A = A / i;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("input error " + e.Message);
            }
        }
    }
}
