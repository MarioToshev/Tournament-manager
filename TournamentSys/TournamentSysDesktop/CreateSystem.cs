using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.SystemLogic;

namespace TournamentSysDesktop
{
    public partial class CreateSystem : Form
    {
        private readonly SystemService _systemService;
        public CreateSystem()
        {
            InitializeComponent();
            _systemService = new SystemService();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            _systemService.Create(new SystemDto(SystemTb.Text));
        }
    }
}
