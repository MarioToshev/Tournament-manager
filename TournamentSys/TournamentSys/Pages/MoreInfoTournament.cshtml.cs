using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TournamentSysData.DTOs;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Models.ViewModels.TournamentViewModels;
using TournamentSysLogic.Services.Interfaces;
using TournamentSysLogic.Services.TournamentLogic;
using TournamentSysLogic.Services.UserLogic;

namespace TournamentSys.Pages
{
    public class MoreInfoTournamentModel : PageModel
    {
        private readonly ILogger<AllTournamentsModel> _logger;

        private readonly TournamentService _tournamentService;
        private readonly PlayerService _playerService;


        [BindProperty]
        public TournamentViewModel Tournament { get; set; }

        public MoreInfoTournamentModel(ILogger<AllTournamentsModel> logger)
        {
            _logger = logger;
            _tournamentService = new TournamentService();
            _playerService = new PlayerService();
        }
        public void OnGet(string TournamentId)
        {
            Tournament = _tournamentService.GetAllTournamentInfo(TournamentId);
        }
        public void OnPost(string TournamentId)
        {
            Tournament = _tournamentService.GetAllTournamentInfo(TournamentId);
            Tournament.Players.ForEach(x => x.Rank = _playerService.GetRank(x));

        }
    }
}
