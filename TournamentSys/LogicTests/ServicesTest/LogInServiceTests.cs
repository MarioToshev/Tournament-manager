using LogicTests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DTOs;
using TournamentSysLogic.Models.ViewModels.UserViewModels;
using TournamentSysLogic.Services.UserLogic;

namespace LogicTests.ServicesTest
{
    [TestClass]
    public class LogInServiceTests
    {
        private readonly LoginService _logInService;
        private readonly UserServiceMockData _userService;

        public LogInServiceTests()
        {
            _userService = new UserServiceMockData();
            _logInService = new LoginService(new UserService(_userService));
        }
        [TestMethod]
        public void CheckCredentialsCorrectTest()
        {
            var user = new UserDto("Jorje", "Petrov", "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=", "jorje@gmail.com", "1");
            _userService.Create(user,"asd");

            var loggingUser = new LogInUserViewModel();
            loggingUser.Email = "jorje@gmail.com";
            loggingUser.Password = "123";

            bool result =_logInService.CheckIfCredentialsAreCorrect(loggingUser, new List<string>() {"1"});
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckCredentialsDifferentRoleTest()
        {
            var user = new UserDto("Jorje", "Petrov", "123", "jorje@gmail.com", "1");
            _userService.Create(user, "asd");

            var loggingUser = new LogInUserViewModel();
            loggingUser.Email = "jorje@gmail.com";
            loggingUser.Password = "123";

            bool result = _logInService.CheckIfCredentialsAreCorrect(loggingUser, new List<string>() { "2" });
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CheckCredentialsWrongPasswordTest()
        {
            var user = new UserDto("Jorje", "Petrov", "123", "jorje@gmail.com", "1");
            _userService.Create(user, "asd");

            var loggingUser = new LogInUserViewModel();
            loggingUser.Email = "jorje@gmail.com";
            loggingUser.Password = "124";

            bool result = _logInService.CheckIfCredentialsAreCorrect(loggingUser, new List<string>() { "1" });
            Assert.IsFalse(result);
        }
    }
}
