﻿using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class Map
{
    [Key]
    public int MapId { get; set; }
    
    [StringLength(100)]
    public string Name { get; set; }
    
    [StringLength(100)]
    public string Type { get; set; }
    
    public ICollection<Match> Matches { get; set; }
}