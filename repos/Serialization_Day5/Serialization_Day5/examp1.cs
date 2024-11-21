using System;
using System.IO;
using System.Text.Json;
//using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization_Day5;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
internal class Program
{
      
    /*private static void Main(string[] args)
    {
        Person person = new Person { Name = "Alice", Age = 30 };
        string jsonString = JsonSerializer.Serialize(person);
        File.WriteAllText("person.json", jsonString);
        Console.WriteLine(jsonString);


        jsonString = File.ReadAllText("Person.json");
        Person deserializedPerson = JsonSerializer.Deserialize<Person>(jsonString);
        Console.WriteLine(JsonSerializer.Serialize(deserializedPerson));







    }*/
}