using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DataServices;
using TournamentSysLogic.Models.DTOs;

namespace LogicTests.MockData
{
    public class TournamentMockData:TournamentDataService
    {
        public List<TournamentDto> tournaments = new List<TournamentDto>();
        
       
        public override void Create(TournamentDto tr)
        {
            tournaments.Add(tr);
        }
        public override void Delete(string id)
        {
            tournaments.Remove(GetOne(id));
        }
        public override List<TournamentDto> GetAll()
        {
            return tournaments;
        }
        
        public override TournamentDto GetOne(string id)
        {
            return tournaments.FirstOrDefault(x => x.Id == id);
        }
        public override void Update(TournamentDto tr)
        {
            tournaments[tournaments.IndexOf(GetOne(tr.Id))] = tr;
        }
        public override void JoinTournament(string tournamentId, string Userid)
        {
            //try later
            //base.JoinTournament(tournamentId, Userid);
        }
        public override bool CheckIfUserParticipates(string tournamentId, string email)
        {
            return base.CheckIfUserParticipates(tournamentId, email);
        }
    }
}
