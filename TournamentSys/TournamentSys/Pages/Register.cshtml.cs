using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TournamentSysData.DTOs;
using TournamentSysLogic.Models.ViewModels.UserViewModels;
using TournamentSysLogic.Services.Interfaces;
using TournamentSysLogic.Services.MapperLogic;
using TournamentSysLogic.Services.UserLogic;

namespace TournamentSys.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserViewModel newUser { get; set; }

        private readonly UserService _userService;
        private readonly IMapper _mapper;
        public string ErrorMessage { get; set; }


        private readonly ILogger<RegisterModel> _logger;
        
        public RegisterModel(ILogger<RegisterModel> logger, IMaintanable<UserDto> userService, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            ErrorMessage = "";
            _userService = new UserService();
            newUser = new UserViewModel();
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.Create(_mapper.MapUserView(newUser), "User");
                }
                catch (Exception ex)
                {

                    ErrorMessage = ex.Message;
                }
            }
            return Page();
        }
    }
}