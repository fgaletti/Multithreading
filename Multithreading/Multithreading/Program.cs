using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    //35 Share Data Multithread 
    class Program
    {

        // non-atomic 
        static void Main(string[] args)
        {
            int n = 0;

            object _lock = new object(); //Ensure that n = 0, Make the thread atomic

            Task myTask = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock(_lock)
                    {
                        n++;
                    }
                   // n++;
                    // n++ -> is reading and writing
                    // n = n + 1 ;
                    // 1 step : reading n
                    // 2 step : sum  of n + 1    
                    // 3 step: after the step 2 n could have been updated for the other thread n = n -1 or more that one time n -1 ; n -1 ;
                    // 4 step : assign the sum of (n + 1 ) -> n (but n was modified by the second thread)
                    //                                        maybe 1 or multiple times  

                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                lock (_lock)
                {
                    n--;
                }
               // n--;
            }

            myTask.Wait();
            Console.WriteLine(n);

        }
    }
}
