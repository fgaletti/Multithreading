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
        public static void ThreadMethod(Object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc {0} ", i);
                Thread.Sleep(0); // foreground thread
            }
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(15);
            t.Join();
            Console.ReadLine();
        }
    }
}
