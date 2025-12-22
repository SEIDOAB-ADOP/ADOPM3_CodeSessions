// See https://aka.ms/new-console-template for more information
using Models.Employees;
using Seido.Utilities.SeedGenerator;

Console.WriteLine("Hello, Linq!");

var seeder = new SeedGenerator();
var employees = seeder.ItemsToList<Employee>(100);

