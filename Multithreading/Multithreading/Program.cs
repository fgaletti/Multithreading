using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    //16 Parallel.For / ForEach
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("Value of {0}",i);
            //    Thread.Sleep(1000);
            //}

            Thread.Sleep(2000);
            Console.WriteLine("Start");

            // FOR ------
            Parallel.For(0, 20, (i) =>
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            });

            Console.ReadKey();
            //FOR EACH ----
            Console.Clear();

            Thread.Sleep(2000);
            Console.WriteLine("Start");
            int[] myArray = { 0, 11, 22, 33, 44, 55, 66, 77, 88, 99, 100 };

            Parallel.ForEach(myArray, (i) =>
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            });

        }
    }
}
