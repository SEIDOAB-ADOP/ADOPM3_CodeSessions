// See https://aka.ms/new-console-template for more information
using Seido.Utilities.SeedGenerator;

Console.WriteLine("Hello, World!");
var seeder = new SeedGenerator();

var t1 = WriteNamesAsync(seeder, 5);
var t2 = WriteLatinAsync(seeder, 10);
var t3 = WriteMusicAsync(seeder, 20);


Task.WaitAll(t1, t2, t3);
System.Console.WriteLine("Main terminated.");



static Task WriteNamesAsync(SeedGenerator seeder, int nrItems) => Task.Run(()=>WriteNames(seeder, nrItems));
static void WriteNames(SeedGenerator seeder, int nrItems)
{
    for (int i = 0; i < nrItems; i++)
    {
        System.Console.WriteLine($"{seeder.FullName} - {i}"); 
        Task.Delay(50).Wait();       
    }
}

static Task WriteLatinAsync(SeedGenerator seeder, int nrItems)=> Task.Run(()=>WriteLatin(seeder, nrItems));
static void WriteLatin(SeedGenerator seeder, int nrItems)
{
    for (int i = 0; i < nrItems; i++)
    {
        System.Console.WriteLine($"{seeder.LatinSentence} - {i}");        
        Task.Delay(50).Wait();       
    }
}

static Task WriteMusicAsync(SeedGenerator seeder, int nrItems) => Task.Run(()=>WriteMusic(seeder, nrItems));
static void WriteMusic(SeedGenerator seeder, int nrItems)
{
    for (int i = 0; i < nrItems; i++)
    {
        System.Console.WriteLine($"{seeder.MusicGroupName} - {i}");        
        Task.Delay(50).Wait();       
    }
}
