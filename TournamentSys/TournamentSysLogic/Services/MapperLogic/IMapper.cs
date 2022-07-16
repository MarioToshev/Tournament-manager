using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DTOs;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Models.ViewModels.TournamentViewModels;
using TournamentSysLogic.Models.ViewModels.UserViewModels;

namespace TournamentSysLogic.Services.MapperLogic
{
    public interface IMapper
    {
        public UserDto MapUserView(UserViewModel user);
        public TournamentViewModel TournamentViewModel(TournamentDto tournament);
        public PlayerViewModel MapPlayerDto(PlayerDto player);
        public PlayerDto MapPlayerViewModel(PlayerViewModel player);


    }
}
