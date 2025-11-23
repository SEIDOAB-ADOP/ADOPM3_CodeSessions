// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.Routing;
using Seido.Utilities.SeedGenerator;

using System;

namespace _03_await // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var seeder = new SeedGenerator();

            List<Task<int>> tasks = new List<Task<int>>();
            try
            {
                tasks.Add(WriteNamesAsync(seeder, 5));
                await tasks[0];

                tasks.Add(WriteLatinAsync(seeder, 10));
                await tasks[1];

                tasks.Add(WriteMusicAsync(seeder, 20));
                await tasks[2];

                //await Task.WhenAll(tasks[0], tasks[1], tasks[2]);
                foreach (var item in tasks)
                {
                    Console.WriteLine($"\ntask result: {item.Result}");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"{ex.Message}");

                foreach (var item in tasks)
                {
                    Console.WriteLine($"\ntask status: {item.Status}");
                }
            }

            System.Console.WriteLine("Main terminated.");
        }

        static Task<int> WriteNamesAsync(SeedGenerator seeder, int nrItems) => Task.Run(()=>WriteNames(seeder, nrItems));
        static int WriteNames(SeedGenerator seeder, int nrItems)
        {
            int sum = 0;
            for (int i = 0; i < nrItems; i++)
            {

                System.Console.WriteLine($"{seeder.FullName} - {i}"); 
                Task.Delay(50).Wait();  
                sum += i;     
            }
            return sum;
        }

        static Task<int> WriteLatinAsync(SeedGenerator seeder, int nrItems)=> Task.Run(()=>WriteLatin(seeder, nrItems));
        static int WriteLatin(SeedGenerator seeder, int nrItems)
        {
            int sum = 0;
            for (int i = 0; i < nrItems; i++)
            {
                System.Console.WriteLine($"{seeder.LatinSentence} - {i}");        
                Task.Delay(50).Wait();       
                sum += i;     
            }
            return sum;
        }

        static Task<int> WriteMusicAsync(SeedGenerator seeder, int nrItems) => Task.Run(()=>WriteMusic(seeder, nrItems));
        static int WriteMusic(SeedGenerator seeder, int nrItems)
        {
            int sum = 0;
            for (int i = 0; i < nrItems; i++)
            {
                if (i == 2) throw new ArgumentException("Exception in WriteNames");
                System.Console.WriteLine($"{seeder.MusicGroupName} - {i}");        
                Task.Delay(50).Wait();   
                sum += i;      
            }
            return sum;
        }

    }
}



