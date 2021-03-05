using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarQubeEndExceptions
{
    /* example for Sonar Qube
    class Program
    {
        static async Task Main(string[] args)
        {
            await MyAsyncMethod(string.Empty);
        }

        private static async Task MyAsyncMethod(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new NotImplementedException();
            }
            await WorkLoad(input);
        }

        private static async Task WorkLoad(string input)
        {
            await Task.Delay(5000);
        }
    }*/

    class Program
    {
        public static void Main(string[] args)
        {
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            try
            {
            //MyAsyncMethod(string.Empty);
            MyAsyncVoidMethod();
            //Console.ReadLine();
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        public static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
            Console.WriteLine(e.Exception.InnerException.Message);
        }

        public static async Task MyAsyncMethod(string input)
        {
            Console.WriteLine("My Async method");
            throw new Exception("Hello from My Async method");
        }

        public static async void MyAsyncVoidMethod()
        {
            Console.WriteLine("My Async void method");
            throw new Exception("Hello from My Async void method");
        }
    }
}
