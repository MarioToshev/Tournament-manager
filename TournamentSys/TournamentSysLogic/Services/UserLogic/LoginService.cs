using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DTOs;
using TournamentSysLogic.Models.ViewModels.UserViewModels;
using TournamentSysLogic.Services.Interfaces;

namespace TournamentSysLogic.Services.UserLogic
{
    public class LoginService
    {
        public readonly UserService _service;
        public readonly PasswordEncryptionService _encryptionService;


        public LoginService()
        {
            _service = new UserService();
            _encryptionService = new PasswordEncryptionService();
        }
        public LoginService(UserService service)
        {
            _service = service;
            _encryptionService = new PasswordEncryptionService();
        }

        public bool CheckIfCredentialsAreCorrect(LogInUserViewModel logInViewModel, List<string> acceptedRoles)
        {
            UserDto userFromBase = _service.GetOneByEmail(logInViewModel.Email);
            if (_encryptionService.AreEqual(logInViewModel.Password,userFromBase.Password, userFromBase.PasswordSalt) &&
                acceptedRoles.Contains(userFromBase.Role))
                return true;
            else
              return false;
        }
        public string GetLoggedUserRole(string email)
        => _service.GetOneByEmail(email).Role;
    }
}
