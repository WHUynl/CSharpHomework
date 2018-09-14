using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topic_7
{
    class Program
    {
        static void Main(string[] args)
        {
            double average = 0;
            double sum = 0;
            double[] array = { 34, 26, 83, 72, 46, 59, 76 };
            double max = array[0];
            double min = array[0];
            Console.WriteLine("the elements of the array are: 34, 26, 83, 72, 46, 59, 76");
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            Console.WriteLine("the sum is: " + sum);
            average = sum / array.Length;
            Console.WriteLine("The average is: " + average);
            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];

                }
            }
            Console.WriteLine("The max is: " + max);
            for (int i = 1; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];

                }
            }
            Console.WriteLine("The min is: " + min);
        }
    }
}
