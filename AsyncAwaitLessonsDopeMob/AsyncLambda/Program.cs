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
        static void Main(string[] args)
        {
            WrapWithTime(() => { Workload(); });
            Console.ReadKey();
        }

        private static void Workload()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Workload finished. ");
        }

        private static void WrapWithTime(Action a)
        {
            Console.WriteLine(DateTime.Now);
            a();
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
