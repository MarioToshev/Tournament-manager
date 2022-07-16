using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentSysData.DTOs.User
{
    public class BaseDataPlayerDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Wins { get; set; }
        public string Loses { get; set; }
        public string Rank { get; set; }
    }
}
