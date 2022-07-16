using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DTOs;

namespace LogicTests.Entities
{
    [TestClass]
    public class UserDtoTest
    {
        [TestMethod]
        public void CreateUserCorrect()
        {
            UserDto user = new UserDto("Jorje", "Petrov","123","jorje@gmail.com","1");
            Assert.IsNotNull(user);
        }
        [TestMethod]
        public void CreateUserWrongEmail()
        {
            try
            {
                UserDto user = new UserDto("Jorje", "Petrov", "123", "jorje@gmail.com", "1");
            }
            catch (Exception ex)
            {

                Assert.AreEqual(ex.Message, "Email is not valid.");
            }   
        }
        [TestMethod]
        public void CreateUserEmptyFirstName()
        {
            try
            {
                UserDto user = new UserDto("", "Petrov", "123", "jorje@gmail.com", "1");
            }
            catch (Exception ex)
            {

                Assert.AreEqual(ex.Message, "First name should be at least 2 simbols");
            }
        }
        [TestMethod]
        public void CreateUserEmptySecondName()
        {
            try
            {
                UserDto user = new UserDto("Jorje", "", "123", "jorje@gmail.com", "1");
            }
            catch (Exception ex)
            {

                Assert.AreEqual(ex.Message, "Second name should be at least 2 simbols");
            }
        }
        [TestMethod]
        public void CreateUserEmptyShortPassword()
        {
            try
            {
                UserDto user = new UserDto("Jorje", "Petrov", "1", "jorje@gmail.com", "1");
            }
            catch (Exception ex)
            {

                Assert.AreEqual(ex.Message, "Password should be at least 3 simbols");
            }
        }

    }
}
