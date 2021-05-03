using Lambda3.Games.Core.Models;
using System;
using System.Collections.Generic;

namespace Lambda3.Games.Core.Interfaces
{
    public interface IGameService
    {
        List<Game> ClassificarJogos(List<Game> jogos);
        List<Game> QuartasDeFinal(List<Game> jogos);
        List<Game> SemiFinal(List<Game> quartasDeFinal);
        List<Game> Final(List<Game> semiFinalistas);
        Tuple<Game, Game> Comparar(Game primeiroJogo, Game segundoJogo);
    }
}
