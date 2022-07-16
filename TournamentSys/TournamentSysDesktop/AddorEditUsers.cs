using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentSysData.DTOs;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.RoleLogic;
using TournamentSysLogic.Services.UserLogic;

namespace TournamentSysDesktop
{
    public partial class AddorEditUsers : Form
    {
        private readonly UserService _userService;
        private readonly PlayerService _playerService;
        private readonly RoleService _roleService;

        private bool _editMode = false;
        private string _userToEditId;
        private Dictionary<string, string> _idAndRoleDict;

        public AddorEditUsers()
        {
            _userService = new UserService();
            _roleService = new RoleService();
            _playerService = new PlayerService();
            _idAndRoleDict = new Dictionary<string, string>();
            InitializeComponent();
            FillTheRoles();

        }
        public AddorEditUsers(UserDto user)
        {
            _userService = new UserService();
            _playerService = new PlayerService();
            _roleService = new RoleService();
            _editMode = true;
            _userToEditId = user.Id;
            _idAndRoleDict = new Dictionary<string, string>();

            InitializeComponent();
            FillTheRoles();

            firstNametb.Text = user.FirstName;
            secondNameTb.Text= user.LastName;
            passwordTb.Text = user.Password;
            emailTb.Text = user.Email;
            roleCb.Text = user.Role;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
             try
            {
                UserDto userDto = new UserDto(
                    firstNametb.Text, secondNameTb.Text, passwordTb.Text, emailTb.Text,
                    _idAndRoleDict.FirstOrDefault(x => x.Value == roleCb.Text).Key);
                if (_editMode)
                {
                    userDto.Id = _userToEditId;
                    _userService.Update(userDto);
                }
                else
                {
                    if (roleCb.Text == "Player")
                    {
                        var player = new PlayerDto
                        {
                            Email = userDto.Email,
                            Rank = "no rank",
                            FirstName = userDto.FirstName,
                            LastName = userDto.LastName,
                            Id = userDto.Id,
                            Role = userDto.Role,
                            Loses = "0",
                            Password = userDto.Password,
                            Wins = "0",
                        };
                        _playerService.Create(player);
                    }
                    else
                    {
                        _userService.Create(userDto);
                    }
                }
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void FillTheRoles()
        {
            foreach (var role in _roleService.GetAll())
            {
                _idAndRoleDict.Add(role.Id, role.RoleName);
            }
            roleCb.Items.AddRange(_idAndRoleDict.Values.ToArray());
        }

        private void AddorEditUsers_Load(object sender, EventArgs e)
        {

        }
    }
}
