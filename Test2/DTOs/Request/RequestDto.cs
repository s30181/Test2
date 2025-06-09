namespace Test2.DTOs;

public class RequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<MatchRequestDto> Matches { get; set; }
}