using System;
using System.Threading.Tasks;

namespace _02a_Tasks 
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var t1 = Task.Run(() => SayHello());
            var t2 = Task.Run(() => SayGoodbye());
                        
            await Task.WhenAll(t1, t2);

            await Task.Run(() => SayGoodEvening());

        }


        static void SayHello()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Hello from SayHello method {i + 1}!");
                Task.Delay(1000).Wait();
            }
        }
        static void SayGoodbye()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Hello from SayGoodbye method {i + 1}!");
                Task.Delay(50).Wait();
            }
        }
        
        static void SayGoodEvening()
        {   
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Hello from SayGoodEvening method {i + 1}!");
                Task.Delay(1000).Wait();

            }
        }

    }
}