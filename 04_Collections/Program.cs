// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Models.Music;
using Seido.Utilities.SeedGenerator;

Console.WriteLine("Hello, Collections!");

var seeder = new SeedGenerator();

//List<T>
List<MusicGroup> music = seeder.ItemsToList<MusicGroup>(10);

//music.ForEach(Console.WriteLine);
//music.ForEach(mg => Console.WriteLine(mg));

System.Console.WriteLine("Start adding");
var sw = new Stopwatch();
sw.Start();
var giantlist = seeder.ItemsToList<MusicGroup>(1000_000);
var ll_giantlist = new LinkedList<MusicGroup>(giantlist);

for (int i = 0; i < 100_000; i++)
{
    //giantlist.Insert(0,new MusicGroup().Seed(seeder));
    ll_giantlist.AddFirst(new MusicGroup().Seed(seeder));

}
sw.Stop();
System.Console.WriteLine($"Elapsed time {sw.ElapsedMilliseconds} ms");

System.Console.WriteLine("Stack<T>");
var stack = new Stack<MusicGroup>();
stack.Push(new MusicGroup().Seed(seeder));
stack.Push(new MusicGroup().Seed(seeder));
System.Console.WriteLine(stack.Pop());
System.Console.WriteLine(stack.Pop());

var intstack = new Stack<int>();
intstack.Push(10);
intstack.Push(20);
intstack.Push(30);
System.Console.WriteLine(intstack.Pop());  
System.Console.WriteLine(intstack.Pop()); 
System.Console.WriteLine(intstack.Pop()); 

Console.WriteLine("Queue<T>");
var intqueue = new Queue<int>();
intqueue.Enqueue(10);  
intqueue.Enqueue(20);
intqueue.Enqueue(30);  
System.Console.WriteLine(intqueue.Peek());  
System.Console.WriteLine(intqueue.Dequeue());  
System.Console.WriteLine(intqueue.Dequeue());    
System.Console.WriteLine(intqueue.Dequeue());

var intlist = new List<int>(intqueue);

System.Console.WriteLine("HashSet<T>");
var uniquelist = new List<MusicGroup>(new HashSet<MusicGroup>(giantlist));

System.Console.WriteLine($"List has {giantlist.Count} items");
System.Console.WriteLine($"uniquelist has {uniquelist.Count} unique items");

Console.WriteLine("Dictionary<TKey,TValue>");
System.Console.WriteLine("Dictionary by MusicGenre");
var musicDict = new Dictionary<MusicGenre, List<MusicGroup>>();

for (MusicGenre g = MusicGenre.Rock; g <= MusicGenre.Metal; g++)
{
    musicDict[g] = uniquelist.FindAll(mg => mg.Genre == g);   
}

System.Console.WriteLine("Jazz bands:");    
musicDict[MusicGenre.Jazz].ForEach(Console.WriteLine);
System.Console.WriteLine("Blues bands:");
musicDict[MusicGenre.Blues].ForEach(Console.WriteLine);

System.Console.WriteLine("Dictionary by Name");
var nameDict = new Dictionary<string, List<MusicGroup>>();
foreach (var mg in uniquelist)
{
    if (!nameDict.ContainsKey(mg.Name))
        nameDict[mg.Name] = new List<MusicGroup>();
    nameDict[mg.Name].Add(mg);
}
System.Console.WriteLine($"Bands with name '{uniquelist[0].Name}':");
nameDict[uniquelist[0].Name].ForEach(Console.WriteLine);

System.Console.WriteLine("Dictionary by (Name, Genre)");
var tupleDict = new Dictionary<(string Name, MusicGenre Genre), List<MusicGroup>>();
foreach (var mg in uniquelist)
{
    var key = (mg.Name, mg.Genre);
    if (!tupleDict.ContainsKey(key))
        tupleDict[key] = new List<MusicGroup>();
    tupleDict[key].Add(mg);
}