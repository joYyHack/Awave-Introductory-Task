using Microsoft.EntityFrameworkCore;
using MyFavouriteGames.BL.DTO;
using MyFavouriteGames.BL.Services.IServices;
using MyFavouriteGames.DAL;
using MyFavouriteGames.DAL.Models;
using MyFavouriteGames.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFavouriteGames.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork mainRepo;

        public UserService(IUnitOfWork mainRepo) => this.mainRepo = mainRepo;

        public async Task<List<User>> GetAllOrderedByDateAsync() => await mainRepo.UserRepo.GetAll().OrderByDescending(u => u.LastTimeVotedDate).ToListAsync();

        public async Task<User> GetByEmaiAsync(string email) => await mainRepo.UserRepo.GetByExpression(u => u.Email.ToLower() == email.ToLower())?.FirstOrDefaultAsync();

        public async Task<int> GetUsersCountAsync() => await mainRepo.UserRepo.GetAll().CountAsync();

        public async Task<Result> AddVotedGameAsync(UserGameDTO dto)
        {
            dto.User.VotedGames.Add(new UserGame { GameId = dto.Game.Id, Game = dto.Game, VotedRank = dto.VotedRank, GameComment = dto.GameComment });
            var result = await mainRepo.UserRepo.UpdateAsync(dto.User);

            return result.IsSuccessful ? new Result(isSuccessful: true) : new Result(isSuccessful: false, errors: result.ErrorsFormatted);
        }

        public async Task<Result> CreateUserWithVotedGameAsync(UserGameDTO dto)
        {
            dto.User.VotedGames = new List<UserGame> { new UserGame { GameId = dto.Game.Id, Game = dto.Game, VotedRank = dto.VotedRank, GameComment = dto.GameComment } };
            var result = await mainRepo.UserRepo.CreateAsync(dto.User);

            return result.IsSuccessful ? new Result(isSuccessful: true) : new Result(isSuccessful: false, errors: result.ErrorsFormatted);
        }
    }
}
