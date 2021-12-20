using Microsoft.EntityFrameworkCore;
using MyFavouriteGames.BL.DTO;
using MyFavouriteGames.BL.Services.IServices;
using MyFavouriteGames.DAL;
using MyFavouriteGames.DAL.Models;
using MyFavouriteGames.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyFavouriteGames.BL.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork mainRepo;
        private readonly IUserService userService;

        public GameService(IUnitOfWork mainRepo, IUserService userService) => (this.mainRepo, this.userService) = (mainRepo, userService);

        public async Task<List<Game>> GetAllAsync() => await mainRepo.GameRepo.GetAll().ToListAsync();

        public async Task<List<Game>> GetByExpressionAsync(Expression<Func<Game, bool>> filter) => await mainRepo.GameRepo.GetByExpression(filter).ToListAsync();

        public async Task<Game> GetByIdAsync(int id) => await mainRepo.GameRepo.GetByIdAsync(id);

        public double GetGameAverageRating(Game game, int maxPossibleRank)
        {
            var totalRank = game.VotedUsers.Sum(u => u.VotedRank);
            return Math.Round((double)totalRank / maxPossibleRank * 100, 2);
        }

        public async Task<Result> VoteForGameAsync(UserGameDTO dto)
        {
            try
            {
                var user = await userService.GetByEmaiAsync(dto.User.Email);

                if (user == null)
                {
                    var createdUserResult = await userService.CreateUserWithVotedGameAsync(dto);

                    if (!createdUserResult.IsSuccessful)
                        throw new Exception(message: createdUserResult.ErrorsFormatted);

                    var createdUser = await userService.GetByEmaiAsync(dto.User.Email);

                    await AddVotedUserForGame(dto);
                }
                else
                {
                    var addedGameResult = await userService.AddVotedGameAsync(dto);
                    if (!addedGameResult.IsSuccessful)
                        throw new Exception(message: addedGameResult.ErrorsFormatted);

                    await AddVotedUserForGame(dto);
                }

                return new Result(isSuccessful: true);
            }
            catch (Exception ex)
            {
                return new Result(isSuccessful: false, errors: ex.Message);
            }
        }

        private async Task<Result> AddVotedUserForGame(UserGameDTO dto)
        {
            try
            {
                if (dto.Game.VotedUsers == null)
                    dto.Game.VotedUsers = new List<UserGame> { new UserGame { UserId = dto.User.Id, User = dto.User, VotedRank = dto.VotedRank, GameComment = dto.GameComment } };
                else
                    dto.Game.VotedUsers.Add(new UserGame { UserId = dto.User.Id, User = dto.User, VotedRank = dto.VotedRank, GameComment = dto.GameComment });

                await mainRepo.GameRepo.UpdateAsync(dto.Game);

                return new Result(isSuccessful: true);
            }
            catch (Exception ex)
            {
                return new Result(isSuccessful: false, errors: ex.Message);
            }
        }
    }
}
