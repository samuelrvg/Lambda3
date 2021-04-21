using System.Collections.Generic;
using Lambda3.Games.Core.Model;
using System.Linq;

namespace Lambda3.Games.Core.Service
{
    public class GameService
    {
        private const int primeiroLugar = 1;
        private int quantidadeMinimaParaListaDeGames { get; set; } = 8;

        public List<Game> ClassificarJogos(List<Game> jogos)
        {
            //if (jogos == null)
            //    throw new NullReferenceException("Lista de Games não pode estar vazia!");

            //if (jogos.Count() % 2 == 1)
            //    throw new Exception("A lista não pode ter Games impares!");

            //if (jogos.Count() > quantidadeMinimaParaListaDeGames)
            //    throw new Exception($"O minimo de games permitidos é {quantidadeMinimaParaListaDeGames}");

            if (jogos.Count() == quantidadeMinimaParaListaDeGames)
                jogos = jogos.OrderBy(g => g.Titulo).ToList();

            Game primeiroJogador = null;
            Game segundoJogador = null;
            int indiceUltimosJogosDaLista = jogos.Count() - 1;

            var classificados = new List<Game>();

            for (int i = 0; i < jogos.ToList().Count(); i++)
            {
                primeiroJogador = jogos[i];
                segundoJogador = jogos[indiceUltimosJogosDaLista];

                if (primeiroJogador.Nota == segundoJogador.Nota && primeiroJogador.Ano == segundoJogador.Ano)
                {
                    var ordernaGames = new List<Game>() { primeiroJogador, segundoJogador };
                    classificados.Add(ordernaGames.OrderBy(e => e.Titulo).FirstOrDefault());
                }
                else if (primeiroJogador.Nota > segundoJogador.Nota || primeiroJogador.Ano > segundoJogador.Ano)
                    classificados.Add(primeiroJogador);
                else
                    classificados.Add(segundoJogador);

                if ((indiceUltimosJogosDaLista - i) == 1)
                    break;

                indiceUltimosJogosDaLista--;
            }

            if (classificados.Count() == primeiroLugar)
            {
                var segundoLugar = jogos.First(e => !classificados.Contains(e));
                classificados.Add(segundoLugar);

                return classificados;
            }

            return ClassificarJogos(classificados);
        }
    }
}
