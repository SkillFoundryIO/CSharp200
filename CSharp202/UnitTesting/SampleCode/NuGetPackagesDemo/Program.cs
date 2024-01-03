using Newtonsoft.Json;
using NuGetPackagesDemo;

var m = new Movie
{
    Title = "Star Wars",
    Rating = "PG",
    Year = 1977
};

string jsonString = JsonConvert.SerializeObject(m);
Console.WriteLine($"Serialized JSON: {jsonString}");

var deserialized = JsonConvert.DeserializeObject<Movie>(jsonString);
Console.WriteLine($"Deserialized Movie: Title = {deserialized.Title}, Rating = {deserialized.Rating}, Year={deserialized.Year}");