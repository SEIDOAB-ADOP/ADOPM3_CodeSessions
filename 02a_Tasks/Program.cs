using System;

namespace _02a_Tasks 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var sum = SayGreetingsAsync("Greetings").Result;
            Console.WriteLine($"Sum from SayGreetingsAsync: {sum}");

            var t1 = SayHelloAsync();
            var t2 = SayGoodByeAsync();
            
            Task.WaitAll(t1, t2);

            var t3 = SayGoodEveningAsync();
            Task.WaitAll(t1, t2, t3);

        }

        static Task<int> SayGreetingsAsync(string greetings) => Task.Run(() => SayGreetings(greetings));
        static int SayGreetings(string greetings)
        {
            var sum = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{greetings} from SayGreetings method {i + 1}!");
                Task.Delay(1000).Wait();
                sum += i;
            }
            return sum;
        }


        static Task SayHelloAsync() => Task.Run(() => SayHello());
        static void SayHello()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Hello from SayHello method {i + 1}!");
                Task.Delay(1000).Wait();
            }
        }


        static Task SayGoodByeAsync() => Task.Run(() => SayGoodbye());
        static void SayGoodbye()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Hello from SayGoodbye method {i + 1}!");
                Task.Delay(50).Wait();
            }
        }
        
        static Task SayGoodEveningAsync() => Task.Run(() => SayGoodEvening());
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