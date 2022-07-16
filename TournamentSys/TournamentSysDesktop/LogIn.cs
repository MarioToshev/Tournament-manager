using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentSysLogic.Models.ViewModels.UserViewModels;
using TournamentSysLogic.Services.UserLogic;

namespace TournamentSysDesktop
{
    public partial class LogIn : Form
    {
        public readonly LoginService _loginService;
        public readonly UserService _userService;
        public LogIn()
        {
            InitializeComponent();
            _loginService = new LoginService();
            _userService = new UserService();
            passwordTb.PasswordChar = '*';
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            LogInUserViewModel user = new LogInUserViewModel { Email = emailTb.Text, Password = passwordTb.Text};
            errMessagelbl.Text = "";
            if (_loginService.CheckIfCredentialsAreCorrect(user, new List<string>() {"Staff"}))
            {
                Home form = new Home();
                form.Show();
                this.Hide();
            }
            else
            {
                errMessagelbl.Text = "Invalid credentials";
            }
        }
    }
}
