using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DTOs;

namespace TournamentSysLogic.Models.DTOs
{
    public class PlayerDto:UserDto
    {
        private string rank;
        private string wins;
        private string loses;


        public PlayerDto(string firstName, string lastName, string password, string email,string rank, string wins, string loses, string role) 
            : base(firstName, lastName, password, email, role)
        {
            this.Rank = rank;
            this.Wins = wins;
            this.Loses = loses;
        }
        public PlayerDto() { }

        public string Rank
        {
            get => rank; 
            set => rank = value; 
        }

        public string Wins
        {
            get =>  wins; 
            set => wins = value; 
        }

        public string Loses
        {
            get => loses; 
            set => loses = value; 
        }
    }
}
