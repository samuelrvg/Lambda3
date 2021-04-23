using Lambda3.Games.Core.Models;
using Lambda3.Games.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lambda3.Games.Tests
{
    [TestClass]
    public class GameTest
    {
        private List<Game> Jogos { get; set; }
        private GameService _gameService { get; set; }

        [TestInitialize]
        public void InitTests()
        {
            _gameService = new GameService();

            Jogos = new List<Game>()
            {
                new Game() { Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
                new Game() { Id = "/playstation/tony-hawks-pro-skater-2", Titulo= "Tony Hawk's Pro Skater 2 (PS)", Nota=98.9, Ano = 2000 },
                new Game() { Id = "/playstation-3/grand-theft-auto-iv", Titulo= "Grand Theft Auto IV (PS3)", Nota=98.9, Ano = 2008 },
                new Game() { Id = "/dreamcast/soulcalibur", Titulo= "SoulCalibur (DC)", Nota=98.9, Ano = 1999 },
                new Game() { Id = "/wii/super-mario-galaxy", Titulo= "Super Mario Galaxy (WII)", Nota=97.9, Ano = 2007 },
                new Game() { Id = "/wii/super-mario-galaxy-2", Titulo= "Super Mario Galaxy 2 (WII)", Nota=97.9, Ano = 2010 },
                new Game() { Id = "/xbox-one/red-dead-redemption-2", Titulo= "Red Dead Redemption 2 (XONE)", Nota=97.9, Ano = 2018 },
                new Game() { Id = "/xbox-one/grand-theft-auto-v", Titulo= "Grand Theft Auto V (XONE)", Nota=97.9, Ano = 2014 },
            };
        }

        [TestMethod]
        public void GamesComNotasIguaisEAnosDiferentesTest()
        {
            var mockGameTest = new Game() { Nota = 98.9, Ano = 2001 };

            var game = _gameService.Comparar(new Game() { Nota = 98.9, Ano = 2000 }, new Game() { Nota = 98.9, Ano = 2001 }).Item1;

            Assert.AreEqual(JsonConvert.SerializeObject(mockGameTest), JsonConvert.SerializeObject(game));
        }

        [TestMethod]
        public void GamesComNotasEAnoIguaisTest()
        {
            var mockGameTest = new Game() { Nota = 97, Ano = 2000, Titulo = "A" };

            var game = _gameService.Comparar(new Game() { Nota = 97, Ano = 2000, Titulo = "B" }, new Game() { Nota = 97, Ano = 2000, Titulo = "A" }).Item1;

            Assert.AreEqual(JsonConvert.SerializeObject(mockGameTest), JsonConvert.SerializeObject(game));
        }

        [TestMethod]
        public void GamesComNotaMaiorTest()
        {
            var mockGameTest = new Game() { Nota = 99 };

            var game = _gameService.Comparar(new Game() { Nota = 99 }, new Game() { Nota = 97 }).Item1;

            Assert.AreEqual(JsonConvert.SerializeObject(mockGameTest), JsonConvert.SerializeObject(game));
        }

        [TestMethod]
        public void ClassificarJogosTest()
        {
            var mockGameTest = new List<Game>()
            {
                new Game() { Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
                new Game() { Id = "/dreamcast/soulcalibur", Titulo= "SoulCalibur (DC)", Nota=98.9, Ano = 1999 },
            };

            var games = _gameService.ClassificarJogos(Jogos);

            Assert.AreEqual(JsonConvert.SerializeObject(mockGameTest), JsonConvert.SerializeObject(games));
        }
    }
}
