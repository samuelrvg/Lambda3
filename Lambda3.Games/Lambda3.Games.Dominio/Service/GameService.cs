using System;
using System.Collections.Generic;
using Lambda3.Games.Dominio.Model;
using System.Linq;

namespace Lambda3.Games.Dominio.Service
{
    public class GameService
    {
        private const int primeiroLugar = 1;
        public int quantidadeMinimaParaListaDeGames { get; private set; } = 8;

        public List<Game> ClassificarGames(List<Game> games)
        {
            if (games == null)
                throw new NullReferenceException("Lista de Games não pode estar vazia!");

            if (games.Count() % 2 == 1)
                throw new Exception("A lista não pode ter Games impares!");

            if (games.Count() > quantidadeMinimaParaListaDeGames)
                throw new Exception($"O minimo de games permitidos é {quantidadeMinimaParaListaDeGames}");

            if (games.Count() == quantidadeMinimaParaListaDeGames)
                games = games.OrderBy(g => g.Titulo).ToList();

            Game game1 = null;
            Game game2 = null;
            int indiceUltimosGamesDaLista = games.Count() - 1;

            var classificados = new List<Game>();

            for (int i = 0; i < games.ToList().Count(); i++)
            {
                game1 = games[i];
                game2 = games[indiceUltimosGamesDaLista];

                if (game1.Nota == game2.Nota && game1.Ano == game2.Ano)
                {
                    var ordernaGames = new List<Game>() { game1, game2 };
                    classificados.Add(ordernaGames.OrderBy(e => e.Titulo).FirstOrDefault());
                }
                else if (game1.Nota > game2.Nota || game1.Ano > game2.Ano)
                    classificados.Add(game1);
                else
                    classificados.Add(game2);

                if ((indiceUltimosGamesDaLista - i) == 1)
                    break;

                indiceUltimosGamesDaLista--;
            }

            if (classificados.Count() == primeiroLugar)
            {
                var segundoLugar = games.First(e => !classificados.Contains(e));
                classificados.Add(segundoLugar);

                return classificados;
            }

            return ClassificarGames(classificados);
        }
    }
}
