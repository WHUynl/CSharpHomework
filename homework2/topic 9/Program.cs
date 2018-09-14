using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace topic_9
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList alist = new ArrayList();
            for (int i = 2; i <= 100; i++)
            {
                alist.Add(i);
            }


            for (int j = 2; j <= 100; j++)
            {
                for (int k = 2; k <= 100; k++)
                {
                    if (k > j && k % j == 0)
                    {
                        alist.Remove(k);
                    }
                }

            }

            for (int i = 0; i < alist.Count; i++)
            {



                Console.WriteLine("{0}\t", alist[i]);



            }
        }
    }
}
