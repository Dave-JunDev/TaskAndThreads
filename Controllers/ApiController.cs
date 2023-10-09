using Microsoft.AspNetCore.Mvc;
using TaskAndThreads.DTO;
using TaskAndThreads.Interfaces;
using TaskAndThreads.Services;

namespace TaskAndThreads.Controller;

[Route("[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    private readonly IPersonService _personService;
    private readonly IFileService _fileService;
    public ApiController(IPersonService personService, IFileService fileService)
    {
        _personService = personService;
        _fileService = fileService;
    }

    [HttpPost("CreatePeople")]
    public Response<Person> CreatePeople(List<Person> people)
    {
        Response<Person> response = new();
        if(people.Count > 5)
            response = _personService.ServiceCreate(people);
        else
            response = _personService.CreatePersons(people);

        return response;
    }

    [HttpGet("GetInformation/{id}")]
    public List<Person> SearchPersons(string id)
    {
        return _fileService.SearchInformation(id);
    }
}