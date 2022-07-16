using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Models.ViewModels.UserViewModels;
using TournamentSysLogic.Services.Interfaces;
using TournamentSysLogic.Services.MapperLogic;
using TournamentSysLogic.Services.TournamentLogic;
using TournamentSysLogic.Services.UserLogic;

namespace TournamentSys.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LogInUserViewModel User { get; set; }
        [BindProperty]
        public string loggedUserEmail { get; set; }
        [BindProperty]
        public string ErrorMessage { get; set; }
        [BindProperty]
        public List<TournamentDto> Tournaments { get; set; }
        [BindProperty]
        public PlayerViewModel player { get; set; }


        private readonly ILogger<LoginModel> _logger;
        private readonly IMapper _mapper;
        private readonly PlayerService _playerService;
        private readonly TournamentService _tournamentService;
        private readonly LoginService _loginService;

        public LoginModel(ILogger<LoginModel> logger, IMapper mapper)
        {
            loggedUserEmail = "";
            player = new PlayerViewModel();
            _logger = logger;
            _mapper = mapper;
            Tournaments = new List<TournamentDto>();
            _tournamentService = new TournamentService();
            _playerService = new PlayerService();
            _loginService = new LoginService();
        }
        public void OnGet(string playerEmail)
        {
            if (!string.IsNullOrEmpty(playerEmail))
            {
                player = _mapper.MapPlayerDto(_playerService.GetOneByEmail(playerEmail));
                player.Rank = _playerService.GetRank(player);
                Tournaments = _tournamentService.GetAllJoined(player.Email);
            }
            else if (HttpContext.User.FindFirst(ClaimTypes.Email) != null)
            {
                loggedUserEmail = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                string role = _loginService.GetLoggedUserRole(loggedUserEmail);
                if (role == "Player")
                {
                    player = _mapper.MapPlayerDto(_playerService.GetOneByEmail(loggedUserEmail));
                    player.Rank = _playerService.GetRank(player);
                    Tournaments = _tournamentService.GetAllJoined(loggedUserEmail);
                }
            }

        }
        public IActionResult OnPost()
        {

            if (!string.IsNullOrEmpty(User.Email) || !string.IsNullOrEmpty(User.Password))
            {
                if (_loginService.CheckIfCredentialsAreCorrect(User, new List<string>() { "Player", "User","Staff" }))
                {
                    ErrorMessage = "";


                    var claims = new List<Claim>
                    {
                       new Claim(ClaimTypes.Email, User.Email)
                    };
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddMinutes(60),
                    };
                    HttpContext.SignInAsync(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(claimsIdentity),
                   authProperties);

                    return RedirectToPage("Index");
                }
                else
                {
                    ErrorMessage = "Invalid password or email";
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
