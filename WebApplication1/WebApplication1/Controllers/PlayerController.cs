using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/players")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet("{customerId}/matches")]
    public async Task<IActionResult> GetPlayerInfo(int playerId)
    {
        var result = await _playerService.GetPlayerInfoAsync(playerId);

        if (result == null)
        {
            return NotFound($"Player with ID {playerId} not found.");
        }

        return Ok(result);
    }
}