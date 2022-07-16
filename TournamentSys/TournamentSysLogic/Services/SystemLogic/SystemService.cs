using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData;
using TournamentSysData.DataServices;
using TournamentSysData.DataServices.UserDataServices;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.Interfaces;

namespace TournamentSysLogic.Services.SystemLogic
{
    public class SystemService : IMaintanable<SystemDto>
    {

        private readonly DatabaseComunication _context;
        private readonly SystemDataService _systemDataService;
        public SystemService()
        {
            _systemDataService = new SystemDataService();
            _context = new DatabaseComunication();
        }
        public void Create(SystemDto sys)
        => _systemDataService.Create(sys);
        public void Delete(string id)
        => _systemDataService.Delete(id);

        public List<SystemDto> GetAll()
        => _systemDataService.GetAll();

        public SystemDto GetOne(string id)
        => _systemDataService.GetOne(id);

        public void Update(SystemDto sys)
        => _systemDataService.Update(sys);
    }
}
