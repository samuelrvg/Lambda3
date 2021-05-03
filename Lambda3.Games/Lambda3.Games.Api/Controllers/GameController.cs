using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Lambda3.Games.Core.Models;
using Lambda3.Games.Core.Validators;
using Microsoft.Extensions.Logging;
using Lambda3.Games.Core.Interfaces;

namespace Lambda3.Games.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IGameService _gameService;

        public GameController(ILogger<GameController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<Game> games)
        {
            _logger.LogInformation("test log information");

            GameValidator validator = new GameValidator();
            var validateListGames = validator.Validate(games);

            if (validateListGames.IsValid)
            {
                var finalistas = _gameService.ClassificarJogos(games);

                return Ok(finalistas);
            }

            return BadRequest(validateListGames.Errors);
        }
    }
}
