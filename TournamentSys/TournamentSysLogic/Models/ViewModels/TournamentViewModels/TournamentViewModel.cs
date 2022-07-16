using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Models.ViewModels.UserViewModels;

namespace TournamentSysLogic.Models.ViewModels.TournamentViewModels
{
    public class TournamentViewModel
    {
        public string Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string SystemName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int MinPlayers { get; set; }
        [Required]
        public int MaxPlayers { get; set; }

        public List<PlayerViewModel> Players { get; set; }
        public List<GameDto> Games { get; set; }
    }
}
