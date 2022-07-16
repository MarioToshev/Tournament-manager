using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.Interfaces;

namespace TournamentSysData.DataServices
{
    public class GameDataService: IMaintanable<GameDto>
    {
        private readonly DatabaseComunication _context;
        public GameDataService()
        {
            _context = new DatabaseComunication();
        }

        public virtual void Create(GameDto obj)
        {
            string query = @"insert into Game(Id,FirstPlayerId,SecondPlayerId,Registered,TournamentId, Score)
                             values(@Id,@FirstPlayerId,@SecondPlayerId,@Registered,@TournamentId,@Score);";
            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", obj.Id },
                {"@FirstPlayerId", obj.FirstPlayerId },
                {"@SecondPlayerId", obj.SecondPlayerId },
                {"@TournamentId", obj.TournamentId },
                {"@Score", obj.Score },
                {"@Registered", obj.Registered }
            });
        }
        public virtual void CreateMultiple(List<GameDto> games)
        {
            StringBuilder query = new StringBuilder();
            string score = "0/0";
            query.Append("BEGIN;");
            foreach (var game in games)
            {
                query.Append(
                    $"insert into Game(Id,FirstPlayerId,SecondPlayerId,Registered,TournamentId, Score) values(\"{game.Id}\",\"{game.FirstPlayerId}\",\"{game.SecondPlayerId}\", \"{game.Registered}\",\"{game.TournamentId}\",\"{score}\");");
            }
            query.Append("COMMIT;");
            string d = query.ToString();
            _context.SendQueryWithNoResult(query.ToString(), new Dictionary<string, dynamic> { });
        }

        public virtual void Delete(string id)
        {
            string query = @"Delete * from Game where Id = @Id";

            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", id }
            });
        }

        public virtual List<GameDto> GetAll()
        {
            string query = @"Select * from Game";

            return _context.Get<GameDto>(query, new Dictionary<string, dynamic> { });
        }
        public virtual List<GameDto> GetAllTournamentGames(string trId)
        {
            string query = @"Select g.Id, g.TournamentId, g.FirstPlayerId,g.SecondPlayerId, g.Registered,
						 IFNULL((select CONCAT(FirstName, "" "", SecondName) from user where id = g.FirstPlayerId), 'Deleted User')  as FirstPlayerNames,
						 IFNULL((select CONCAT(FirstName, "" "", SecondName) from user where id = g.SecondPlayerId), 'Deleted User')as SecondPlayerNames,
						 g.Score from Game g
                         where g.TournamentId = @TournamentId";

            return _context.Get<GameDto>(query, new Dictionary<string, dynamic>
            {
                { "@TournamentId", trId}
            });
        }

        public virtual GameDto GetOne(string id)
        {
            string query = @"Select * from Game where Id = @Id";

            return _context.Get<GameDto>(query, new Dictionary<string, dynamic>
            {
                {"@Id",id }
            })[0];
        }

        public virtual void Update(GameDto obj)
        {
            string query = @"Update Game set Score = @Score,
                             Registered = @Registered
                             where Id = @Id;";
            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", obj.Id },
                {"@Score", obj.Score },
                {"@Registered", obj.Registered }
            });
        }
    }
}
