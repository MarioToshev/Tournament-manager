using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentSysLogic.Models.DTOs
{
    public class GameDto
    {
        private string id;
        private string tournamentId;
        private string firstPlayerId;
        private string secondPlayerId;
        private int registered;
        private string score;

        public GameDto() { }
        public GameDto(string firstP, string secondP, string tournamentId,string score)
        {
            this.Id = Guid.NewGuid().ToString();
            this.FirstPlayerId = firstP;
            this.SecondPlayerId = secondP;
            this.Score = score;
            this.TournamentId = tournamentId;
        }
        public string Id
        {
            get => id;
            set => id = value;
        }
        public string FirstPlayerId
        {
            get => firstPlayerId;
            set => firstPlayerId = value;
        }
        public string SecondPlayerId
        {
            get => secondPlayerId;
            set => secondPlayerId = value;
        }
        //A string consisted of two numbers and a "/"  
        //Right part firstPlayer , Left part secondPlayer ex. -> "40/30"
        public string Score
        {
            get => score;
            set => score = value;
        }
        public string TournamentId
        {
            get => tournamentId;
            set => tournamentId = value;
        }
        public int Registered
        {
            get => registered;
            set => registered = value;
        }

        public string FirstPlayerNames { get; set; }
        public string SecondPlayerNames { get; set; }

        public override string ToString()
        {
            return $"{FirstPlayerNames} VS {SecondPlayerNames} Current Score: {Score}";
        }
    }
}
