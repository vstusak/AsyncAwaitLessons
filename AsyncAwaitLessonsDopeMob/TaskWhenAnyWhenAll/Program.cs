using System;
using System.IO;
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
                tasks.Add(WaitForSeconds(i*100));
            }

            await Task.WhenAll(tasks);
        }

        private static async Task WaitForSeconds(int taskNumber)
        {
            try
            {
                await Task.Delay(taskNumber);

                throw new Exception("task number is empty");

                var text = File.ReadAllText(string.Empty);

                Console.WriteLine($"Finished {taskNumber};Thread: {Thread.CurrentThread.ManagedThreadId}");
            }
            
            catch(Exception ex)
            {
                //throw new Exception("This is the catch block");
                // NEVER!!! throw a !!!new!!! exception in a catch block
                // throw;
                throw new Exception("Welcome to the Catch block", ex);
            }
        }
    }
}
