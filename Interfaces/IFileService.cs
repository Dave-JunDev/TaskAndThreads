using TaskAndThreads.DTO;

namespace TaskAndThreads.Interfaces;

public interface IFileService
{
    void SaveInformation(List<Person> people, string groupId);
    List<Person> SearchInformation(string id);
}