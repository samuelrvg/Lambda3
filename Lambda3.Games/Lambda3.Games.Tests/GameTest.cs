using Lambda3.Games.Core.Model;
using Lambda3.Games.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lambda3.Games.Tests
{
    [TestClass]
    public class GameTest
    {
        private List<Game> GamesComNotasIguaisEAnosDiferentes { get; set; }
        private List<Game> GamesComNotasEAnoIguais { get; set; }
        private List<Game> GamesComNotaMaior { get; set; }
        private List<Game> Jogos { get; set; }
        private GameService _gameService { get; set; }

        [TestInitialize]
        public void InitTests()
        {
            _gameService = new GameService();

            GamesComNotasIguaisEAnosDiferentes = new List<Game>();

            GamesComNotasEAnoIguais = new List<Game>();

            GamesComNotaMaior = new List<Game>();

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

            var games = _gameService.CompararJogos(GamesComNotasIguaisEAnosDiferentes, new Game() { Nota = 98.9, Ano = 2000 }, new Game() { Nota = 98.9, Ano = 2001 });

            Assert.AreEqual(JsonConvert.SerializeObject(mockGameTest), JsonConvert.SerializeObject(games[0]));
        }

        [TestMethod]
        public void GamesComNotasEAnoIguaisTest()
        {
            var mockGameTest = new Game() { Nota = 97, Ano = 2000, Titulo = "A" };

            var games = _gameService.CompararJogos(GamesComNotasEAnoIguais, new Game() { Nota = 97, Ano = 2000, Titulo = "B" }, new Game() { Nota = 97, Ano = 2000, Titulo = "A" });

            Assert.AreEqual(JsonConvert.SerializeObject(mockGameTest), JsonConvert.SerializeObject(games[0]));
        }

        [TestMethod]
        public void GamesComNotaMaiorTest()
        {
            var mockGameTest = new Game() { Nota = 99 };

            var games = _gameService.CompararJogos(GamesComNotaMaior, new Game() { Nota = 99 }, new Game() { Nota = 97 });

            Assert.AreEqual(JsonConvert.SerializeObject(mockGameTest), JsonConvert.SerializeObject(games[0]));
        }

        [TestMethod]
        public void ClassificarJogosTest()
        {
            var mockGameTest = new List<Game>()
            {
                new Game() { Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
                new Game() { Id = "/playstation-3/grand-theft-auto-iv", Titulo= "Grand Theft Auto IV (PS3)", Nota=98.9, Ano = 2008 },
            };

            var games = _gameService.ClassificarJogos(Jogos);

            Assert.AreEqual(JsonConvert.SerializeObject(mockGameTest), JsonConvert.SerializeObject(games));
        }

        //[TestMethod]
        //public void ClassificaoNaoPodeAceitarListaDeGamesImparesTest()
        //{
        //    var mockGameTest = new List<Game>()
        //    {
        //        new Game() {Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
        //        new Game() {Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
        //        new Game() {Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
        //    };

        //    Assert.ThrowsException<Exception>(() =>
        //    {
        //        _gameService.ClassificarJogos(mockGameTest);
        //    });
        //}

        //[TestMethod]
        //public void ListaDeGamesNaoPodeSerNullTest()
        //{
        //    List<Game> mockGameTest = null;

        //    Assert.ThrowsException<NullReferenceException>(() =>
        //    {
        //        _gameService.ClassificarJogos(mockGameTest);
        //    }, "Lista de Games não pode estar vazia");
        //}

        //[TestMethod]
        //public void MinimoDeGamesPermitidoParaIniciarJogoTest()
        //{
        //    Assert.ThrowsException<Exception>(() =>
        //    {
        //        _gameService.ClassificarJogos(MinimoPermitidoDeGames);
        //    });
        //}
    }
}
