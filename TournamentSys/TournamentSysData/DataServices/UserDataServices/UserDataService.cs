using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DTOs;

namespace TournamentSysData.DataServices.UserDataServices
{
    public class UserDataService : IUserDataService
    {
        private readonly DatabaseComunication _context;
        public UserDataService()
        {
            _context = new DatabaseComunication();
        }
        public virtual void Create(UserDto user, string roleName)
        {
            string query = @"Insert into `User`(Id,FirstName,SecondName,Password,PasswordSalt,Email, RoleId)
                            Values( @Id, @firstname, @lastName, @Password,@PasswordSalt, @Email, (Select Id from Role where RoleName = @Role));";
            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", user.Id},
                {"@firstname", user.FirstName },
                {"@lastName",user.LastName },
                {"@Password",user.Password },
                {"@PasswordSalt",user.PasswordSalt },
                {"@Email", user.Email},
                {"@Role", roleName}
            });
        }

        public virtual void CreateWithRoleId(UserDto user)
        {
            string query = @"Insert into `User`(Id,FirstName,SecondName,Password,PasswordSalt,Email, RoleId)
                            Values( @Id, @firstname, @lastName, @Password,@PasswordSalt, @Email, @RoleId);";
            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", user.Id},
                {"@firstname", user.FirstName },
                {"@lastName",user.LastName },
                {"@Password",user.Password },
                {"@PasswordSalt",user.PasswordSalt },
                {"@Email", user.Email},
                {"@RoleId", user.Role}
            });
        }

        public virtual UserDto GetOneByEmail(string email)
        {
            try
            {
                string query = @"Select u.Id,u.FirstName,u.SecondName,u.Password,u.PasswordSalt,u.Email,
                    (Select r.RoleName from Role r where r.Id = u.RoleId) as Role from User u
                    where u.Email = @Email";

                return _context.Get<UserDto>(query, new Dictionary<string, dynamic>
            {
                {"@Email",email}
            })[0];
            }
            catch (Exception)
            {
                return new UserDto();
            }

        }

        public virtual void Delete(string userId)
        {
            string query = @"
                        SET FOREIGN_KEY_CHECKS=0;
                        delete from User where Id = @Id;
                        SET FOREIGN_KEY_CHECKS=1;
                         ";
            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>
            {
                {"@Id", userId},
            });
        }

        public virtual List<UserDto> GetAll()
        {
            string query = @"Select Id,FirstName,SecondName as LastName,Password,PasswordSalt,Email,
                    (Select RoleName from Role where Id = RoleId) as Role from User";
            return _context.Get<UserDto>(query, new Dictionary<string, dynamic> {});
        }
        public virtual List<UserDto> GetAll(string role)
        {
            string query = @"Select Id,FirstName,SecondName as LastName,Password,PasswordSalt,Email,
                    (Select RoleName from Role where Id = RoleId) as Role from User
                     order by Role = @RoleName;";

            return _context.Get<UserDto>(query, new Dictionary<string, dynamic> {
                {"@RoleName",role }
                });
        }
        public virtual UserDto GetOne(string userId)
        {
            string query = @"SelectId,FirstName,SecondName,Password,PasswordSalt,Email,
                    (Select Id from Role where Id = RoleId) as Role from User
                     where Id = @id";
            return _context.Get<UserDto>(query, new Dictionary<string, dynamic>
            {
                {"@id",userId}
            })[0];
        }

        public virtual void Update(UserDto user)
        {
            string query = @"Update User Set FirstName = @FirstName,SecondName = @lastName,Password = @Password,PasswordSalt = @PasswordSalt,Email = @Email
                             Where Id = @Id";
            _context.SendQueryWithNoResult(query, new Dictionary<string, dynamic>()
            {
                 {"@Id", user.Id},
                {"@firstname", user.FirstName },
                {"@lastName",user.LastName },
                {"@Password",user.Password },
                {"@PasswordSalt",user.PasswordSalt },
                {"@Email", user.Email}
            });
        }
    }
}
