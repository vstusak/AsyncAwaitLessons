using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhenAll
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var tasks = new List<Task>();
            for (int i = 0; i < 50; i++)
            {
                tasks.Add(MyAsyncMethod(i));
            }

            Task.WhenAll(tasks).Wait();
            Console.WriteLine("Everything's finished.");
            Console.ReadLine();
        }

        public static async Task MyAsyncMethod(int randomSeed)
        {
            var i = new Random(randomSeed).Next(0, 9);
            await Task.Delay(i * 100);
            Console.WriteLine($"Generated number was {i}. Worker thread: {Thread.CurrentThread.ManagedThreadId}. Seed number was {randomSeed}.");
        } 
    }
}
