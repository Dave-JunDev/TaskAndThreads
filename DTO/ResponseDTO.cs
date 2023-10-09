namespace TaskAndThreads.DTO;

public class Response<T>
{
    public int Code {get; set;}
    public string? Message {get; set;}
    public List<T>? Data {get; set;}
    public string? GroupId {get; set;}
}