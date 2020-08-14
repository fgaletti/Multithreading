using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    // 37_Creating a deadlock
    // where both thread are waiting for each other
    class Program
    {
        static void Main(string[] args)
        {
            object lockA = new object();
            object lockB = new object();

            Task myTask = Task.Run(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(5000); //We could omit this line
                    lock (lockB)
                    {
                        Console.WriteLine("Locked A and B");
                    }
                }
            }
            );

            lock (lockB)
            {
                Thread.Sleep(1000);
                lock (lockA)
                {
                    Console.WriteLine("Locked B and A");
                }
            }

            myTask.Wait();
        }
    }
}
