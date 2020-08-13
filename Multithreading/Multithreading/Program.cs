using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{

    //8_Start a New Task
    class Program
    {
        public static void ThreadMethod()
        {
            Task t = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("*");
                }
            }
            );
        }
        static void Main(string[] args)
        {
            Task t = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("*");
                }
            }
                );

            t.Wait(); //T.JOIN , Same thing 

            // With Fucntions

            Task t2 = Task.Run(action: ThreadMethod);
            t2.Wait();

            var t3 = Task.Run(() => ThreadMethod());
        }
    }
}
