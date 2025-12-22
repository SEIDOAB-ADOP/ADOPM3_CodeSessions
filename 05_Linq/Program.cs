// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.Http.Features;
using Models.Employees;
using Newtonsoft.Json;
using Seido.Utilities.SeedGenerator;

Console.WriteLine("Hello, Linq!");

// var seeder = new SeedGenerator();
// var employees = seeder.ItemsToList<Employee>(100);
// System.Console.WriteLine($"Generated {employees.Count} employees.");

// SerializeJson("employees.json", employees);

var emp = DeSerializeJson("employees.json");  
Console.WriteLine($"Deserialized {emp.Count} employees from JSON.");

emp.ToList().ForEach(e => System.Console.WriteLine($"{e.FirstName} {e.LastName}"));

// Existing example: veterinarians, Where!
var vets = emp.Where(e => e.Role == WorkRole.Veterinarian);
 vets.ToList().ForEach(v =>
            System.Console.WriteLine($"Vet: {v.FirstName} {v.LastName}, Hired: {v.HireDate:d}, Cards: {v.CreditCards.Count}")
        );

//vets Ordered hiring date
System.Console.WriteLine();
var orderedByHire = vets.OrderByDescending(e => e.HireDate);
 orderedByHire.ToList().ForEach(v =>
            System.Console.WriteLine($"Vet: {v.FirstName} {v.LastName}, Hired: {v.HireDate:d}, Cards: {v.CreditCards.Count}")
        );

//5 earliest employed vets
System.Console.WriteLine("Earliest");  
vets.OrderBy(e => e.HireDate).Take(5)
.ToList().ForEach(v =>
            System.Console.WriteLine($"Vet: {v.FirstName} {v.LastName}, Hired: {v.HireDate:d}, Cards: {v.CreditCards.Count}")
        );


System.Console.WriteLine("Latest");  
//5 latest employed vets  
vets.OrderBy(e => e.HireDate).TakeLast(5)
.ToList().ForEach(v =>
            System.Console.WriteLine($"Vet: {v.FirstName} {v.LastName}, Hired: {v.HireDate:d}, Cards: {v.CreditCards.Count}")
        );


// TakeWhile: order by HireDate then take while hired before 2010
System.Console.WriteLine("Before 2010");
vets.OrderBy(e => e.HireDate).TakeWhile(e => e.HireDate.Year < 2010)
.ToList().ForEach(v =>
            System.Console.WriteLine($"Vet: {v.FirstName} {v.LastName}, Hired: {v.HireDate:d}, Cards: {v.CreditCards.Count}")
        );


System.Console.WriteLine("Select");
var res = vets.OrderBy(e => e.HireDate).TakeWhile(e => e.HireDate.Year < 2010).Select(e => $"{e.FirstName} {e.LastName}");
res.ToList().ForEach(System.Console.WriteLine);


System.Console.WriteLine("SelectMany CreditCards");
var res1 = vets.OrderBy(e => e.HireDate).TakeWhile(e => e.HireDate.Year < 2010).SelectMany(e => e.CreditCards);
res1.ToList().ForEach(c => System.Console.WriteLine($"{c.Issuer}: {c.Number}"));

System.Console.WriteLine("Distinct CreditCards");
var res2 = vets.OrderBy(e => e.HireDate).TakeWhile(e => e.HireDate.Year < 2010).SelectMany(e => e.CreditCards).DistinctBy(c => c.Issuer);
res2.ToList().ForEach(c => System.Console.WriteLine($"{c.Issuer}"));


System.Console.WriteLine("\nGroup by Role");
var res3 = emp.GroupBy(e=> e.Role);
foreach (var item in res3)
{
    System.Console.WriteLine($"-----{item.Key}: {item.Count()}");
    var names = item.Select(e => $"{e.FirstName} {e.LastName}");
    names.ToList().ForEach(System.Console.WriteLine);

}







//Serialization Helpers
void SerializeJson(string jsonFileName, List<Employee> list)
{
    string sJson = JsonConvert.SerializeObject(list, Formatting.Indented);

    using (Stream s = File.Create(fname(jsonFileName)))
    using (TextWriter writer = new StreamWriter(s))
        writer.Write(sJson);
}
static List<Employee> DeSerializeJson(string jsonFileName)
{
    using (Stream s = File.OpenRead(fname(jsonFileName)))
    using (TextReader reader = new StreamReader(s))
    {
        var flist = JsonConvert.DeserializeObject<List<Employee>>(reader.ReadToEnd());
        return flist;
    }
}

static string fname(string name)
{
    var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    documentPath = Path.Combine(documentPath, "CodeSessions", "Linq");
    if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
    return Path.Combine(documentPath, name);
}

