using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace WhenAllWhenAny
{
    class Program
    {
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
                //Task.WhenAll(tasks).Wait();
                await Task.WhenAny(tasks)/*.Wait()*/;
            }
            catch (Exception ex)
            {
                throw;
            }
            
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);

            Console.WriteLine("Workload finished");
            Console.ReadKey();
        }

        public static async Task Workload(int counter)
        {
            var rnd = new Random(counter + DateTime.Now.Millisecond);
            var rndNumber = rnd.Next(10);
            await Task.Delay(rndNumber * 100);

            Console.WriteLine($"Creation number {counter}; " +
                $"Thread number {Thread.CurrentThread.ManagedThreadId}; " +
                $"Generated number {rndNumber}");
        }
    }
}
