using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpAcademyAsyncTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < int.MaxValue; i++)
            //{
            //    var t = new Thread(_ =>
            //    {
            //        Thread.Sleep(3);
            //    });
            //    t.Start();
            //}
            //ThreadPool.QueueUserWorkItem(_ => Thread.Sleep(3));

            var urls = new[] { "http://www.seznam.cz", "http://www.google.com", "http://www.github.com" };
            //foreach (var item in urls)
            //{
            //    var result = Load(item);
            //    Console.WriteLine(result);
            //}
            ServicePointManager.DefaultConnectionLimit = Int32.MaxValue;
            ThreadPool.SetMinThreads(12, 1);
            //new Stream().BeginRead()
            Parallel.ForEach(urls, item => // only for non-blocking calculation
            {
                Console.WriteLine(Load(item));
            });

            // async await - Silver ligth



            //var t = Task.Run(() =>
            //{
            //    Console.WriteLine("Hello world in thread");
            //    //Thread.Sleep(32);
            //    //Thread.Yield();
            //});
            Console.ReadLine();
        }

        private static string Load(string item)
        {
            var request = WebRequest.CreateHttp(item);
            using var response = request.GetResponse();

            return response.ContentType;
        }

        private static async Task<string> LoadAsync(string item)
        {
            return await Task.FromResult("");
        }

    }
}
