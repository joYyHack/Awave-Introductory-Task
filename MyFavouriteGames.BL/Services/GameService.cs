using MyFavouriteGames.BL.Services.IServices;
using MyFavouriteGames.DAL.Models;
using MyFavouriteGames.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavouriteGames.BL.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork mainRepo;

        public GameService(IUnitOfWork mainRepo) => this.mainRepo = mainRepo;

        public async Task<List<Game>> GetAllAsync() => (await mainRepo.GameRepo.GetAllAsync()).ToList();
    }
}
