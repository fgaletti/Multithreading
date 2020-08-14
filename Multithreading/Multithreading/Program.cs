using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    //12 Task.WaitAny
    class Program
    {
        static void Main(string[] args)
        {
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(2000);
                return 1;
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(2000);
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(2000);
                return 3;
            });

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks); // wait for any Task that is completed, it can be Any 1,2,3 in an unpreditable order      
                Task<int> completedTask = tasks[i];
                Console.WriteLine(completedTask.Result);
                var temp = tasks.ToList();
                temp.RemoveAt(i); // remove the task that is completed
                tasks = temp.ToArray();
            }


            /* List OF TASK String */
            /* Task<string>[] tasksStrings = new Task<string>[3];
             tasksStrings[0] = Task.Run(() =>
             {
                 Thread.Sleep(2000);
                 return "String";
             });*/

        }
    }
}
