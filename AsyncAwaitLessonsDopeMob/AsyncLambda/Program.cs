using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncLambda
{
    class Program
    {
        static async Task Main(string[] args)
        //static void Main(string[] args)
        {
            var i = 3;
            await WrapWithTime(async () => { await Workload(i); }); //async call for async code
            //WrapWithTime(async () => { await Workload(i); }).Wait(); //sync call for async code
            //_ = WrapWithTime(async () => { await Workload(i); }); //sync call for async code

            Console.ReadKey();
        }

        private static async Task Workload(int seconds)
        {
            //Thread.Sleep(5000); //Loading from I/O, no processor operation
            await Task.Delay(TimeSpan.FromSeconds(seconds)); //Loading from I/O, but using async method

            Console.WriteLine("Workload finished. ");
        }

        private static async Task WrapWithTime(Func<Task> a)
        {
            Console.WriteLine(DateTime.Now);
            await a();
            Console.WriteLine(DateTime.Now);
        }

        //    private static void CollectionExample()
        //    {
        //        var people = new List<Person>();
        //        var petres = people.Where(NewMethod());
        //    }

        //    private static Func<Person, bool> NewMethod()
        //    {
        //        return person => person.Name == "Petr";
        //    }
        //}

        //internal class Person
        //{
        //    public string Name { get; set; }
        //    public string Surname { get; set; }

    }
}
