using LogicTests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DTOs.User;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.GameLogic;

namespace LogicTests.ServicesTest
{
    [TestClass]
    public class GameGenerationTests
    {
        public RobinRoundGameGenerator _robinRoundGameGenerator;
        public SingleEleminationGameGenerator _singleEleminationGameGenerator;
        public GameServiceMockData _gameServiceMockData;

        public GameGenerationTests()
        {
            _gameServiceMockData = new GameServiceMockData();
            _robinRoundGameGenerator = new RobinRoundGameGenerator(new GameService(_gameServiceMockData));
            _singleEleminationGameGenerator = new SingleEleminationGameGenerator(new GameService(_gameServiceMockData));
        }

        [TestMethod]
        public void RobinRoundGameGenerationTests()
        {
            var gameList = new List<GameDto>()
            {
                new GameDto("1","2","1","0/0"),
                new GameDto("1","3","1","0/0"),
                new GameDto("1","4","1","0/0"),
                new GameDto("2","3","1","0/0"),
                new GameDto("2","4","1","0/0"),
                new GameDto("3","4","1","0/0")
            };
            var player = new List<BaseDataPlayerDto>
            {
                new BaseDataPlayerDto(){Id="1", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},
                new BaseDataPlayerDto(){Id="2", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},
                new BaseDataPlayerDto(){Id="3", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},
                new BaseDataPlayerDto(){Id="4", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},

            };

            List<GameDto> listGames = _robinRoundGameGenerator.GenerateAndSaveIfNotExistingRobinRoundGames(player, "1");
            bool result = true;
            listGames.ForEach(x =>
            {
                if (gameList.Contains(x))
                    result = false;
            });
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void RobinRoundRerturnGamesWhenExistTests()
        {
            var gameList = new List<GameDto>()
            {
                new GameDto("1","2","1","0/0"),
                new GameDto("1","3","1","0/0"),
                new GameDto("1","4","1","0/0"),
                new GameDto("2","3","1","0/0"),
                new GameDto("2","4","1","0/0"),
                new GameDto("3","4","1","0/0")
            };
            _gameServiceMockData.CreateMultiple(gameList);
            var player = new List<BaseDataPlayerDto>
            {
                new BaseDataPlayerDto(){Id="1", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},
                new BaseDataPlayerDto(){Id="2", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},
                new BaseDataPlayerDto(){Id="3", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},
                new BaseDataPlayerDto(){Id="4", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},

            };

            List<GameDto> listGames = _robinRoundGameGenerator.GenerateAndSaveIfNotExistingRobinRoundGames(player, "1");
            bool result = true;
            listGames.ForEach(x =>
            {
                if (gameList.Contains(x))
                    result = false;
            });
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void RobinRoundGameGenerationWithNoPlayersTests()
        {
            var gameList = new List<GameDto>();
            var player = new List<BaseDataPlayerDto>();

            List<GameDto> listGames = _robinRoundGameGenerator.GenerateAndSaveIfNotExistingRobinRoundGames(player, "1");
            bool result = false;
            if (listGames.Count == 0)
                result = true;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void SingleEleminationGameGenerationEvenTests()
        {
            var gameList = new List<GameDto>()
            {
                new GameDto("3","4","1","0/0"),
                new GameDto("1","2","1","0/0")
            };
            var player = new List<BaseDataPlayerDto>
            {
                new BaseDataPlayerDto(){Id="1", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},
                new BaseDataPlayerDto(){Id="2", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},
                new BaseDataPlayerDto(){Id="3", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},
                new BaseDataPlayerDto(){Id="4", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},
            };

           
            List<GameDto> listGames = _singleEleminationGameGenerator.GenerateOrReturnSingleEleminationGames(player, "1");

            bool result = false;
            for (int i = 0; i < gameList.Count(); i++)
            {
                if (gameList[i].FirstPlayerId == listGames[i].FirstPlayerId &&
                    gameList[i].SecondPlayerId == listGames[i].SecondPlayerId)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void SingleEleminationGameGenerationOddTests()
        {
            var gameList = new List<GameDto>()
            {
                new GameDto("1","2","1","0/0"),
            };
            var player = new List<BaseDataPlayerDto>
            {
                new BaseDataPlayerDto(){Id="1", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},
                new BaseDataPlayerDto(){Id="2", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},
                new BaseDataPlayerDto(){Id="3", Email = "",FirstName = "d", LastName = "d",Loses ="0",Rank="0",Wins="0"},
            };

            List<GameDto> listGames = _singleEleminationGameGenerator.GenerateOrReturnSingleEleminationGames(player, "1");
            bool result = false;
            for (int i = 0; i < gameList.Count(); i++)
            {
                if (gameList[i].FirstPlayerId == listGames[i].FirstPlayerId &&
                    gameList[i].SecondPlayerId == listGames[i].SecondPlayerId)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            Assert.IsTrue(result);
        }
    }
}
