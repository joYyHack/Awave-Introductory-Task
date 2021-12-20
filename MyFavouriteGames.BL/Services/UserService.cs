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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork mainRepo;

        public UserService(IUnitOfWork mainRepo) => this.mainRepo = mainRepo;

        public async Task<List<User>> GetAllAsync() => (await mainRepo.UserRepo.GetAllAsync()).ToList();
    }
}
