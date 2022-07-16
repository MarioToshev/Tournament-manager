using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.Interfaces;

namespace TournamentSysData.DataServices
{
    public class SystemDataService : IMaintanable<SystemDto>
    {
        private readonly DatabaseComunication _context;
        public SystemDataService()
        {
            _context = new DatabaseComunication();
        }
        public void Create(SystemDto sys)
        {
            string query = @"Insert into System(Id, SystemName)
                             Values(@Id,@SystemName)";

            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", sys.Id},
                {"@SystemName", sys.SystemName},
            });
        }
        public void Delete(string id)
        {
            string query = @"Delete * from System
                             where Id = @Id";

            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", id},
            });
        }

        public List<SystemDto> GetAll()
        {
            string query = @"Select * from System";

            return _context.Get<SystemDto>(query, new Dictionary<string, dynamic> { });
        }

        public SystemDto GetOne(string id)
        {
            string query = @"Select * from System
                             where Id = @Id";
            return _context.Get<SystemDto>(query, new Dictionary<string, dynamic> { })[0];
        }

        public void Update(SystemDto sys)
        {
            string query = @"Update System set SystemName = @SystemName
                             where Id = @Id";

            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", sys.Id},
                {"@SystemName", sys.SystemName},
            });
        }
    }
}
