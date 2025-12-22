// See https://aka.ms/new-console-template for more information
using Models.Employees;
using Newtonsoft.Json;
using Seido.Utilities.SeedGenerator;

Console.WriteLine("Hello, Linq!");

var seeder = new SeedGenerator();
var employees = seeder.ItemsToList<Employee>(100);
System.Console.WriteLine($"Generated {employees.Count} employees.");

SerializeJson("employees.json", employees);
var deserializedEmployees = DeSerializeJson("employees.json");  
Console.WriteLine($"Deserialized {deserializedEmployees.Count} employees from JSON.");





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

