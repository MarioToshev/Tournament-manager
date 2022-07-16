using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TournamentSysData.DTOs;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.Interfaces;
using TournamentSysLogic.Services.TournamentLogic;
using TournamentSysLogic.Services.UserLogic;

namespace TournamentSys.Pages
{
    public class AllTournamentsModel : PageModel
    {
        private readonly IMaintanable<TournamentDto> _trDataService;
        private readonly UserService _userService;
        private readonly TournamentService _tournamentService;


        [BindProperty]
        public string ErrorMessage { get; set; }
        [BindProperty]
        public List<TournamentDto> Tournaments { get; set; }

        private readonly ILogger<AllTournamentsModel> _logger;

        public AllTournamentsModel(ILogger<AllTournamentsModel> logger, IMaintanable<TournamentDto> trService)

        {
            _tournamentService = new TournamentService();
            _logger = logger;
            _userService = new UserService();
            _trDataService = trService;
            Tournaments = new List<TournamentDto>();
        }

        public void OnGet(string filter)
        {
            if (filter == "All")
            {
                Tournaments = _trDataService.GetAll();
            }
            else if (filter == "Available")
            {
                if (User.FindFirst(ClaimTypes.Email) != null)
                {
                    Tournaments = _tournamentService.GetAllAvailable(User.FindFirst(ClaimTypes.Email).Value);
                }
                else
                {
                    ErrorMessage = "You have to be logged in";
                }
            }
            else if (filter == "Ongoing")
            {
                Tournaments = _tournamentService.GetAllOngoing();
            }
            else if (filter == "Past")
            {
                Tournaments = _tournamentService.GetAllPast();
            }
            else
            {
                Tournaments = _trDataService.GetAll();
            }
        }
        public IActionResult OnPost(string TournamentId)
        {
            if (User.FindFirst(ClaimTypes.Email) != null)
            {
                if (_userService.GetOneByEmail(User.FindFirst(ClaimTypes.Email).Value).Role == "Player")
                {
                    if (!_tournamentService.PlayerIsInTournament(TournamentId, User.FindFirst(ClaimTypes.Email).Value))
                    {
                        try
                        {
                            _tournamentService.JoinTournament(TournamentId, User.FindFirst(ClaimTypes.Email).Value);
                        }
                        catch (Exception ex)
                        {

                            ErrorMessage = ex.Message;
                        }
                    }
                    else
                    {
                        ErrorMessage = "You participate in this tournament already";
                    }
                }
                else
                {
                    ErrorMessage = "You have to be a player to participate";
                    
                }
                Tournaments = _trDataService.GetAll();
                return Page();
            }
            else
            {
                return RedirectToPage("Login");
            }
        }
    }
}