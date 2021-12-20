using MyFavouriteGames.BL.DTO;
using MyFavouriteGames.DAL;
using MyFavouriteGames.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFavouriteGames.BL.Services.IServices
{
    public interface IUserService
    {
        Task<List<User>> GetAllOrderedByDateAsync();

        Task<User> GetByEmaiAsync(string email);

        Task<Result> CreateUserWithVotedGameAsync(UserGameDTO dto);

        Task<Result> AddVotedGameAsync(UserGameDTO dto);

        Task<int> GetUsersCountAsync();
    }
}
