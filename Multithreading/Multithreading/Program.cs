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
        // foreground / background
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc2 {0} ", i);
                Thread.Sleep(1000); // background thread
            }
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.IsBackground = true; // It does not prevent the program from closing 
            t.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main Thread: Do some work");
                Thread.Sleep(0); // foreground thread
            }

            t.Join(); // prevent the program to close as soon as we exit the method "For" 
                      // don go pass this line of code Until the thread we executed is Done Executing its code
                      //Always wait for all the thread to finish

            Console.WriteLine("AFTER");
        }
    }
}
