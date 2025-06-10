using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
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
    [HttpPost]
    public async Task<IActionResult> AddPlayer([FromBody] PlayerRequestDTO playerRequest)
    {
        var (success, errorMessage) = await _playerService.AddPlayerAsync(playerRequest);
    
        if (!success)
        {
            if (errorMessage!.Contains("exists")) // Simple check for conflict
            { return Conflict(errorMessage);
            }
            return BadRequest(errorMessage);
        }
            
        return CreatedAtAction(nameof(AddPlayer), new { id = GetPlayerInfo(playerRequest.Players.PlayerId) }, null);
    }
}