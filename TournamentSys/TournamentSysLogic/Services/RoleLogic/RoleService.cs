using TournamentSysData.DataServices;
using TournamentSysLogic.Models.DTOs.User;
using TournamentSysLogic.Services.Interfaces;

namespace TournamentSysLogic.Services.RoleLogic
{
    public class RoleService : IMaintanable<RoleDto>
    {
        private readonly RoleDataService _roleDataService;

        public RoleService()
        {
            _roleDataService = new RoleDataService();
        }
        public void Create(RoleDto role)
        => _roleDataService.Create(role);   

        public void Delete(string id)
        => _roleDataService.Delete(id);

        public List<RoleDto> GetAll()
        => _roleDataService.GetAll();

        public RoleDto GetOne(string id)
        => _roleDataService.GetOne(id);

        public void Update(RoleDto role)
        => _roleDataService.Update(role);
    }
} 
