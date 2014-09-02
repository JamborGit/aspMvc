using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awaitConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = example1(); 

        }
        static async Task DoWork()
        {

            Console.WriteLine("Hello World!");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Working..{0}", i);
                await Task.Delay(1000);//以前我们用Thread.Sleep(1000)，这是它的替代方式。 
            }
        }
        static async Task example1()
        {
            await DoWork();
            Console.WriteLine("First async Run End");
        }
    }
}
