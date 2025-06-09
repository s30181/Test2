using Microsoft.AspNetCore.Mvc;
using Test2.DTOs;
using Test2.Exceptions;
using Test2.Services;
using Test2.Models;

namespace Test2.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private PlayerService _playerService;
    
    public PlayersController(PlayerService playerService)
    {
        _playerService = playerService;
    }
    
    [HttpGet("{id:int}/matches")]
    public async Task<IActionResult> Get(int id)
    {
        var player = await _playerService.Get(id);

        if (player == null)
        {
            return NotFound();
        }
        
        return Ok(player);
    }

    [HttpPost]
    public async Task<IActionResult> Post(RequestDto player)
    {
        try
        {
            await _playerService.Create(player);
            
            return Created();
        }
        catch (MatchNotExistsException e)
        {
            return BadRequest(e.Message);
        }

    }
}