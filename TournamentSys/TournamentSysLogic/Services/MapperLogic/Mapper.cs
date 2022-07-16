using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DTOs;
using TournamentSysData.DTOs.User;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Models.ViewModels.TournamentViewModels;
using TournamentSysLogic.Models.ViewModels.UserViewModels;

namespace TournamentSysLogic.Services.MapperLogic
{
    public class Mapper : IMapper
    {
        public  UserDto MapUserView(UserViewModel user)
        {
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
        }

        public TournamentViewModel TournamentViewModel(TournamentDto tournament)
        {
            return new TournamentViewModel
            {
                Description = tournament.Description,
                StartDate = tournament.StartDate,
                EndDate = tournament.EndDate,
                Games = new List<GameDto>(),
                Players = new List<PlayerViewModel>(),
                SystemName = tournament.SystemName,
                Location = tournament.Location,
                MaxPlayers  = tournament.MaxPlayers,
                MinPlayers = tournament.MinPlayers
            };
        }
        public PlayerDto MapPlayerViewModel(PlayerViewModel player)
        {
            return new PlayerDto()
            {
                Id = player.Id,
                Email = player.Email,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Wins = player.Wins,
                Loses = player.Loses,
                Rank = player.Rank,
                Role = "Player",
                Password = ""
            };
        }
        public BaseDataPlayerDto MapToBaseDataPlayerDto(PlayerViewModel player)
        {
            return new BaseDataPlayerDto()
            {
                Id = player.Id,
                Email = player.Email,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Wins = player.Wins,
                Loses = player.Loses,
                Rank = player.Rank
            };
        }
        public PlayerViewModel MapPlayerDto(PlayerDto player)
        {
            return new PlayerViewModel()
            {
                Id = player.Id,
                Email = player.Email,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Wins = player.Wins,
                Loses = player.Loses,
                Rank = player.Rank,
            };
        }
        public PlayerViewModel MapPlayerDto(BaseDataPlayerDto player)
        {
            return new PlayerViewModel()
            {
                Id = player.Id,
                Email = player.Email,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Wins = player.Wins,
                Loses = player.Loses,
                Rank = player.Rank,
            };
        }
    }
}
