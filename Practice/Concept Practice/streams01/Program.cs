using System.Numerics;
using System.Text.Json;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        // dynamic/anonymous object occupying RAM i.e. an in-memory object!
        var jsonObject = new { Name = "Alice", Age = 18 }; 

        // converts that object into json string (json is always string just a different format)
        string json = JsonSerializer.Serialize(jsonObject);
        string jsonString = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
        Console.WriteLine(jsonString);
        Console.WriteLine(json);

        Console.WriteLine(jsonObject);
    }
}