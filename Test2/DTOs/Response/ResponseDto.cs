namespace Test2.DTOs;

public class ResponseDto
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    
    public List<ResponseMatchDto> Matches { get; set; }
}