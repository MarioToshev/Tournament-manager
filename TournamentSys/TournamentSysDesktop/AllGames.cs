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
using TournamentSysLogic.Services.GameLogic;
using TournamentSysLogic.Services.TournamentLogic;
using TournamentSysLogic.Services.UserLogic;

namespace TournamentSysDesktop
{
    public partial class AllGames : Form
    {
        private readonly GameService _gameService;
        private readonly TournamentService _tournamentService;
        private readonly PlayerService _playerService;
        private readonly string trId;


        public AllGames(List<GameDto> games)
        {
            _gameService = new GameService();
            _playerService = new PlayerService();
            InitializeComponent();
            trId = games[0].TournamentId;
            foreach (var game in games)
            {
                Gameslb.Items.Add(game);
            }
        }
        private void GamesRobinRound_Load(object sender, EventArgs e)
        {

        }

        private void addScore_Click(object sender, EventArgs e)
        {
            try
            {
                int p1Score = int.Parse(firstPlayerScore.Text);
                int p2Score = int.Parse(SecondPlayerScore.Text);
                if (p1Score > 0 &&
               p2Score > 0)
                {

                    if (_gameService.CheckIfScoreIsValidBadminton(p1Score, p2Score))
                    {
                        if (Gameslb.SelectedItem != null)
                        {
                            MessageBox.Show("Success!");
                            var game = (GameDto)Gameslb.SelectedItem;
                            game.Score = $"{p1Score}/{p2Score}";

                            if (game.Registered == 0)
                            {
                                PlayerDto pl1 = _playerService.GetOne(game.FirstPlayerId);
                                PlayerDto pl2 = _playerService.GetOne(game.SecondPlayerId);

                                if (p2Score > p1Score)
                                {
                                    pl2.Wins = (int.Parse(pl2.Wins) + 1).ToString();
                                    pl1.Loses = (int.Parse(pl2.Loses) + 1).ToString();
                                }
                                else
                                {
                                    pl1.Wins = (int.Parse(pl1.Wins) + 1).ToString();
                                    pl2.Loses = (int.Parse(pl2.Loses) + 1).ToString();
                                }
                                _playerService.Update(pl1);
                                _playerService.Update(pl2);
                                game.Registered = 1;
                            }

                            _gameService.Update(game);

                        }
                        else
                        {
                            MessageBox.Show("Select a game first");
                        }
                    }
                    else
                    {
                        MessageBox.Show("This is not a valid score for a Badminton game");
                    }
                }
                else
                {
                    MessageBox.Show("Score can not be less than 0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Fill the score first");
            }
            RefreshList();

        }
        private void RefreshList()
        {
            Gameslb.Items.Clear();
            _gameService.GetAllTournamentGames(trId).ForEach(x => Gameslb.Items.Add(x));
        }
    }
}
