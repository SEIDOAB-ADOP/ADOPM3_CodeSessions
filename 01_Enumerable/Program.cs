using System.Runtime.InteropServices;
using _01_Enumerable.Models;

Console.WriteLine("Hello, Friends!");

var friends = new FriendList(10_000);

System.Console.WriteLine($"Number of friends in list: {friends.Count}");

System.Console.WriteLine(friends[3]);
for (int i = 0; i < 10; i++)
{
    System.Console.WriteLine(friends[i]);
}


System.Console.WriteLine("\nFirst 10 friends");
foreach (var item in friends.OrderBy(f => f.Car.Color).Take(10))
{
    System.Console.WriteLine(item);
}

System.Console.WriteLine("\nLast 10 friends");
foreach (var item in friends.OrderBy(f => f.Car.Color).TakeLast(10))
{
    System.Console.WriteLine(item);
}