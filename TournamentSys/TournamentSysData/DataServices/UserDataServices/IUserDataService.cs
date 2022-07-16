using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DTOs;
using TournamentSysLogic.Models.DTOs;

namespace TournamentSysData.DataServices.UserDataServices
{
    public interface IUserDataService
    {
        public void Create(UserDto user, string roleName);
        public void Update(UserDto user);
        public void Delete(string userId);
        public UserDto GetOne(string userId);
        public List<UserDto> GetAll();
    }
}
