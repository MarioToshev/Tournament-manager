using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DTOs;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.Interfaces;

namespace TournamentSysData.DataServices
{
    public class TournamentDataService : IMaintanable<TournamentDto>
    {
        private readonly DatabaseComunication _context;
        public TournamentDataService()
        {
            _context = new DatabaseComunication();
        }
        public virtual void Create(TournamentDto tr)
        {
            string query = @"insert into Tournament(Id,StartDate,EndDate,SystemId,Description,Location,MinPlayers,MaxPlayers)
                             values(@Id,@StartDate,@EndDate,(Select Id from System where SystemName = @SystemName)
                                 ,@Description,@Location,@MinPlayers,@MaxPlayers);";
            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", tr.Id },
                {"@StartDate", tr.StartDate.ToUniversalTime()},
                {"@EndDate", tr.EndDate.ToUniversalTime() },
                {"@SystemName", tr.SystemName },
                {"@Description", tr.Description },
                {"@Location", tr.Location },
                {"@MinPlayers", tr.MinPlayers },
                {"@MaxPlayers", tr.MaxPlayers }
            });
        }

        public virtual void Delete(string id)
        {
            string query = @"delete * from Tournament where Id = @id";
            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", id }
            });
        }

        public virtual List<TournamentDto> GetAll()
        {
            string query = @"select t.Id, t.StartDate, t.EndDate, t.Description,  s.SystemName, t.Location, t.MinPlayers, t.MaxPlayers from Tournament t
                            inner join `System` s on s.Id = t.SystemId";
            return _context.Get<TournamentDto>(query, new Dictionary<string, dynamic> { });
        }
        public virtual List<TournamentDto> GetAllAvailable(string playerEmail)
        {
            string query = @"select t.Id, t.StartDate, t.EndDate, t.Description,  s.SystemName, t.Location, t.MinPlayers, t.MaxPlayers from TournamtentToUser tu                            
                            inner join Tournament t on  t.Id <> tu.TournamentId
                            inner join `System` s on s.Id = t.SystemId
                            where tu.PlayerId = (Select id from user where email = @Email);";
            return _context.Get<TournamentDto>(query, new Dictionary<string, dynamic> {
                {"@Email",playerEmail }
            });
        }
        public virtual List<TournamentDto> GetAllJoined(string email)
        {
            string query = @"select t.Id, t.StartDate, t.EndDate, t.Description,  s.SystemName, t.Location, t.MinPlayers, t.MaxPlayers from TournamtentToUser tu                            
                            inner join Tournament t on  t.Id = tu.TournamentId
                            inner join System s on s.Id = t.SystemId
                            where tu.PlayerId = (Select id from user where email = @Email);";
            return _context.Get<TournamentDto>(query, new Dictionary<string, dynamic> {
                {"@Email",email}
            });
        }
        public virtual List<TournamentDto> GetAllOngoing()
        {
            string query = @"select t.Id, t.StartDate, t.EndDate, t.Description,  s.SystemName, t.Location, t.MinPlayers, t.MaxPlayers from Tournament t
                            inner join `System` s on s.Id = t.SystemId
                            where Date(@Date) >= t.StartDate && Date(@Date) <= t.EndDate";
            return _context.Get<TournamentDto>(query, new Dictionary<string, dynamic> {
                {"@Date", DateTime.Now }
            });
        }
        public virtual List<TournamentDto> GetAllPast()
        {
            string query = @"select t.Id, t.StartDate, t.EndDate, t.Description,  s.SystemName, t.Location, t.MinPlayers, t.MaxPlayers from Tournament t
                            inner join `System` s on s.Id = t.SystemId
                            where  Date(@Date) > t.EndDate";
            return _context.Get<TournamentDto>(query, new Dictionary<string, dynamic> {
                {"@Date", DateTime.Now }
            });
        }

        public virtual TournamentDto GetOne(string id)
        {
            string query = @"select t.Id, t.StartDate, t.EndDate, t.Description, s.SystemName, t.Location, t.MinPlayers, t.MaxPlayers from Tournament t
                             inner join `System` s on s.Id = t.SystemId
                             where t.Id = @Id";
            return _context.Get<TournamentDto>(query, new Dictionary<string, dynamic>
            {
                {"@Id", id }
            })[0];
        }

        public virtual void Update(TournamentDto tr)
        {
            string query = @"Update Tournament set StartDate = @StartDate
                           ,EndDate = @EndDate,Description = @Description,
                           Location = @Location,MinPlayers = @MinPlayers,MaxPlayers = @MaxPlayers 
                             where Id = @Id;";
            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", tr.Id },
                {"@StartDate", tr.StartDate },
                {"@EndDate", tr.EndDate },
                {"@Description", tr.Description },
                {"@Location", tr.Location },
                {"@MinPlayers", tr.MinPlayers },
                {"@MaxPlayers", tr.MaxPlayers }
            });
        }
        public virtual void JoinTournament(string tournamentId, string email )
        {
            string query = @"insert into TournamtentToUser
            values(@TournamentId, 
            (Select u.Id from User u
            inner join role r on r.Id = u.RoleId
            where u.Email = @UserEmail && r.RoleName = 'Player'));";
            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@TournamentId", tournamentId },
                {"@UserEmail", email }
            });
        }
        public virtual bool CheckIfUserParticipates(string tournamentId, string email)
        {
            string query = @"Select * from TournamtentToUser
            where TournamentId = @TournamentId and
            PlayerId = (Select u.Id from User u
            inner join role r on r.Id = u.RoleId
            where u.Email = @UserEmail && r.RoleName = 'Player');";
           var record =  _context.Get<TournamentToUserDto>(query, new Dictionary<string, dynamic>
            {
                {"@TournamentId", tournamentId },
                {"@UserEmail", email }
            });
            if (record.Count > 0)
                return true;
            else return false;    
        }
    }
}
