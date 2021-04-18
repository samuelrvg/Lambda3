using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Lambda3.Games.Console
{
    public class Games
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public double Nota { get; set; }
        public int Ano { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var games = CriarGames();

            var gamesSelecionados = SelecionarOitoGamesDistintosParaDisputa(games).OrderBy(g => g.Titulo).ToList();

            //var primeiraFaseDeClassificacao = Classificacao(gamesSelecionados);
            //var segundaFaseDeClassificacao = Classificacao(primeiraFaseDeClassificacao);
            var classificacao = Classificacao(gamesSelecionados);

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

        public static List<Games> CriarGames()
        {
            var games = new List<Games>()
            {
                new Games() { Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
                new Games() { Id = "/playstation/tony-hawks-pro-skater-2", Titulo= "Tony Hawk's Pro Skater 2 (PS)", Nota=98.9, Ano = 2000 },
                new Games() { Id = "/playstation-3/grand-theft-auto-iv", Titulo= "Grand Theft Auto IV (PS3)", Nota=98.9, Ano = 2008 },
                new Games() { Id = "/dreamcast/soulcalibur", Titulo= "SoulCalibur (DC)", Nota=98.9, Ano = 1999 },
                new Games() { Id = "/wii/super-mario-galaxy", Titulo= "Super Mario Galaxy (WII)", Nota=97.9, Ano = 2007 },
                new Games() { Id = "/wii/super-mario-galaxy-2", Titulo= "Super Mario Galaxy 2 (WII)", Nota=97.9, Ano = 2010 },
                new Games() { Id = "/xbox-one/red-dead-redemption-2", Titulo= "Red Dead Redemption 2 (XONE)", Nota=97.9, Ano = 2018 },
                new Games() { Id = "/xbox-one/grand-theft-auto-v", Titulo= "Grand Theft Auto V (XONE)", Nota=97.9, Ano = 2014 },
                new Games() { Id = "/playstation-3/grand-theft-auto-v", Titulo= "Grand Theft Auto V (PS3)", Nota=97.9, Ano = 2013 },
                new Games() { Id = "/xbox-360/grand-theft-auto-v", Titulo= "Grand Theft Auto V (X360)", Nota=97.0, Ano = 2013 },
                new Games() { Id = "/dreamcast/tony-hawks-pro-skater-2", Titulo= "Tony Hawk's Pro Skater 2 (DC)", Nota=97.0, Ano = 2000 },
                new Games() { Id = "/switch/the-legend-of-zelda-breath-of-the-wild", Titulo= "The Legend of Zelda: Breath of the Wild (Switch)", Nota=97.8, Ano = 2017 },
                new Games() { Id = "/playstation-2/tony-hawks-pro-skater-3", Titulo= "Tony Hawk's Pro Skater 3 (PS2)", Nota=97.8, Ano = 2001 },
                new Games() { Id = "/nintendo-64/perfect-dark", Titulo= "Perfect Dark (N64)", Nota=97.8, Ano = 2000 },
                new Games() { Id = "/playstation-4/red-dead-redemption-2", Titulo= "Red Dead Redemption 2 (PS4)", Nota=97.8, Ano = 2018 },
                new Games() { Id = "/cube/metroid-prime", Titulo= "Metroid Prime (GC)", Nota=97.8, Ano = 2002 },
            };

            return games;
        }

        public static List<Games> SelecionarOitoGamesDistintosParaDisputa(List<Games> games)
        {
            List<Games> gamesSelecionados = null;
            if (games != null)
            {
                var random = new Random();
                gamesSelecionados = new List<Games>();
                for (int i = 0; i < games.ToList().Count(); i++)
                {
                    if (gamesSelecionados.Count() == 8)
                        break;

                    var indice = random.Next(0, games.Count());
                    var game = games[indice];

                    gamesSelecionados.Add(game);
                    games.Remove(game);
                }
            }

            return gamesSelecionados;
        }

        public static List<Games> Classificacao(List<Games> games)
        {
            if (games == null)
                throw new Exception("Lista de Games não pode estar vazia");

            Games game1 = null;
            Games game2 = null;
            int count = games.Count() - 1;

            List<Games> classificados = new List<Games>();

            for (int i = 0; i < games.ToList().Count(); i++)
            {
                game1 = games[i];
                game2 = games[count];

                if (game1.Nota == game2.Nota)
                {
                    if (game1.Ano == game2.Ano)
                    {
                        classificados.Add(games.OrderBy(e => e.Titulo).FirstOrDefault());
                    }
                    else if (game1.Ano > game2.Ano)
                        classificados.Add(game1);
                    else
                        classificados.Add(game2);
                }
                else if (game1.Nota > game2.Nota)
                {
                    classificados.Add(game1);
                }
                else
                    classificados.Add(game2);

                if ((count - i) == 1)
                    break;

                count--;
            }

            if(classificados.Count() == 1)
            {
                var segundoLugar = games.First(e => !classificados.Contains(e));
                classificados.Add(segundoLugar);
                return classificados;
            }

            return Classificacao(classificados);
        }

        //public static List<Games> ClassificacaoFinal(List<Games> finalistas)
        //{
        //    var classificacaoFinal = new List<Games>();
        //    var primeiroLugar = Classificacao(finalistas).FirstOrDefault();

        //    classificacaoFinal.Add(primeiroLugar);

        //    var segundoLugar = finalistas.Where(e => e.Id != primeiroLugar.Id).FirstOrDefault();
        //    classificacaoFinal.Add(segundoLugar);

        //    return classificacaoFinal;
        //}
    }
}
