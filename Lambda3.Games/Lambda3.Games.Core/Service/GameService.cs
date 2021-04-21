using System.Collections.Generic;
using Lambda3.Games.Core.Model;
using System.Linq;

namespace Lambda3.Games.Core.Service
{
    public class GameService
    {
        public List<Game> ClassificarJogos(List<Game> jogos)
        {
            //if (jogos == null)
            //    throw new NullReferenceException("Lista de Games não pode estar vazia!");

            //if (jogos.Count() % 2 == 1)
            //    throw new Exception("A lista não pode ter Games impares!");

            //if (jogos.Count() > quantidadeMinimaParaListaDeGames)
            //    throw new Exception($"O minimo de games permitidos é {quantidadeMinimaParaListaDeGames}");

            jogos = jogos.OrderBy(g => g.Titulo).ToList();

            var classificados = new List<Game>();
            int indiceUltimosJogosDaLista = jogos.Count - 1;

            for (int i = 0; i < jogos.Count; i++)
            {
                CompararJogos(classificados, jogos[i], jogos[indiceUltimosJogosDaLista]);

                if ((indiceUltimosJogosDaLista - i) == 1)
                    break;

                indiceUltimosJogosDaLista--;
            }

            var segundoRound = new List<Game>();
            CompararJogos(segundoRound, classificados[0], classificados[1]);
            CompararJogos(segundoRound, classificados[2], classificados[3]);

            var final = new List<Game>();
            CompararJogos(final, segundoRound[0], segundoRound[1]);

            final.Add(segundoRound.FirstOrDefault(g => !(final.Contains(g))));

            return final;
        }

        private List<Game> CompararJogos(List<Game> jogos, Game primeiroJogador, Game segundoJogador)
        {
            if (primeiroJogador.Nota > segundoJogador.Nota)
                jogos.Add(primeiroJogador);
            else if (primeiroJogador.Nota == segundoJogador.Nota)
            {
                if (primeiroJogador.Ano == segundoJogador.Ano)
                {
                    var orderGames = new List<Game>() { primeiroJogador, segundoJogador };
                    jogos.Add(orderGames.OrderBy(e => e.Titulo).ToList()[0]);
                }
                else if (primeiroJogador.Ano > segundoJogador.Ano)
                    jogos.Add(primeiroJogador);
                else
                    jogos.Add(segundoJogador);
            }
            else
                jogos.Add(segundoJogador);

            return jogos;
        }

    }
}

