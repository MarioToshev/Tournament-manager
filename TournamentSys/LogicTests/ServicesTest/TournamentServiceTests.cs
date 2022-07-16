using LogicTests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.TournamentLogic;

namespace LogicTests.ServicesTest
{
    [TestClass]
    public class TournamentServiceTests
    {
        private readonly TournamentService _tournamentService;
        private readonly TournamentDto  _tournament= new TournamentDto(DateTime.Now, DateTime.Now.AddDays(2),"1","desc","city",1,3);

        public TournamentServiceTests()
        {
            _tournamentService = new TournamentService(new TournamentMockData());
        }
        [TestMethod]
        public void CreateCorrectTournament()
        {
            _tournamentService.Create(_tournament);
            Assert.IsNotNull(_tournamentService.GetOne(_tournament.Id));
        }
        [TestMethod]
        public void UpdateTournamentTest()
        {
            _tournamentService.Create(_tournament);
            var newUser = _tournament;
            newUser.Location = "Burgas";

            _tournamentService.Update(_tournament);
            Assert.AreEqual(_tournamentService.GetOne(_tournament.Id).Location, "Burgas");
        }
        [TestMethod]
        public void UpdateNoneExistingTournamentTest()
        {
            try
            {
                _tournamentService.Update(_tournament);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Tournament doesn't exist");
            }

        }
        [TestMethod]
        public void RemoveTournamentTest()
        {
            _tournamentService.Create(_tournament);

            _tournamentService.Delete(_tournament.Id);
            Assert.IsNull(_tournamentService.GetOne(_tournament.Id));
        }
        [TestMethod]
        public void RemoveNoneExistingTournamentTest()
        {
            try
            {
                _tournamentService.Delete(_tournament.Id);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Tournament doesn't exist");
            }

        }
    }
}
