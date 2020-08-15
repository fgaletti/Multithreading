using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    // 42 Using a CancellationToken
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

           // var toke2 = true;
            Task myTask = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }

                token.ThrowIfCancellationRequested(); // notify the user when a task is cancelled
            }, token
            );

            try
            {
                Console.WriteLine("Press enter to stop the task");
                Console.ReadLine();
                cancellationTokenSource.Cancel();
                myTask.Wait();
            }
            catch (AggregateException e)
            {

                Console.WriteLine(e.InnerExceptions[0].Message);
            }
           
            Console.WriteLine("Press enter to end the program");
            Console.ReadLine();
        }
    }
}
