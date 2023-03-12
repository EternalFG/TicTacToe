using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using TicTacToe.Services;

namespace TicTacToe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicTacToeController : ControllerBase
    {
        private readonly IPendingPlayers _pendingPlayers;
        private readonly IGameSessionService _gameSessionService;

        public TicTacToeController(IPendingPlayers pendingPlayers, IGameSessionService gameSessionService)
        {
            _pendingPlayers = pendingPlayers;
            _gameSessionService = gameSessionService;
        }

        [HttpPost("ready")]
        public async Task<IActionResult> SetReady()
        {
            if (User?.Identity?.IsAuthenticated == false || User?.IsInRole("Player") == false)
            {
                return Unauthorized();
            }

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _pendingPlayers.AddPlayerAsync(id);
            return Ok();
        }



        [HttpGet("checksession")]
        public async Task<IActionResult> CheckSession()
        {
            if (User?.Identity?.IsAuthenticated == false || User?.IsInRole("Player") == false)
            {
                return Unauthorized();
            }


            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ready = await _pendingPlayers.CheckPlayerAsync(id);
            var session = await _gameSessionService.FindPlayerSession(id);

            if (session != null)
            {
                return Ok("Session found: " + session.Value);
            }
            else if (ready == false)
            {
                return Forbid();
            }
            return Ok("Ожидаю соперника...");
        }



        [HttpPut("setmove")]
        public async Task<IActionResult> SetMove([FromQuery] int x, [FromQuery] int y)
        {
            if (User?.Identity?.IsAuthenticated == false || User?.IsInRole("Player") == false)
            {
                return Unauthorized();
            }

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var session = await _gameSessionService.FindPlayerSession(id);

            if (session != null)
            {
                var hasMoved = await _gameSessionService.TryMove(session.Value, id, x, y);
                if (hasMoved.Item1 != string.Empty)
                {
                    return Ok($"Победа {hasMoved.Item1}!");
                }
                if (hasMoved.Item2)
                {
                    return Ok("Успешно походили на клетку: " + x + ", " + y);
                }
                else
                {
                    return Ok("Что-то не так, ход противника или клетка занята.");
                }
            }
            return Ok("Вы не нашли игру!");
        }


        [HttpGet("drawmap")]
        public async Task<IActionResult> DrawMap()
        {
            if (User?.Identity?.IsAuthenticated == false || User?.IsInRole("Player") == false)
            {
                return Unauthorized();
            }

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var session = await _gameSessionService.FindPlayerSession(id);

            if (session != null)
            {
                var map = await _gameSessionService.GetMap(session.Value);

                var sb = new StringBuilder();
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    for (int x = 0; x < map.GetLength(0); x++)
                    {
                        var symbol = map[x, y];
                        sb.Append(symbol?.ToString() + " " ?? ". ");
                    }
                    sb.AppendLine();
                }

                return Ok(sb.ToString());
            }
            return Ok("Вы не нашли игру!");
        }

    }
}
