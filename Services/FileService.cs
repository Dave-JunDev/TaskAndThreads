using System.Text.Json;
using TaskAndThreads.DTO;
using TaskAndThreads.Interfaces;

namespace TaskAndThreads.Services;

public class FileService : IFileService
{

    public void SaveInformation(List<Person> people, string groupId)
    {

        List<Person> data = new List<Person>();
        string currentDirectory = Directory.GetCurrentDirectory();
        string file = Path.Combine(currentDirectory, "file/BD.json");
        string information = File.ReadAllText(file);

        data = JsonSerializer.Deserialize<List<Person>>(information)!;

        foreach(Person person in people)
        {
            person.Id = groupId;
            data.Add(person);
        }

        using (StreamWriter sw = new StreamWriter(file))
        {
            string json = JsonSerializer.Serialize<List<Person>>(data);
            sw.WriteLine(json);
            sw.Flush();
        }
    }

    public List<Person> SearchInformation(string id)
    {
        List<Person> person = new List<Person>();
        string currentDirectory = Directory.GetCurrentDirectory();
        string file = Path.Combine(currentDirectory, "file/BD.json");
        string information = File.ReadAllText(file);

        person = JsonSerializer.Deserialize<List<Person>>(information)!;

        return person.FindAll(x => x.Id == id).ToList();
    }
}
