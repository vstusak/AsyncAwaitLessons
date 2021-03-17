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
        static void Main(string[] args)
        {
            WrapWithTime(async () =>
            {
                await Workload();
            });
            



            Console.WriteLine("\r\nPress Enter");
            Console.ReadLine();
        }

        private static void WrapWithTime(Action p)
        {
            Console.WriteLine(DateTime.Now);
            p();
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
