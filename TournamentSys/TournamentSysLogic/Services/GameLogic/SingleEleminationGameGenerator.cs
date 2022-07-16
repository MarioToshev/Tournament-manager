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
    public class SingleEleminationGameGenerator
    {
        private List<GameDto> games;
        public readonly GameService _gameService;
        public readonly Mapper _mapper;

        public SingleEleminationGameGenerator()
        {
            games = new List<GameDto>();
            _mapper = new Mapper();
            _gameService = new GameService();
        }
        public SingleEleminationGameGenerator(GameService gameService)
        {
            games = new List<GameDto>();
            _mapper = new Mapper();
            _gameService = gameService;
        }
        public List<GameDto> GenerateOrReturnSingleEleminationGames(List<BaseDataPlayerDto> players, string tournamentId)
        {
            List<GameDto> games = new List<GameDto>();
            games = _gameService.GetAllTournamentGames(tournamentId);

            Dictionary<GameDto, BaseDataPlayerDto> gameAndWinner = new Dictionary<GameDto, BaseDataPlayerDto>();
            if (games.Count == 0)
            {
                games = GenerateGamesSingleElemintion(players, tournamentId);
                _gameService.CreateMultiple(games);
            }
            if (games.Count < players.Count - 1)
            {
                if (games.FirstOrDefault(x => x.Score == "0/0") == null)
                {
                    var newGames = GenerateGamesSingleElemintion(GetWinersFromGames(games, players), tournamentId);
                    _gameService.CreateMultiple(newGames);
                    newGames.ForEach(x => games.Add(x));
                }
            }
            return games;
        }

        private List<GameDto> GenerateGamesSingleElemintion(List<BaseDataPlayerDto> players, string tournamentId)
        {
            if (players.Count % 2 == 0)
                games = GetResultEven(players, tournamentId);
            else games = GetResultOdd(players, tournamentId);

            return games;
        }
        private List<GameDto> GetResultEven(List<BaseDataPlayerDto> players, string tournamentId)
        {
            if (players.Count <= 1)
            {
                return games;
            }
            GetResultEven(players.Skip(2).ToList(), tournamentId);
            games.Add(new GameDto(players[0].Id, players[1].Id, tournamentId, "0/0"));
            return new List<GameDto>();
        }

        private List<GameDto> GetResultOdd(List<BaseDataPlayerDto> players, string tournamentId)
        {
            games.Add(new GameDto(players[0].Id, players[1].Id, tournamentId, "0/0"));
            return games;
        }
        public List<BaseDataPlayerDto> GetWinersFromGames(List<GameDto> games, List<BaseDataPlayerDto> players)
        {

            foreach (var game in games)
            {
                int[] score = game.Score.Split("/").Select(x => int.Parse(x)).ToArray();
                if (score[0] > score[1])
                {
                    players.Remove(players.FirstOrDefault(x => x.Id == game.SecondPlayerId));
                }
                else if (score[0] < score[1])
                {
                    players.Remove(players.FirstOrDefault(x => x.Id == game.FirstPlayerId));
                }
            }
            return players;
        }
    }
}
