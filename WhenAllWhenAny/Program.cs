using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace WhenAllWhenAny
{
    class Program
    {
        private static readonly ConcurrentDictionary<int, string> concurrentDictionary = new ConcurrentDictionary<int, string>();

        static async Task Main(string[] args)
        {
            var tasks = new List<Task>();
            for (int i = 0; i < 50; i++)
            {
                tasks.Add(Workload(i));
            }
            //var sw = new Stopwatch();
            //sw.Start();


            try
            {
                Task.WhenAll(tasks).Wait();

                //await Task.WhenAny(tasks)/*.Wait()*/;
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);

            Console.WriteLine("Workload finished");

            foreach (var entry in concurrentDictionary)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

            Console.ReadKey();

        }

        public static async Task Workload(int counter)
        {
            var rnd = new Random(counter + DateTime.Now.Millisecond);
            var rndNumber = rnd.Next(10);
            await Task.Delay(rndNumber * 100);

            //if (rndNumber % 3 == 0)
            //{
            //    throw new Exception($"EXCEPTION: Creation number {counter}; " +
            //    $"Thread number {Thread.CurrentThread.ManagedThreadId}; " +
            //    $"Generated number {rndNumber}");
            //}

            concurrentDictionary.TryAdd(Thread.CurrentThread.ManagedThreadId, rndNumber.ToString());

            Console.WriteLine($"Creation number {counter}; " +
                $"Thread number {Thread.CurrentThread.ManagedThreadId}; " +
                $"Generated number {rndNumber}");
        }
    }
}
