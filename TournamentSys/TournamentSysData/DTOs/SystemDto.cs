using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentSysLogic.Models.DTOs
{
    public class SystemDto
    {
        public string id;
        private string systemName;

        public SystemDto()
        {
            Id = Guid.NewGuid().ToString();
        }
        public SystemDto(string SystemName)
        {
            id = Guid.NewGuid().ToString();
            this.SystemName = SystemName;
        }
        public string Id
        {
            get => id;
            set => id = value;
        }
        public string SystemName
        {
            get => systemName;
            set => systemName = value;
        }
    }
}
