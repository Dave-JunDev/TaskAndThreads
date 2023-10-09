using TaskAndThreads.Interfaces;
using TaskAndThreads.DTO;

namespace TaskAndThreads.Services;
public class PersonService : IPersonService
{
    private readonly IFileService _fileService;
    public PersonService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public async Task CreatePersonsAsync(List<Person> people, string groupId)
    {
        if(people.Count <= 0)
            throw new Exception("The list of persons is 0");

        await Task.Delay(100);

        _fileService.SaveInformation(people, groupId);
    }

    public Response<Person> CreatePersons(List<Person> people)
    {
        if(people.Count <= 0)
            throw new Exception("The list of persons is 0");

        Response<Person> response = new();
        string groupId = Guid.NewGuid().ToString();
        response.GroupId = groupId;

        _fileService.SaveInformation(people, groupId);

        response.Code = 200;
        response.Message = "Se guardo la informacion satisfactoriamente";
        response.Data = people;

        return response;
    }

    public Response<Person> ServiceCreate(List<Person> people)
    {
        Response<Person> response = new();
        string groupId = Guid.NewGuid().ToString();
        response.Message = "Verfique la creacion en";
        response.Code = 200;
        response.GroupId = groupId;

        var t = Task.Run(() => CreatePersonsAsync(people, groupId));

        return response;
    }
}