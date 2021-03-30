using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitLambdaExp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await WrapWithTime(async () =>
            {
                await Workload();
            });
            



            Console.WriteLine("\r\nPress Enter");
            Console.ReadLine();
        }

        private static async Task WrapWithTime(Func<Task> p)
        {
            Console.WriteLine(DateTime.Now);
            await p();
            Console.WriteLine(DateTime.Now);
        }

        private static async Task Workload()
        {
            Console.WriteLine("Workload started.");
            await Task.Delay(4000);
            Console.WriteLine("Workload finished.");
        }

    }
}
