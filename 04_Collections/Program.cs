// See https://aka.ms/new-console-template for more information
using Models.Music;
using Seido.Utilities.SeedGenerator;

Console.WriteLine("Hello, Collections!");

var seeder = new SeedGenerator();

//List<T>
List<MusicGroup> music = seeder.ItemsToList<MusicGroup>(10);

music.ForEach(Console.WriteLine);
