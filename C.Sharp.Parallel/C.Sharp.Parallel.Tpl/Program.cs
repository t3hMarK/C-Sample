using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.Sharp.Parallel.Tpl
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => 
            {
                Task task1 = t1();
                Task task2 = t2();

                await Task.WhenAll(task1, task2);
                Console.WriteLine("Async Done");
            });

            Console.ReadKey();
        }

        private static async Task t1()
        {
            Console.WriteLine("Begin Test 1");
            await Task.Delay(1000);
            Console.WriteLine("End Test 1");
        }

        private static async Task t2()
        {
            Console.WriteLine("Begin Test 2");
            await Task.Delay(5000);
            Console.WriteLine("End Test 2");
        }
    }
}
