using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentSysLogic.Models.DTOs.User
{
    public class RoleDto
    {
        private string id;
        private string roleName;

        public RoleDto(string roleMame)
        {
            this.RoleName = roleMame;
        }
        public RoleDto() { }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }


    }
}
