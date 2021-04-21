using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Lambda3.Games.Core.Models;
using Lambda3.Games.Core.Services;
using Lambda3.Games.Core.Validators;
using Microsoft.Extensions.Logging;

namespace Lambda3.Games.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly GameService _gameService;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
            _gameService = new GameService();
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
