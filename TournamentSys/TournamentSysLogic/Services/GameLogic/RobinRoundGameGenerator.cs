using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DTOs.User;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.MapperLogic;
using TournamentSysLogic.Services.UserLogic;

namespace TournamentSysLogic.Services.GameLogic
{
    public class RobinRoundGameGenerator
    {
        private List<GameDto> games;
        public readonly GameService _gameService;

        public RobinRoundGameGenerator() 
        {
            games = new List<GameDto>();
            _gameService = new GameService();
        }
        public RobinRoundGameGenerator(GameService service)
        {
            games = new List<GameDto>();
            _gameService = service;
        }

        public List<GameDto> GenerateAndSaveIfNotExistingRobinRoundGames(List<BaseDataPlayerDto> players, string tournamentId)
        {
            List<GameDto> games = new List<GameDto>();
            games = _gameService.GetAllTournamentGames(tournamentId);
            if (games.Count > 0)
            {
                return games;
            }
            else
            {
                games = GenerateRobinRoundGames(players, tournamentId);
                _gameService.CreateMultiple(games);
                return games;
            }
        }
        private List<GameDto> GenerateRobinRoundGames(List<BaseDataPlayerDto> players, string tournamentId)
        {
            for (int j = 1; j < players.Count; j++)
            {
                games.Add(new GameDto(players[0].Id, players[j].Id, tournamentId, "0/0"));
            }  
            if (players.Count <= 1)
            {
                return games;
            }
            else
            {
                return GenerateRobinRoundGames(players.Skip(1).ToList(), tournamentId);
            }
        }
    }
}
