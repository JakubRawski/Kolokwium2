using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IPlayerService
{
    Task<PlayerTournamentDto?> GetPlayerInfoAsync(int PlayerId);
    Task<(bool Success, string Message)> AddPlayerAsync(PlayerRequestDTO request);
}