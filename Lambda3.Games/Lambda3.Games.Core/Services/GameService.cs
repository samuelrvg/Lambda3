using System;
using System.Collections.Generic;
using System.Linq;
using Lambda3.Games.Core.Models;

namespace Lambda3.Games.Core.Services
{
    public class GameService
    {
        public List<Game> ClassificarJogos(List<Game> jogos)
        {
            var quartasDeFinal = QuartasDeFinal(jogos);

            var semiFinal = SemiFinal(quartasDeFinal);

            return Final(semiFinal);
        }

        private List<Game> QuartasDeFinal(List<Game> jogos)
        {
            var quartasDeFinal = new List<Game>();

            var listaJogosPorTitulo = jogos.OrderBy(g => g.Titulo).ToList();

            int indiceUltimosJogosDaLista = listaJogosPorTitulo.Count - 1;

            for (int i = 0; i < listaJogosPorTitulo.Count; i++)
            {
                quartasDeFinal.Add(Comparar(listaJogosPorTitulo[i], listaJogosPorTitulo[indiceUltimosJogosDaLista]).Item1);

                if ((indiceUltimosJogosDaLista - i) == 1)
                    break;

                indiceUltimosJogosDaLista--;
            }

            return quartasDeFinal;
        }

        private List<Game> SemiFinal(List<Game> quartasDeFinal)
        {
            var semiFinal = new List<Game>();

            var primeiroFinalista = Comparar(quartasDeFinal[0], quartasDeFinal[1]).Item1;
            var segundoFinalista = Comparar(quartasDeFinal[2], quartasDeFinal[3]).Item1;

            semiFinal.Add(primeiroFinalista);
            semiFinal.Add(segundoFinalista);

            return semiFinal;
        }

        private List<Game> Final(List<Game> semiFinalistas)
        {
            var finalistas = new List<Game>();

            var primeiroESegundoLugar = Comparar(semiFinalistas[0], semiFinalistas[1]);

            finalistas.Add(primeiroESegundoLugar.Item1);
            finalistas.Add(primeiroESegundoLugar.Item2);

            return finalistas;
        }

        public Tuple<Game, Game> Comparar(Game primeiroJogo, Game segundoJogo)
        {
            if (primeiroJogo.Nota > segundoJogo.Nota)
                return new Tuple<Game, Game>(primeiroJogo, segundoJogo);

            if (primeiroJogo.Nota == segundoJogo.Nota)
            {
                if (primeiroJogo.Ano > segundoJogo.Ano)
                    return new Tuple<Game, Game>(primeiroJogo, segundoJogo);

                if (primeiroJogo.Ano == segundoJogo.Ano)
                {
                    if (string.Compare(primeiroJogo.Titulo, segundoJogo.Titulo, StringComparison.InvariantCulture) < 0)
                        return new Tuple<Game, Game>(primeiroJogo, segundoJogo);

                    return new Tuple<Game, Game>(segundoJogo, primeiroJogo);
                }
            }

            return new Tuple<Game, Game>(segundoJogo, primeiroJogo);
        }
    }
}

