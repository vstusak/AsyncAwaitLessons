using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWhenAnyWhenAll
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var tasks = new List<Task>();
            for (int i = 0; i < 50; i++)
            {
                tasks.Add(WaitForSeconds(i));
            }

            await Task.WhenAll(tasks);
        }

        private static async Task WaitForSeconds(int taskNumber)
        {
            await Task.Delay(taskNumber);
            Console.WriteLine($"Finished {taskNumber};Thread: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
