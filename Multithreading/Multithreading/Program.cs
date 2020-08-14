using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    //11 Task.WaitAll
    class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks = new Task[3];

            // 2 case returning INT  : 
            // Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 111;
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("2");
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("3");
                return 3;
            });

            // Activate 2 case to get the result -> Console.WriteLine(tasks[0].Result);
            
             Task.WaitAll(tasks); // wait for all threads to finish

            //after WaitAll

            Console.WriteLine("After WaitAll");
        }
    }

}
