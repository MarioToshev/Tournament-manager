using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DataServices.UserDataServices;
using TournamentSysData.DTOs;
using TournamentSysLogic.Services.Interfaces;
using TournamentSysLogic.Services.UserLogic;

namespace LogicTests.Entities
{
    public class UserServiceMockData:UserDataService
    {
        private static List<UserDto> _users;
        public UserServiceMockData()
        {
            _users = new List<UserDto>();
        }

        public override void CreateWithRoleId(UserDto obj)
        {
            _users.Add(obj);
        }
        public override void Create(UserDto obj, string role)
        {
            CreateWithRoleId(obj);
        }
        public override void Delete(string id)
        {
            _users.Remove(GetOne(id));
        }

        public override List<UserDto> GetAll()
        {
            return _users;
        }

        public override UserDto GetOne(string id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
        public override void Update(UserDto obj)
        {
            _users[_users.IndexOf(_users.FirstOrDefault(x => x.Id == obj.Id))] = obj;
        }
        public override UserDto GetOneByEmail(string email)
        {
            return _users.FirstOrDefault(x => x.Email == email);
        }
    }
}
