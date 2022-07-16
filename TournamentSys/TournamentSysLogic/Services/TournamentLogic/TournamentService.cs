using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData;
using TournamentSysData.DataServices;
using TournamentSysData.DTOs;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Models.ViewModels.TournamentViewModels;
using TournamentSysLogic.Models.ViewModels.UserViewModels;
using TournamentSysLogic.Services.GameLogic;
using TournamentSysLogic.Services.Interfaces;
using TournamentSysLogic.Services.MapperLogic;
using TournamentSysLogic.Services.UserLogic;

namespace TournamentSysLogic.Services.TournamentLogic
{
    public class TournamentService : IMaintanable<TournamentDto>
    {
        private readonly TournamentDataService _dataService;
        private readonly PlayerService _playerService;
        private readonly GameService _gameService;
        private readonly Mapper _mapper;

        public TournamentService(TournamentDataService dataService)
        {
            _dataService = dataService;
            _playerService = new PlayerService();
            _gameService = new GameService();
            _mapper = new Mapper();
        }
        public TournamentService()
        {
            _dataService = new TournamentDataService();
            _playerService = new PlayerService();
            _gameService = new GameService();
            _mapper = new Mapper();
        }
        public void Create(TournamentDto tr)
        => _dataService.Create(tr);

        public void Delete(string id)
        => _dataService.Delete(id);

        public List<TournamentDto> GetAll()
        => _dataService.GetAll();

        public TournamentDto GetOne(string id)
        => _dataService.GetOne(id);

        public void Update(TournamentDto tr)
        => _dataService.Update(tr);

        public List<TournamentDto> GetAllAvailable(string email)
         => _dataService.GetAllAvailable(email);
        public List<TournamentDto> GetAllOngoing()
        => _dataService.GetAllOngoing();
        public List<TournamentDto> GetAllPast()
        => _dataService.GetAllPast();
        public List<TournamentDto> GetAllJoined(string email)
        => _dataService.GetAllJoined(email);


        public void JoinTournament(string trId, string email)
        {
            var tournament = _dataService.GetOne(trId);
            
            if (tournament.MaxPlayers > _playerService.GetAllFromTournament(trId).Count)
            {
                if (DateTime.Compare(DateTime.Now.AddDays(7),tournament.StartDate) < 0)
                {
                    _dataService.JoinTournament(trId, email);
                }
                else
                {
                    throw new Exception("The tournament Registration is closed");
                }
            }
            else
            {
                throw new Exception("The tournament is full");
            }
        }


        public bool PlayerIsInTournament(string trId, string email)
            => _dataService.CheckIfUserParticipates(trId,email);


        public TournamentViewModel GetAllTournamentInfo(string trId)
        {
            List<GameDto> games = _gameService.GetAllTournamentGames(trId);
            List <PlayerViewModel> players = _playerService.GetAllFromTournament(trId);
            TournamentDto tournamentDto = GetOne(trId);

            TournamentViewModel result = _mapper.TournamentViewModel(tournamentDto);
            result.Games = new List<GameDto>();
            result.Players = new List<PlayerViewModel>();
            if (result.Games != null)
            {
                result.Games = games;
            }
            if (result.Players != null)
            {
                result.Players = players;
            }

            return result;
        }
    }
}
