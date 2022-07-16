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
using TournamentSysLogic.Services.RoleLogic;
using TournamentSysLogic.Services.UserLogic;

namespace TournamentSysDesktop
{
    public partial class UserManager : Form
    {
        private readonly UserService _userService;
        private readonly RoleService _roleService;

        public UserManager()
        {
            _userService = new UserService();
            _roleService = new RoleService();

            InitializeComponent();
            _roleService.GetAll().ForEach(x => rolecb.Items.Add(x.RoleName));
            RefreshList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddorEditUsers form = new AddorEditUsers();
            form.Show();
        }

        private void editUserBtn_Click(object sender, EventArgs e)
        {
            if (allUsersLb.SelectedItem != null)
            {
                AddorEditUsers form = new AddorEditUsers((UserDto)allUsersLb.SelectedItem);
                form.Show();
            }
            else
            {
                MessageBox.Show("Select a user first");
            }
        }
         
        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            if (allUsersLb.SelectedItem != null)
            {
                DialogResult answer = MessageBox.Show("Are you sure that you want to delete that user",
                      "Delete user", MessageBoxButtons.YesNo);
                switch (answer)
                {
                    case DialogResult.Yes:
                        _userService.Delete(((UserDto)allUsersLb.SelectedItem).Id);
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Select a user first");
            }
        }

        private void RefreshList()
        {
            allUsersLb.Items.Clear();
            _userService.GetAll().Where(x => x.Role == rolecb.Text).ToList().ForEach(x => allUsersLb.Items.Add(x));
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void rolecb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }
    }
}
