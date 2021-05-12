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
        static CancellationTokenSource tokenSource = new CancellationTokenSource();
        

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


            var task = Task.Run(async () =>
            {
                await LoadAdresses(tokenSource.Token);
            });

            await Task.Delay(8000);

            tokenSource.Cancel();
            //await LoadAdresses(tokenSource.Token);
            

            Console.ReadLine();
        }

        private static async Task LoadAdresses(CancellationToken cancelToken)
        {
            var addresses = new[] { "http://seznam.cz", "http://idnes.cz", "http://novinky.cz" };
            foreach (var item in addresses)
            {
                var result = await Load(item);
                Console.WriteLine(result);

                //cancelToken.ThrowIfCancellationRequested();
                //equivalent to:
                if (cancelToken.IsCancellationRequested)
                {
                    throw new TaskCanceledException($"Cancelled for {item}");
                }
            }
        }

        private static async Task<string> Load(string address)
        {
            HttpWebRequest request = WebRequest.CreateHttp(address);
            using (WebResponse response = await request.GetResponseAsync())
            {
                await Task.Delay(5000);
                return response.ContentType;
            }

            //var response = request.GetResponse();
            //var result = response.ContentType;
            //response.Dispose();
            //return result;
        }
    }
}