using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitLessons
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Run(() =>
            {
                Console.WriteLine("Hello world.");
                Thread.Sleep(1000);
                FileStream fileStream = new FileStream("", FileMode.OpenOrCreate);
                //await fileStream.ReadAsync();

                //TODO - řádek 38 - pokračovat
            });

            Console.ReadLine();
        }
    }
}
