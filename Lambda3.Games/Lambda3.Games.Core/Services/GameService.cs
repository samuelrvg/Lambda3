﻿using System;
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

            jogos = jogos.OrderBy(g => g.Titulo).ToList();

            int indiceUltimosJogosDaLista = jogos.Count - 1;

            for (int i = 0; i < jogos.Count; i++)
            {
                quartasDeFinal.Add(Comparar(jogos[i], jogos[indiceUltimosJogosDaLista]).Item1);

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

            var finalista = Comparar(semiFinalistas[0], semiFinalistas[1]).Item1;

            finalistas.Add(finalista);
            finalistas.Add(semiFinalistas.FirstOrDefault(g => !(finalistas.Contains(g))));

            return finalistas;
        }

        public Tuple<Game, Game> Comparar(Game primeiroJogador, Game segundoJogador)
        {
            if (primeiroJogador.Nota > segundoJogador.Nota)
                return new Tuple<Game, Game>(primeiroJogador, segundoJogador);

            if (primeiroJogador.Nota == segundoJogador.Nota)
            {
                if (primeiroJogador.Ano > segundoJogador.Ano)
                    return new Tuple<Game, Game>(primeiroJogador, segundoJogador);

                if (primeiroJogador.Ano == segundoJogador.Ano)
                {
                    if (string.Compare(primeiroJogador.Titulo, segundoJogador.Titulo, StringComparison.InvariantCulture) < 0)
                        return new Tuple<Game, Game>(primeiroJogador, segundoJogador);

                    return new Tuple<Game, Game>(segundoJogador, primeiroJogador);
                }
            }

            return new Tuple<Game, Game>(segundoJogador, primeiroJogador);
        }
    }
}

