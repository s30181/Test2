using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Test2.DTOs;

public class ResponseMatchDto
{
    public string Tournament { get; set; }
    public string Map { get; set; }
    public DateTime Date { get; set; }
    
    [JsonPropertyName("MVPs")]
    public int MVPs { get; set; }
    public decimal Rating { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
}