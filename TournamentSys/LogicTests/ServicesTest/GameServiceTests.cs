using LogicTests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.GameLogic;

namespace LogicTests.ServicesTest
{
    [TestClass]
    public class GameServiceTests
    {
        private readonly GameService _gameService;
        private readonly GameDto _game = new GameDto("1","2","1","10/22");

        public GameServiceTests()
        {
            _gameService = new GameService(new GameServiceMockData());
        }
        [TestMethod]
        public void CreateCorrectGame()
        {
            _gameService.Create(_game);
            Assert.IsNotNull(_gameService.GetOne(_game.Id));
        }
        [TestMethod]
        public void UpdateGameTest()
        {
            _gameService.Create(_game);
            var newGame = _game;
            newGame.Score = "1/30";

            _gameService.Update(_game);
            Assert.AreEqual(_gameService.GetOne(_game.Id).Score, "1/30");
        }
        [TestMethod]
        public void UpdateNoneExistingGameTest()
        {
            try
            {
                _gameService.Update(_game);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Game doesn't exist");
            }

        }
        [TestMethod]
        public void RemoveGameTest()
        {
            _gameService.Create(_game);

            _gameService.Delete(_game.Id);
            Assert.IsNull(_gameService.GetOne(_game.Id));
        }
        [TestMethod]
        public void RemoveNoneExistingGameTest()
        {
            try
            {
                _gameService.Delete(_game.Id);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Game doesn't exist");
            }

        }
    }
}
