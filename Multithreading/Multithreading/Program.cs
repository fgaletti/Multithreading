using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    // 45 Setting a timeout on a task
    class Program
    {
        static void Main(string[] args)
        {
            Task longRunning = Task.Run(() =>
            {
                Console.WriteLine("Inside longRunning");
                Thread.Sleep(5000);
            });

            // if it surpasses thta amount of time we can Cut the task Off 
            int index = Task.WaitAny(new Task[] { longRunning }, 1000);
            if(index == -1)
            {
                Console.WriteLine("Task timed out");
            }
        }
    }
}
