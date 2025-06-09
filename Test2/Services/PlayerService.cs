using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.DTOs;
using Test2.Exceptions;
using Test2.Models;

namespace Test2.Services;

public class PlayerService
{
    private readonly DatabaseContext _context;
    
    public PlayerService(DatabaseContext context)
    {
        _context = context;
    }
    
    
    public async Task<ResponseDTO?> Get(int id)
    {
        var player = await _context.Players.Include(player => player.PlayerMatches)
            .ThenInclude(playerMatch => playerMatch.Match).ThenInclude(match => match.Tournament)
            .Include(player => player.PlayerMatches).ThenInclude(playerMatch => playerMatch.Match)
            .ThenInclude(match => match.Map).FirstOrDefaultAsync(player => player.PlayerId == id);

        if (player == null)
        {
            return null;
        }

        return new ResponseDTO()
        {
            PlayerId = player.PlayerId,
            FirstName = player.FirstName,
            LastName = player.LastName,
            BirthDate = player.BirthDate,
            Matches = player.PlayerMatches.Select(playerMatch => new ResponseMatchDTO()
            {
                Tournament = playerMatch.Match.Tournament.Name,
                Map = playerMatch.Match.Map.Name,
                Date = playerMatch.Match.MatchDate,
                MVPs = playerMatch.MVPs,
                Rating = playerMatch.Rating,
                Team1Score = playerMatch.Match.Team1Score,
                Team2Score = playerMatch.Match.Team2Score,
            }).ToList()
        };
    }
    

    public async Task Create(RequestDTO playerDto)
    {
        var matches = playerDto.Matches
            .Select(match => _context.Matches.FirstOrDefault(m => m.MatchId == match.MatchId))
            .ToList();

        if (matches.Any(match => match == null))
        {
            throw new MatchNotExists();
        }


        var player = new Player()
        {
            FirstName = playerDto.FirstName,
            LastName = playerDto.LastName,
            BirthDate = playerDto.BirthDate,
            PlayerMatches = playerDto.Matches.Select(match => new PlayerMatch()
                {
                    MatchId = match.MatchId,
                    Rating = match.Rating,
                    MVPs = match.MVPs,
                })
                .ToList()
        };

        matches.ForEach(match =>
        {
            var newRating = playerDto
                .Matches
                .FirstOrDefault(matchMatch => matchMatch.MatchId == match.MatchId)?.Rating;
            match.BestRating = newRating > match.BestRating ? newRating : match.BestRating;
        });
        
        await _context.Players.AddAsync(player);
        
        await _context.SaveChangesAsync();
        
    }
}