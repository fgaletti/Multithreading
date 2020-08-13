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
        //  5_Thread_Static
        [ThreadStatic]
        public static int _field; // unique for every field 

        static void Main(string[] args)
        {
            // thread 1
            Thread t1 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }
            ));
            t1.Start();

            // thread 2
            Thread t2 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread BB: {0}", _field);
                }
            }
            ));
            t2.Start();

            Console.ReadKey();
        }
    }
}
