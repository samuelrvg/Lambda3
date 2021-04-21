using Lambda3.Games.Core.Model;
using Lambda3.Games.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Lambda3.Games.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameService = new GameService();
            var games = CriarGames();

            var gamesSelecionados = SelecionarOitoGamesDistintosParaDisputa(games);

            var classificacao = gameService.ClassificarJogos(gamesSelecionados);

            WriteLine("-------PRIMEIRO LUGAR-------");
            WriteLine("Titulo: {0}", classificacao[0].Titulo);
            WriteLine("Nota: {0}", classificacao[0].Nota);
            WriteLine("Ano: {0}", classificacao[0].Ano);

            WriteLine("-------SEGUNDO LUGAR-------");
            WriteLine("Titulo: {0}", classificacao[1].Titulo);
            WriteLine("Nota: {0}", classificacao[1].Nota);
            WriteLine("Ano: {0}", classificacao[1].Ano);

            ReadKey();
        }

        public static List<Game> CriarGames()
        {
            var games = new List<Game>()
            {
                new Game() { Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
                new Game() { Id = "/playstation/tony-hawks-pro-skater-2", Titulo= "Tony Hawk's Pro Skater 2 (PS)", Nota=98.9, Ano = 2000 },
                new Game() { Id = "/playstation-3/grand-theft-auto-iv", Titulo= "Grand Theft Auto IV (PS3)", Nota=98.9, Ano = 2008 },
                new Game() { Id = "/dreamcast/soulcalibur", Titulo= "SoulCalibur (DC)", Nota=98.9, Ano = 1999 },
                new Game() { Id = "/wii/super-mario-galaxy", Titulo= "Super Mario Galaxy (WII)", Nota=97.9, Ano = 2007 },
                new Game() { Id = "/wii/super-mario-galaxy-2", Titulo= "Super Mario Galaxy 2 (WII)", Nota=97.9, Ano = 2010 },
                new Game() { Id = "/xbox-one/red-dead-redemption-2", Titulo= "Red Dead Redemption 2 (XONE)", Nota=97.9, Ano = 2018 },
                new Game() { Id = "/xbox-one/grand-theft-auto-v", Titulo= "Grand Theft Auto V (XONE)", Nota=97.9, Ano = 2014 },
                new Game() { Id = "/playstation-3/grand-theft-auto-v", Titulo= "Grand Theft Auto V (PS3)", Nota=97.9, Ano = 2013 },
                new Game() { Id = "/xbox-360/grand-theft-auto-v", Titulo= "Grand Theft Auto V (X360)", Nota=97.0, Ano = 2013 },
                new Game() { Id = "/dreamcast/tony-hawks-pro-skater-2", Titulo= "Tony Hawk's Pro Skater 2 (DC)", Nota=97.0, Ano = 2000 },
                new Game() { Id = "/switch/the-legend-of-zelda-breath-of-the-wild", Titulo= "The Legend of Zelda: Breath of the Wild (Switch)", Nota=97.8, Ano = 2017 },
                new Game() { Id = "/playstation-2/tony-hawks-pro-skater-3", Titulo= "Tony Hawk's Pro Skater 3 (PS2)", Nota=97.8, Ano = 2001 },
                new Game() { Id = "/nintendo-64/perfect-dark", Titulo= "Perfect Dark (N64)", Nota=97.8, Ano = 2000 },
                new Game() { Id = "/playstation-4/red-dead-redemption-2", Titulo= "Red Dead Redemption 2 (PS4)", Nota=97.8, Ano = 2018 },
                new Game() { Id = "/cube/metroid-prime", Titulo= "Metroid Prime (GC)", Nota=97.8, Ano = 2002 },
            };

            return games;
        }

        public static List<Game> SelecionarOitoGamesDistintosParaDisputa(List<Game> jogos)
        {
            List<Game> jogosSelecionados = null;
            if (jogos != null)
            {
                var random = new Random();
                jogosSelecionados = new List<Game>();
                for (int i = 0; i < jogos.ToList().Count(); i++)
                {
                    if (jogosSelecionados.Count() == 8)
                        break;

                    var indice = random.Next(0, jogos.Count());
                    var jogo = jogos[indice];

                    jogosSelecionados.Add(jogo);
                    jogos.Remove(jogo);
                }
            }

            return jogosSelecionados;
        }
    }
}
