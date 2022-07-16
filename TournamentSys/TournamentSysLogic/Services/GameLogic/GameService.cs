using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSysData;
using TournamentSysData.DataServices;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.Interfaces;

namespace TournamentSysLogic.Services.GameLogic
{
    public class GameService : IMaintanable<GameDto>
    {
        private readonly DatabaseComunication _context;
        private readonly GameDataService _gameDataService;
        public GameService()
        {
            _context = new DatabaseComunication();
            _gameDataService = new GameDataService();
        }
        public GameService(GameDataService gameMockDataService)
        {
            _context = new DatabaseComunication();
            _gameDataService = gameMockDataService;
        }

        public void Create(GameDto obj)
        => _gameDataService.Create(obj);

        public void CreateMultiple(List<GameDto> games)
        => _gameDataService.CreateMultiple(games);

        public void Delete(string id)
        => _gameDataService.Delete(id);

        public List<GameDto> GetAll()
        => _gameDataService.GetAll();

        public List<GameDto> GetAllTournamentGames(string trId)
        => _gameDataService.GetAllTournamentGames(trId);

        public GameDto GetOne(string id)
        => _gameDataService.GetOne(id);

        public void Update(GameDto obj)
        => _gameDataService.Update(obj);
        public bool CheckIfScoreIsValidBadminton(int p1Score, int p2Score)
        {

            if (p1Score >= 20 && p2Score >= 20 && p1Score <= 30 && p2Score <= 30)
            {
                if (p1Score - p2Score >= 2 || p2Score - p1Score >= 2)
                {
                    return true;
                }
                if (p1Score == 30 || p2Score == 30)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
