using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysLogic.Models.DTOs.User;
using TournamentSysLogic.Services.Interfaces;

namespace TournamentSysData.DataServices
{
    public class RoleDataService: IMaintanable<RoleDto>
    {

        private readonly DatabaseComunication _context;
        public RoleDataService()
        {
            _context = new DatabaseComunication();
        }
        public void Create(RoleDto role)
        {
            string query = @"Insert into Role(Id, RoleName)
                             Values(@Id,@RoleName)";

            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", role.Id},
                {"@RoleName", role.RoleName},
            });
        }
        public void Delete(string id)
        {
            string query = @"Delete * from Role
                             where Id = @Id";

            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", id},
            });
        }

        public List<RoleDto> GetAll()
        {
            string query = @"Select * from Role;";
            return _context.Get<RoleDto>(query, new Dictionary<string, dynamic> { });
        }

        public RoleDto GetOne(string id)
        {
            string query = @"Select * from Role
                             where Id = @Id";
            return _context.Get<RoleDto>(query, new Dictionary<string, dynamic> { })[0];
        }

        public void Update(RoleDto role)
        {
            string query = @"Update Role set RoleName = @RoleName
                             where Id = @Id";

            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", role.Id},
                {"@RoleName", role.RoleName},
            });
        }
    }
}
