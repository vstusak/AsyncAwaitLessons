using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitLessons
{
    class Program
    {
        static async void Main(string[] args)
        {

            //Task t = Task.Run(() =>
            //{
            //Console.WriteLine("Hello world.");
            //Thread.Sleep(1000);
            //FileStream fileStream = new FileStream("", FileMode.OpenOrCreate);
            //await fileStream.ReadAsync();

            //TODO - řádek 38 - pokračovat
            //});
            var urls = new[] { "https://google.com", "https://seznam.cz", "https://doodle.com", "https://manning.com", "https://reddit.com" };

            //foreach (var url in urls)
            //{
            //    //string contentType = LoadUrl(url);
            //    //Console.WriteLine(contentType);
            //    var result = LoadUrl(url);
            //    Console.WriteLine(result);

            //}

            ThreadPool.SetMinThreads(100,100);
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;

            Parallel.ForEach(urls, async url =>
            {
                var result = await LoadUrl(url);
                Console.WriteLine(url + result);
            });

            Console.ReadLine();
        }
        

        private static async Task<string> LoadUrl(string url)
        {
            var request = WebRequest.CreateHttp(url);
            WebResponse response = await GetResponse(request);
            var contentType = response.ContentType;
            return contentType;
        }

        private static async Task<WebResponse> GetResponse(HttpWebRequest request)
        {
            return await request.GetResponseAsync();
        }
    }
}
