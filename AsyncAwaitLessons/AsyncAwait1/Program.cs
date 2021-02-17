using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace csharpwednesdays
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < int.MaxValue; i++)
            //{
            //    var thread = new Thread(() =>
            //    {
            //        Thread.Sleep(-1);
            //    });
            //    thread.Start();
            //    Console.WriteLine(i);
            //}

            //ThreadPool.QueueUserWorkItem()
            //Task t = Task.Run(() =>
            //{
            //    Console.WriteLine("Hello world!");
            //    Thread.Sleep(32);
            //    Thread.Yield();
            //});
            //t.Wait();

            var addresses = new[] {"http://seznam.cz", "http://idnes.cz", "http://novinky.cz"};

            foreach (var address in addresses)
            {
                var result = Load(address);
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }

        private static string Load(string address)
        {
            HttpWebRequest request = WebRequest.CreateHttp(address);
            using (WebResponse response = request.GetResponse())
            {
                return response.ContentType;
            }

            //var response = request.GetResponse();
            //var result = response.ContentType;
            //response.Dispose();
            //return result;
        }
    }
}