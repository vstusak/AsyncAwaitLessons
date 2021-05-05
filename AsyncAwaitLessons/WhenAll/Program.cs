using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhenAll
{
    class Program
    {
        private static ConcurrentDictionary<int, string> _dictionary = new ConcurrentDictionary<int, string>();
        private static SynchronizedCollection<string> _collection = new SynchronizedCollection<string>();
        public static async Task Main(string[] args)
        {

            var tasks = new List<Task>();
            for (int i = 0; i < 50; i++)
            {
                tasks.Add(MyAsyncMethod(i));
            }

            try
            {
                await Task.WhenAll(tasks);

                //await Task.WhenAny(tasks);

                //var whenAnyTask = await Task.WhenAny(tasks);
                //await whenAnyTask;
            }
            catch (Exception e)
            {
                if (e is AggregateException)
                {
                    foreach (var item in ((AggregateException)e).InnerExceptions)
                    {
                        Console.WriteLine($"AggregateException: {item.Message}");
                    }
                }
                else
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Everything's finished.");
            Console.ReadLine();

            foreach (var d in _dictionary)
            {
                Console.WriteLine($"{d.Key}: {d.Value}");
            }

            Console.ReadLine();
        }

        public static async Task MyAsyncMethod(int randomSeed)
        {
            //var i = new Random(randomSeed).Next(0, 9);

            //await Task.Delay(i * 100);

            

            //if (i < 5)
            //{
            //throw new Exception($"Exception: Generated number was {i}. Worker thread: {Thread.CurrentThread.ManagedThreadId}. Seed number was {randomSeed}.");
            //}

            //Console.WriteLine($"Generated number was {i}. Worker thread: {Thread.CurrentThread.ManagedThreadId}. Seed number was {randomSeed}.");

            _dictionary.TryAdd(1, "rtiuhgfc bnhgtrfd");
            _collection.Add("rtiuhgfc bnhgtrfd");

            Console.WriteLine($"Task {randomSeed} finished writing to concurrent dictionary.");
        }
    }
}
