using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitLocks
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var deadlock = new DeadlockClass();
            await deadlock.Workload();
            //lock (deadlock)
            //{
            //
            //}
            //await Workload();
        }
        private static async Task Workload()
        {
            Console.WriteLine("Workload started.");
            await Task.Delay(5000).ConfigureAwait(false);
            Console.WriteLine("Workload finished.");
        }      
    }

    public class DeadlockClass
    {
        private static readonly object _workloadLock = new object();
        public async Task Workload()
        {
            Console.WriteLine("Workload started.");
            /*lock (_workloadLock)
            {
                await Task.Delay(5000).ConfigureAwait(false);
            }*/

            Monitor.Enter(_workloadLock);
            await Task.Delay(5000).ConfigureAwait(false);            
            Monitor.Exit(_workloadLock);

            Console.WriteLine("Workload finished.");
            Console.ReadLine();
        }
    }
}
