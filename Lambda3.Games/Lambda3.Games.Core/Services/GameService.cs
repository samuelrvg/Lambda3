using System.Collections.Generic;
using System.Linq;
using Lambda3.Games.Core.Models;

namespace Lambda3.Games.Core.Services
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

            var quartasDeFinal = new List<Game>();
            int indiceUltimosJogosDaLista = jogos.Count - 1;

            for (int i = 0; i < jogos.Count; i++)
            {
                CompararJogos(quartasDeFinal, jogos[i], jogos[indiceUltimosJogosDaLista]);

                if ((indiceUltimosJogosDaLista - i) == 1)
                    break;

                indiceUltimosJogosDaLista--;
            }

            var semiFinal = new List<Game>();
            CompararJogos(semiFinal, quartasDeFinal[0], quartasDeFinal[2]);
            CompararJogos(semiFinal, quartasDeFinal[1], quartasDeFinal[3]);

            var final = new List<Game>();
            CompararJogos(final, semiFinal[0], semiFinal[1]);

            final.Add(semiFinal.FirstOrDefault(g => !(final.Contains(g))));

            return final;
        }

        public List<Game> CompararJogos(List<Game> jogos, Game primeiroJogador, Game segundoJogador)
        {
            if (primeiroJogador.Nota > segundoJogador.Nota)
                jogos.Add(primeiroJogador);
            else if (primeiroJogador.Nota == segundoJogador.Nota)
            {
                if (primeiroJogador.Ano == segundoJogador.Ano)
                {
                    var orderGames = new List<Game>() { primeiroJogador, segundoJogador };
                    jogos.Add(orderGames.OrderBy(g => g.Titulo).ToList()[0]);
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

