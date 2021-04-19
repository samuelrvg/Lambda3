using Lambda3.Games.Dominio.Model;
using Lambda3.Games.Dominio.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Lambda3.Games.Tests
{
    [TestClass]
    public class GameTest
    {
        private List<Game> GamesComNotasIguais { get; set; }
        private List<Game> GamesComNotasEAnoIguais { get; set; }
        private List<Game> GamesComNotasIguaiEAnoDiferente { get; set; }
        private List<Game> GamesComNotaMaior { get; set; }
        private List<Game> ClassificaVencedores { get; set; }
        private List<Game> MinimoPermitidoDeGames { get; set; }
        private GameService _gameService { get; set; }

        [TestInitialize]
        public void InitTests()
        {
            _gameService = new GameService();

            GamesComNotasIguais = new List<Game>()
                    {
                        new Game() { Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=98.9, Ano = 1998 },
                        new Game() { Id = "/playstation/tony-hawks-pro-skater-2", Titulo= "Tony Hawk's Pro Skater 2 (PS)", Nota=98.9, Ano = 2000 },
                    };

            GamesComNotasEAnoIguais = new List<Game>()
                    {
                        new Game() { Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=98.9, Ano = 1998 },
                        new Game() { Id = "/dreamcast/soulcalibur", Titulo= "SoulCalibur (DC)", Nota=98.9, Ano = 1998 },
                    };

            GamesComNotasIguaiEAnoDiferente = new List<Game>()
                    {
                        new Game() { Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=98.9, Ano = 1998 },
                        new Game() { Id = "/dreamcast/soulcalibur", Titulo= "SoulCalibur (DC)", Nota=98.9, Ano = 2001 },
                    };

            GamesComNotaMaior = new List<Game>()
                    {
                        new Game() { Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=98.9, Ano = 1998 },
                        new Game() { Id = "/playstation/tony-hawks-pro-skater-2", Titulo= "Tony Hawk's Pro Skater 2 (PS)", Nota=99, Ano = 1998 },
                    };

            ClassificaVencedores = new List<Game>()
            {
                new Game() { Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
                new Game() { Id = "/dreamcast/soulcalibur", Titulo= "SoulCalibur (DC)", Nota=98.9, Ano = 1999 },
                new Game() { Id = "/wii/super-mario-galaxy", Titulo= "Super Mario Galaxy (WII)", Nota=97.9, Ano = 2007 },
                new Game() { Id = "/wii/super-mario-galaxy-2", Titulo= "Super Mario Galaxy 2 (WII)", Nota=97.9, Ano = 2010 },

            };

            MinimoPermitidoDeGames = new List<Game>()
            {
                new Game() { Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
                new Game() { Id = "/dreamcast/soulcalibur", Titulo= "SoulCalibur (DC)", Nota=98.9, Ano = 1999 },
                new Game() { Id = "/wii/super-mario-galaxy", Titulo= "Super Mario Galaxy (WII)", Nota=97.9, Ano = 2007 },
                new Game() { Id = "/wii/super-mario-galaxy-2", Titulo= "Super Mario Galaxy 2 (WII)", Nota=97.9, Ano = 2010 },
                new Game() { Id = "/dreamcast/tony-hawks-pro-skater-2", Titulo= "Tony Hawk's Pro Skater 2 (DC)", Nota=97.0, Ano = 2000 },
                new Game() { Id = "/switch/the-legend-of-zelda-breath-of-the-wild", Titulo= "The Legend of Zelda: Breath of the Wild (Switch)", Nota=97.8, Ano = 2017 },
                new Game() { Id = "/nintendo-64/perfect-dark", Titulo= "Perfect Dark (N64)", Nota=97.8, Ano = 2000 },
                new Game() { Id = "/cube/metroid-prime", Titulo= "Metroid Prime (GC)", Nota=97.8, Ano = 2002 },
                new Game() { Id = "/wii/super-mario-galaxy-2", Titulo= "Super Mario Galaxy 2 (WII)", Nota=97.9, Ano = 2010 },
            };
        }

        [TestMethod]
        public void GamesComNotasIguaisTest()
        {
            var mockGameTest = new Game() { Id = "/playstation/tony-hawks-pro-skater-2", Titulo = "Tony Hawk's Pro Skater 2 (PS)", Nota = 98.9, Ano = 2000 };

            var games = _gameService.ClassificarGames(GamesComNotasIguais);

            Assert.AreEqual(JsonConvert.SerializeObject(mockGameTest), JsonConvert.SerializeObject(games[0]));
        }

        [TestMethod]
        public void GamesComNotasEAnoIguaisTest()
        {
            var mockGameTest = new Game() { Id = "/dreamcast/soulcalibur", Titulo = "SoulCalibur (DC)", Nota = 98.9, Ano = 1998 };

            var games = _gameService.ClassificarGames(GamesComNotasEAnoIguais);

            Assert.AreEqual(JsonConvert.SerializeObject(mockGameTest), JsonConvert.SerializeObject(games[0]));
        }

        [TestMethod]
        public void GamesComNotasIguaiEAnoDiferenteTest()
        {
            var mockGameTest = new List<Game>()
                    {
                        new Game() { Id = "/dreamcast/soulcalibur", Titulo= "SoulCalibur (DC)", Nota=98.9, Ano = 2001 },
                        new Game() { Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=98.9, Ano = 1998 },
                    };

            var games = _gameService.ClassificarGames(GamesComNotasIguaiEAnoDiferente);

            Assert.AreEqual(JsonConvert.SerializeObject(mockGameTest), JsonConvert.SerializeObject(games));
        }

        [TestMethod]
        public void GamesComNotaMaiorTest()
        {
            var mockGameTest = new Game() { Id = "/playstation/tony-hawks-pro-skater-2", Titulo = "Tony Hawk's Pro Skater 2 (PS)", Nota = 99, Ano = 1998 };

            var games = _gameService.ClassificarGames(GamesComNotaMaior);

            Assert.AreEqual(JsonConvert.SerializeObject(mockGameTest), JsonConvert.SerializeObject(games[0]));
        }

        [TestMethod]
        public void ClassificaVencedoresTest()
        {
            var mockGameTest = new List<Game>()
            {
                new Game() {Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
                new Game() {Id = "/dreamcast/soulcalibur", Titulo= "SoulCalibur (DC)", Nota=98.9, Ano = 1999 },
            };

            var finalistas = _gameService.ClassificarGames(ClassificaVencedores);

            Assert.AreEqual(JsonConvert.SerializeObject(mockGameTest), JsonConvert.SerializeObject(finalistas));
        }

        [TestMethod]
        public void ClassificaoNaoPodeAceitarListaDeGamesImparesTest()
        {
            var mockGameTest = new List<Game>()
            {
                new Game() {Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
                new Game() {Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
                new Game() {Id = "/nintendo-64/the-legend-of-zelda-ocarina-of-time", Titulo= "The Legend of Zelda: Ocarina of Time (N64)", Nota=99.9, Ano = 1998 },
            };

            Assert.ThrowsException<Exception>(() =>
            {
                _gameService.ClassificarGames(mockGameTest);
            });
        }

        [TestMethod]
        public void ListaDeGamesNaoPodeSerNullTest()
        {
            List<Game> mockGameTest = null;

            Assert.ThrowsException<NullReferenceException>(() =>
            {
                _gameService.ClassificarGames(mockGameTest);
            }, "Lista de Games não pode estar vazia");
        }

        [TestMethod]
        public void MinimoDeGamesPermitidoParaIniciarJogoTest()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                _gameService.ClassificarGames(MinimoPermitidoDeGames);
            });
        }
    }
}
