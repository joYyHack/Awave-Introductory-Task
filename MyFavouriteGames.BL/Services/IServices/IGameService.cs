using MyFavouriteGames.BL.DTO;
using MyFavouriteGames.DAL;
using MyFavouriteGames.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyFavouriteGames.BL.Services.IServices
{
    public interface IGameService
    {
        Task<List<Game>> GetAllAsync();

        Task<List<Game>> GetByExpressionAsync(Expression<Func<Game, bool>> filter);

        Task<Game> GetByIdAsync(int id);

        Task<Result> VoteForGameAsync(UserGameDTO dto);

        double GetGameAverageRating(Game game, int maxPossibleRank);

        //TODO
        //Task<List<Game>> GetTop100GamesFromWebAndSetToDbAsync();
    }
}
