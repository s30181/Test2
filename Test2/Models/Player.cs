using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class Player
{
    [Key]
    public int PlayerId { get; set; }
    
    [StringLength(50)]
    public string FirstName { get; set; }
    
    [StringLength(100)]
    public string LastName { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public ICollection<PlayerMatch> PlayerMatches { get; set; }
    
}