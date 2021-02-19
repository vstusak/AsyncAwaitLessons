using System;
using System.Threading.Tasks;

namespace AsyncAwaitLambda
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await TimeWrapper(async () =>
            {
                await Workload();
            });
            Console.ReadKey();
        }

        private static async Task TimeWrapper(Func<Task> a)
        {
            Console.WriteLine($"{DateTime.Now}");
            await a();
            Console.WriteLine($"{DateTime.Now}");
        }

        private static async Task Workload()
        {
            Console.WriteLine("Workload started.");
            await Task.Delay(5000).ConfigureAwait(false);
            Console.WriteLine("Workload finished.");
        }
    }
}
