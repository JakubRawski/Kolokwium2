using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class PlayerService : IPlayerService
{
        private readonly ApplicationDbContext _context;

        public PlayerService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<PlayerTournamentDto> GetPlayerInfoAsync(int PlayerId)
        {
            var player = await _context.Players
                .Select(e => new PlayerTournamentDto()
                {
                    PlayerId = e.PlayerId,
                    Firstname = e.Firstname,
                    Lastname = e.Lastname,
                    BirthDate = e.BirthDate,
                    Matches = new List<MatchDto>()
                    .ToList()
                })
                .FirstOrDefaultAsync(e => e.PlayerId == PlayerId);

            if (player is null)
                throw new NotFoundException();
        
            return player;

        }

        public async Task<(bool Success, string Message)> AddPlayerAsync(PlayerRequestDTO request)
        {
            var player = await _context.Players.FirstOrDefaultAsync(c => c.PlayerId == request.Players.PlayerId);

            if (player != null)
            {
                return (false, "Player with the provided ID already exists.");
            }

            player = new Player
            {
                PlayerId = request.Players.PlayerId,
                Firstname = request.Players.Firstname,
                Lastname = request.Players.Lastname,
                BirthDate = request.Players.BirthDate
            };

            _context.Players.Add(player);

            foreach (var play in request.Players)
            {
                //tu mial byc warunek ale zabraklo czasu

            }

            await _context.SaveChangesAsync();

            return (true, "Player added successfully.");
        }
        
}

