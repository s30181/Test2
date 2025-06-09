using Newtonsoft.Json;

namespace Test2.DTOs;

public class ResponseDTO
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    
    public List<ResponseMatchDTO> Matches { get; set; }
}

public class ResponseMatchDTO
{
    public string Tournament { get; set; }
    public string Map { get; set; }
    public DateTime Date { get; set; }
    
    [JsonProperty(PropertyName = "MVPs")]
    public int MVPs { get; set; }
    public decimal Rating { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
}