 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData;
using TournamentSysData.DataServices.UserDataServices;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Models.ViewModels.UserViewModels;
using TournamentSysLogic.Services.Interfaces;
using TournamentSysLogic.Services.MapperLogic;

namespace TournamentSysLogic.Services.UserLogic
{
    public class PlayerService: IMaintanable<PlayerDto>
    {
        private readonly PlayerDataService _playerDataService;
        private readonly PasswordEncryptionService _encriptionService;
        private readonly Mapper _mapper;

        public PlayerService()
        {
            _playerDataService = new PlayerDataService();
            _encriptionService = new PasswordEncryptionService();
            _mapper = new Mapper();
        }
        public void Create(PlayerDto user)
        {
            user.PasswordSalt = _encriptionService.CreateSalt(5);
            user.Password = _encriptionService.GenerateHash(user.Password, user.PasswordSalt);
            _playerDataService.Create(user);
        }

        public void Delete(string userId)
       => _playerDataService.Delete(userId);

        public List<PlayerDto> GetAll()
        => _playerDataService.GetAll();

        public List<PlayerViewModel> GetAllFromTournament(string trId)
        =>_playerDataService.GetAllFromTournament(trId)
          .Select(dto => _mapper.MapPlayerDto(dto)).ToList();

        public PlayerDto GetOne(string userId)
        => _playerDataService.GetOne(userId);
        public PlayerDto GetOneByEmail(string email)
        => _playerDataService.GetOneByEmail(email);

        public void Update(PlayerDto user)
       => _playerDataService.Update(user);

        public string GetRank(PlayerViewModel player)
        {
            int result = ((int.Parse(player.Wins) + 1) / (int.Parse(player.Loses) + 1)) * 100;
            return result.ToString();
        }
    }
}

