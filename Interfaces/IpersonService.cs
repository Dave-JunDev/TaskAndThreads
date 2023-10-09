using TaskAndThreads.DTO;

namespace TaskAndThreads.Interfaces;
public interface IPersonService
{
    Task CreatePersonsAsync(List<Person> people, string groupId);
    Response<Person> CreatePersons(List<Person> people);
    Response<Person> ServiceCreate(List<Person> people);
}