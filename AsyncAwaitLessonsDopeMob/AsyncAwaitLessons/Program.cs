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
        static void Main(string[] args)
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

            Parallel.ForEach(urls, url =>
            {
                var result = LoadUrl(url);
                Console.WriteLine(url + result);
            });


            Console.ReadLine();

        }

        private static string LoadUrl(string url)
        {
            var request = WebRequest.CreateHttp(url);
            var response = request.GetResponse();
            var contentType = response.ContentType;
            return contentType;
        }
    }
}
