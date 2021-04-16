using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Lambda3.Games.Dominio.Model;
using Lambda3.Games.Dominio.Service;

namespace Lambda3.Games.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            if (games == null)
                BadRequest();

            if(games.Count() == quantidadeMinimaParaListaDeGames)
            {
                var primeiroGrupo = _gameService.Classificacao(games.OrderBy(g => g.Titulo).ToList());
                var segundoGrupo = _gameService.Classificacao(primeiroGrupo);
                var finalistas = _gameService.ClassificacaoFinal(segundoGrupo);

                return Ok(finalistas);
            }

            return NotFound();
        }
    }
}
