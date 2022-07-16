using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.SystemLogic;
using TournamentSysLogic.Services.TournamentLogic;

namespace TournamentSysDesktop
{
    public partial class CreateTournament : Form
    {
        private readonly TournamentService _tournamentService;
        private readonly SystemService _systemService;
        private bool _editMode;
        private string _trId;
        public CreateTournament()
        {
            _editMode = false;
            InitializeComponent();
            _tournamentService = new TournamentService();
            _systemService = new SystemService();
            SystemTb.Items.AddRange(_systemService.GetAll().Select(x => x.SystemName).ToArray());
            startDate.Value = DateTime.Now;
            endDate.Value = DateTime.Now;
        }

        public CreateTournament(TournamentDto tr)
        {
            InitializeComponent();
            _tournamentService = new TournamentService();
            _systemService = new SystemService();
            SystemTb.Items.AddRange(_systemService.GetAll().Select(x => x.SystemName).ToArray());


            _editMode = true;
            _trId = tr.Id;
            decrTb.Text = tr.Description;
            startDate.Value = tr.StartDate;
            endDate.Value = tr.EndDate;
            SystemTb.Text = tr.SystemName;
            minPlayersNum.Value = tr.MinPlayers;
            maxPlayerNm.Value = tr.MaxPlayers;
            LocationTb.Text = tr.Location;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TournamentDto tr = new TournamentDto()
            {
                Description = decrTb.Text,
                StartDate = startDate.Value,
                EndDate = endDate.Value,
                SystemName = SystemTb.Text,
                MinPlayers = int.Parse(minPlayersNum.Value.ToString()),
                MaxPlayers = int.Parse(maxPlayerNm.Value.ToString()),
                Location = LocationTb.Text
            };
            if (HasEmptyVaslues(tr) && ValidateTournamentValues(tr))
            {

                if (_editMode)
                    Edit(tr);
                else
                    Create(tr);
                this.Hide();
            }

        }
        public void Edit(TournamentDto tr)
        {
            tr.Id = _trId;
            _tournamentService.Update(tr);
        }
        public void Create(TournamentDto tr)
        {
            _tournamentService.Create(tr);
        }

        public bool ValidateTournamentValues(TournamentDto tr)
        {
            if (DateTime.Compare(tr.StartDate, tr.EndDate) > 0|| tr.EndDate == DateTime.Now || tr.StartDate == DateTime.Now)
            {
                MessageBox.Show("Dates are incorrect. Please check them again and resubmit.");
                return false;

            }
            else if (tr.MinPlayers > tr.MaxPlayers || tr.MaxPlayers < 0 || tr.MaxPlayers < 0)
            {
                MessageBox.Show("Maximal or Minimal player counts are incorrect. Please check them again and resubmit.");
                return false;
            }
            else
                return true;
        }
        public bool HasEmptyVaslues(TournamentDto tr)
        {
            if (tr.Description == "" ||
                 tr.Location == "" ||
                 tr.SystemName == "" ||
                 tr.EndDate == null ||
                 tr.StartDate == null ||
                 tr.MinPlayers == 0 ||
                 tr.MaxPlayers == 0)
            {
                MessageBox.Show("All fields should be filled");
                return false;
            }
            else
                return true;
        }
    }
}