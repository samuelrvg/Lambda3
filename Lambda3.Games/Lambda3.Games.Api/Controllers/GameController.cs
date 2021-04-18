using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Lambda3.Games.Dominio.Model;
using Lambda3.Games.Dominio.Service;

namespace Lambda3.Games.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController()
        {
            _gameService = new GameService();
        }

        [HttpPost]
        public ActionResult<Game> Post([FromBody] List<Game> games)
        {
            try
            {
                if (games?.Count == _gameService.quantidadeMinimaParaListaDeGames)
                {
                    var finalistas = _gameService.Classificacao(games);
                    return Ok(finalistas);
                }

                return BadRequest();
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}
