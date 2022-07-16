using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentSysData.DTOs.User;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.GameLogic;
using TournamentSysLogic.Services.MapperLogic;
using TournamentSysLogic.Services.TournamentLogic;
using TournamentSysLogic.Services.UserLogic;

namespace TournamentSysDesktop
{
    public partial class Home : Form
    {
        public readonly TournamentService _tournamentService;
        public readonly GameService _gameService;
        public readonly RobinRoundGameGenerator _roundRobinShceduleService;
        public readonly SingleEleminationGameGenerator _singleEleminationShceduleService;
        public readonly PlayerService _playerService;
        public readonly Mapper _mapper;




        public Home()
        {
            InitializeComponent();
            _tournamentService = new TournamentService();
            _gameService = new GameService();
            _roundRobinShceduleService = new RobinRoundGameGenerator();
            _singleEleminationShceduleService = new SingleEleminationGameGenerator();
            _playerService = new PlayerService();
            _mapper = new Mapper();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void AddTournament_Click(object sender, EventArgs e)
        {
            CreateTournament form = new CreateTournament();
            form.Show();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (TournamentsLb.SelectedItem != null)
            {
                CreateTournament form = new CreateTournament((TournamentDto)TournamentsLb.SelectedItem);
                form.Show();
            }
            else
                MessageBox.Show("Select an item first");
        }

        private void ShowGamesBtn_Click(object sender, EventArgs e)
        {
            if (TournamentsLb.SelectedItem != null)
            {
                TournamentDto tr = (TournamentDto)TournamentsLb.SelectedItem;
                if (DateTime.Compare(DateTime.Now, tr.StartDate) < 0)
                {
                    MessageBox.Show($"Tournament has to start before generating the games. Wait until {tr.StartDate}");
                }

                List<BaseDataPlayerDto> players = _playerService.GetAllFromTournament(tr.Id)
                                          .Select(x => _mapper.MapToBaseDataPlayerDto(x)).ToList();
                if (tr.MinPlayers <= players.Count())
                {
                    List<GameDto> games = new List<GameDto>();
                     if (tr.SystemName == "Robin Round")
                     {
                        games =
                        _roundRobinShceduleService.GenerateAndSaveIfNotExistingRobinRoundGames(players, tr.Id);
                     }
                    else if (tr.SystemName == "Single Elemination")
                    {
                        games =
                       _singleEleminationShceduleService.GenerateOrReturnSingleEleminationGames(players, tr.Id);
                    }
                    AllGames form = new AllGames(games);
                    form.Show();
                }
                else
                {
                    MessageBox.Show("The tournament needs more players to start");
                }
            }
            else
                MessageBox.Show("Select an item first");
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        public void RefreshList()
        {
            TournamentsLb.Items.Clear();
            foreach (var tr in _tournamentService.GetAll())
            {
                TournamentsLb.Items.Add(tr);
            }
        }

        private void manageUsersBtn_Click(object sender, EventArgs e)
        {
            UserManager form = new UserManager();
            form.Show();
        }
    }
}
