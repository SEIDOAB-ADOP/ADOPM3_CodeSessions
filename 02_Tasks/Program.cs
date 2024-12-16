// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.Routing;
using Seido.Utilities.SeedGenerator;

Console.WriteLine("Hello, World!");
var seeder = new SeedGenerator();
Task<int> t1=null;
Task<int> t2=null; 
Task<int> t3=null;
try
{
    t1 = WriteNamesAsync(seeder, 5);
    t2 = WriteLatinAsync(seeder, 10);
    t3 = WriteMusicAsync(seeder, 20);

    Task.WaitAll(t1, t2, t3);
    Console.WriteLine($"\nt1 result: {t1.Result}, t2 result: {t2.Result}, t3 result: {t3.Result}");
}
catch (Exception ex)
{
    System.Console.WriteLine($"{ex.Message}");

    System.Console.WriteLine($"t1 status {t1?.Status}");
    System.Console.WriteLine($"t2 status {t2?.Status}");
    System.Console.WriteLine($"t3 status {t3?.Status}");
}

System.Console.WriteLine("Main terminated.");




static Task<int> WriteNamesAsync(SeedGenerator seeder, int nrItems) => Task.Run(()=>WriteNames(seeder, nrItems));
static int WriteNames(SeedGenerator seeder, int nrItems)
{
    int sum = 0;
    for (int i = 0; i < nrItems; i++)
    {
        if (i == 2) throw new ArgumentException("Exception in WriteNames");

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
        System.Console.WriteLine($"{seeder.MusicGroupName} - {i}");        
        Task.Delay(50).Wait();   
        sum += i;      
    }
    return sum;
}
