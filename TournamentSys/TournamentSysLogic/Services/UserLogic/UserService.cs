using TournamentSysData.DataServices.UserDataServices;
using TournamentSysData.DTOs;
using TournamentSysLogic.Services.Interfaces;

namespace TournamentSysLogic.Services.UserLogic
{
    public class UserService : IMaintanable<UserDto>
    {
        private readonly UserDataService _service;
        private readonly PasswordEncryptionService _encriptionService;
        public UserService()
        {
            _service = new UserDataService();
            _encriptionService = new PasswordEncryptionService();
        }
        public UserService(UserDataService mockDataService)
        {
            _service = mockDataService;
            _encriptionService = new PasswordEncryptionService();
        }

        //Crud operations
        #region CRUD
        public virtual void Create(UserDto user)
        {
            if (GetOneByEmail(user.Email).Email == null)
            {
                user.PasswordSalt = _encriptionService.CreateSalt(5);
                user.Password = _encriptionService.GenerateHash(user.Password, user.PasswordSalt);
                _service.CreateWithRoleId(user);
            }
          
           
        }
        public void Create(UserDto user, string roleName)
        {

            if (GetOneByEmail(user.Email).Email == null)
            {
                user.PasswordSalt = _encriptionService.CreateSalt(5);
                user.Password = _encriptionService.GenerateHash(user.Password, user.PasswordSalt);
                _service.Create(user, roleName);
            }
            else
            {
                throw new ArgumentException("User with this email already exists");
            }
        }

        public void Delete(string userId)
        => _service.Delete(userId);
        
        public List<UserDto> GetAll(string? role)
        => _service.GetAll(role);
        public List<UserDto> GetAll()
        => _service.GetAll();

        public UserDto GetOne(string userId)
       => _service.GetOne(userId);
        public UserDto GetOneByEmail(string email)
       => _service.GetOneByEmail(email);

        public void Update(UserDto user)
        => _service.Update(user);
        #endregion

       
    }
}
