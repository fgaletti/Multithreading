using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    class Program
    {
        // 4 Stopping Thread
        static void Main(string[] args)
        {
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }

                ));

            t.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            stopped = true;
            t.Join();
        }
    }
}
