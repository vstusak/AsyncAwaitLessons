using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace csharpwednesdays
{
    class Program
    {
        static async Task Main(string[] args)
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
            //ThreadPool.SetMinThreads()

            //var stream = new FileStream("", FileMode.Open);
            //stream.BeginRead()

            var addresses = new[] {"http://seznam.cz", "http://idnes.cz", "http://novinky.cz"};

            //Parallel.ForEach(addresses, address =>
            //{
            //    var result = Load(address);
            //    Console.WriteLine(result);
            //});

            foreach (var item in addresses)
            {
                var result = await Load(item);
                Console.WriteLine(result);
            }
            Console.ReadLine();
        }

        private static async Task<string> Load(string address)
        {
            HttpWebRequest request = WebRequest.CreateHttp(address);
            using (WebResponse response = await request.GetResponseAsync())
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