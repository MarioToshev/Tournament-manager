using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentSysLogic.Models.ViewModels.UserViewModels
{
    public class PlayerViewModel
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Wins { get; set; }
        [Required]
        public string Loses { get; set; }
        [Required]
        public string Rank { get; set; }
    }
}
