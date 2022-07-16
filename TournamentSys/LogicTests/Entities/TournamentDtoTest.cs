using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysLogic.Models.DTOs;

namespace LogicTests.Entities
{
    [TestClass]
    public class TournamentDtoTest
    {
        [TestMethod]
        public void CreateTrournamentCorrect()
        {
            TournamentDto trournament = new TournamentDto(DateTime.Now, DateTime.Now.AddDays(2), "1", "desc", "city", 1, 3);
            Assert.IsNotNull(trournament);
        }
        [TestMethod]
        public void CreaTetrournamentNoSystem()
        {
            try
            {
                TournamentDto trournament = new TournamentDto(DateTime.Now, DateTime.Now.AddDays(2), "", "desc", "city", 1, 3);
            }
            catch (Exception ex)
            {

                Assert.AreEqual(ex.Message, "Select a system.");
            }
        }
        [TestMethod]
        public void CreateTrournamentEmptyFirstName()
        {
            try
            {
                TournamentDto trournament = new TournamentDto(DateTime.Now, DateTime.Now.AddDays(2), "1", "desc", "", 1, 3);
            }
            catch (Exception ex)
            {

                Assert.AreEqual(ex.Message, "The city should be filled");
            }
        }
        
    }
}
