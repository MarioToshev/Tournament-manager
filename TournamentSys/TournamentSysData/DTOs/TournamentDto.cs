using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentSysLogic.Models.DTOs
{
    public class TournamentDto
    {
        private string id;
        private DateTime endDate;
        private DateTime startDate;
        private string systemName;
        private string description;
        private string location;
        private int minPlayers;
        private int maxPlayers;

        public TournamentDto()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public TournamentDto(DateTime startDate, DateTime endDate, string systemId, string description,
             string location, int minPlayers, int maxPlayers)
        {
            this.Id = Guid.NewGuid().ToString();
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Description = description;
            this.Location = location;
            this.MinPlayers = minPlayers;
            this.MaxPlayers = maxPlayers;
            this.systemName = systemId;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }
        public DateTime StartDate
        {
            get => startDate;
            set => startDate = value;
        }
        public DateTime EndDate
        {
            get => endDate;
            set => endDate = value;
        }
        public string SystemName
        {
            get => systemName;
            set => systemName = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public string Location
        {
            get => location;
            set => location = value;
        }


        public int MinPlayers
        {
            get => minPlayers;
            set => minPlayers = value;
        }

        public int MaxPlayers
        {
            get => maxPlayers;
            set => maxPlayers = value;
        }


        public override string ToString()
        {
            return $"A tournament in {Location} with min {MinPlayers} and max {MaxPlayers} players  Type: {SystemName}";
        }
    }
}
