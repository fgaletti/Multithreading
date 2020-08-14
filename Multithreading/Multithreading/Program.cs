using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    // 40_Using_The_Interlocked_Class
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Task myTask = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                   // n++;
                    Interlocked.Increment(ref n);
                }
            }
            );

            for (int i = 0; i < 1000000; i++)
            {
                n--;
                Interlocked.Decrement(ref n);
            }
            myTask.Wait();
            Console.WriteLine(n);
        }
    }
}
