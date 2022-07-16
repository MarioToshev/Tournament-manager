using LogicTests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DTOs;
using TournamentSysLogic.Services.Interfaces;
using TournamentSysLogic.Services.UserLogic;

namespace LogicTests.ServicesTest
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService _userService;
        private UserDto  _user = new UserDto("Jorje", "Petrov", "123", "jorje@gmail.com", "1");
        public UserServiceTests()
        {
            _userService = new UserService(new UserServiceMockData());
        }

       
        [TestMethod]
        public void CreateCorrectUser()
        {
            _userService.Create(_user);
            Assert.IsNotNull(_userService.GetOne(_user.Id));
        }
        [TestMethod]
        public void CreateUserTwoTimes()
        {
            _userService.Create(_user);
            _userService.Create(_user);
            Assert.IsTrue(_userService.GetAll().Select(x => x.Email == _user.Email).Count() == 1);
        }
        [TestMethod]
        public void UpdateUserTest()
        {
            _userService.Create(_user);
            var newUser = _user;
            newUser.FirstName = "Ivan";

            _userService.Update(_user);
            Assert.AreEqual(_userService.GetOne(_user.Id).FirstName,"Ivan");
        }
        [TestMethod]
        public void UpdateNoneExistingUserTest()
        {
            try
            {
                _userService.Update(_user);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message,"User  doesn't exist");
            }
           
        }
        [TestMethod]
        public void RemoveUserTest()
        {
            _userService.Create(_user);

            _userService.Delete(_user.Id);
            Assert.IsNull(_userService.GetOne(_user.Id));
        }
        [TestMethod]
        public void RemoveNoneExistingUserTest()
        {
            try
            {
                _userService.Delete(_user.Id);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message,"User doesn't exist");
            }
           
        }

    }
}
