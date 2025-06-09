namespace Test2.DTOs;

public class RequestDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<MatchRequestDTO> Matches { get; set; }
    
}

public class MatchRequestDTO
{
    public int MatchId { get; set; }
    public int MVPs {get; set;}
    public decimal Rating { get; set; }
}