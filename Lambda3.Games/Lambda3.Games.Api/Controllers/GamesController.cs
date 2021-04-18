using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Lambda3.Games.Dominio.Model;
using Lambda3.Games.Dominio.Service;

namespace Lambda3.Games.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly GameService _gameService;
        private const int quantidadeMinimaParaListaDeGames = 8;

        public GamesController()
        {
            _gameService = new GameService();
        }

        [HttpPost]
        public ActionResult<Game> Post([FromBody] List<Game> games)
        {
            try
            {
                if (games == null)
                    BadRequest();

                if (games.Count() == quantidadeMinimaParaListaDeGames)
                {
                    var finalistas = _gameService.Classificacao(games.OrderBy(g => g.Titulo).ToList());

                    return Ok(finalistas);
                }

                return NotFound();
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}
