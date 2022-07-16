using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DTOs.User;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.Interfaces;

namespace TournamentSysData.DataServices.UserDataServices
{
    public class PlayerDataService: IMaintanable<PlayerDto>
    {
        private readonly DatabaseComunication _context;
        public PlayerDataService()
        {
            _context = new DatabaseComunication();
        }
        public virtual void Create(PlayerDto user)
        {
            string query = @"
                BEGIN;
                Insert into `User` (id,FirstName,SecondName,Password,PasswordSalt,Email, RoleId)
                Values( @Id, @firstname, @lastName, @Password,@PasswordSalt, @Email, 
                (Select Id from Role where RoleName = 'Player'));

                Insert into `Player`(UserId,Rank,Wins,Loses)
                Values(@Id,@Rank,@Loses,@Wins);
                COMMIT;";

            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", user.Id},
                {"@firstname", user.FirstName },
                {"@lastName",user.LastName },
                {"@Password",user.Password },
                {"@Email", user.Email},
                {"@Rank", user.Rank},
                {"@PasswordSalt", user.PasswordSalt},
                {"@Loses", user.Loses},
                {"@Wins", user.Wins}
            });
        }

        public virtual void Delete(string userId)
        {
            string query = @"
                            BEGIN;
                            delete from User where Id = @Id;
                            delete from User where Id = @Id;
                            COMMIT;";
            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", userId},
            });
        }

        public virtual List<PlayerDto> GetAll()
        {
            string query = @"Select u.Id, u.FirstName, u.SecondName as  LastName, u.Password,u.PasswordSalt, u.Email, 
                             (Select r.RoleName from Role r where r.Id = u.RoleId) as Role, p.Rank, p.Wins, p.Loses from User u
                             inner join Player p on u.Id = p.UserId;"; ;
            return _context.Get<PlayerDto>(query, new Dictionary<string, dynamic> { });
        }
        public virtual List<BaseDataPlayerDto> GetAllFromTournament(string trId)
        {
            string query = @"Select u.Id, u.FirstName, u.SecondName, u.Password,u.PasswordSalt, u.Email, 
						   (Select r.RoleName from Role r where r.Id = u.RoleId) as Role , p.Rank, p.Wins, p.Loses from  TournamtentToUser tu
                           inner join player p on tu.PlayerId = p.UserId
                           inner join user u on u.Id = p.UserId
                           where tu.tournamentId = @TrId;";
            return _context.Get<BaseDataPlayerDto>(query, new Dictionary<string, dynamic>
            {
                {"@TrId", trId }
            });
        }

        public virtual PlayerDto GetOne(string userId)
        {
            string query = @"Select u.Id, u.FirstName, u.SecondName as  LastName, u.Password,u.PasswordSalt, u.Email, 
                             (Select r.RoleName from Role r where r.Id = u.RoleId) as Role, p.Rank, p.Wins, p.Loses from Player p
                             inner join User u on u.Id = p.UserId
                             where p.UserId = @id;";
            return _context.Get<PlayerDto>(query, new Dictionary<string, dynamic>
            {
                {"@id",userId}
            })[0];
        }
        public virtual PlayerDto GetOneByEmail(string email)
        {
            string query = @"Select u.Id, u.FirstName, u.SecondName as  LastName, u.Password, u.Email, 
                             (Select r.RoleName from Role r where r.Id = u.RoleId) as Role, p.Rank, p.Wins, p.Loses from Player p
                             inner join User u on u.Id = p.UserId
                             where u.Email = @Email;";
            return _context.Get<PlayerDto>(query, new Dictionary<string, dynamic>
            {
                {"@Email",email}
            })[0];
        }

        public virtual void Update(PlayerDto user)
        {
            string query = @"Update User u 
                            inner join Player p on  u.Id = p.UserId
                            Set u.FirstName = @firstname,  u.SecondName =@lastName,  u.Password =@Password,
                            u.Email = @Email, p.Rank = @Rank,  p.Wins = @Wins,  p.Loses= @Loses
                            WHERE u.Id = @Id;";
            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>()
            {
                {"@Id", user.Id},
                {"@firstname", user.FirstName },
                {"@lastName",user.LastName },
                {"@Password",user.Password },
                {"@Email", user.Email},
                {"@Wins", user.Wins},
                {"@Loses", user.Loses},
                {"@Rank", user.Rank}
            });
        }

       
    }
}
