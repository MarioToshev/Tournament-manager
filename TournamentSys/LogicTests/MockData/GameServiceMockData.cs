using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData.DataServices;
using TournamentSysLogic.Models.DTOs;

namespace LogicTests.MockData
{
    public class GameServiceMockData : GameDataService
    {
        public List<GameDto> Games { get; set; }
        public GameServiceMockData()
        {
            Games = new List<GameDto>();
        }
        public override void Create(GameDto obj)
        {
            Games.Add(obj);
        }
        public override void CreateMultiple(List<GameDto> games)
        {
            foreach (var game in games)
            {
                games.Add(game);
            }
        }
        public override void Delete(string id)
        {
            Games.Remove(GetOne(id));
        }
        public override List<GameDto> GetAll()
        {
            return Games;
        }
        public override void Update(GameDto obj)
        {
            Games[Games.IndexOf(GetOne(obj.Id))] = obj;
        }
        public override GameDto GetOne(string id)
        {
            return Games.FirstOrDefault(x => x.Id == id);
        }
        public override List<GameDto> GetAllTournamentGames(string trId)
        {
            return Games.Where(x => x.TournamentId == trId).ToList();
        }
    }
}
