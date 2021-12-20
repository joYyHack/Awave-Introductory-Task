using Microsoft.EntityFrameworkCore;
using MyFavouriteGames.DAL.Context;
using MyFavouriteGames.DAL.Models;
using MyFavouriteGames.DAL.Repo.IRepo;
using System.Linq;

namespace MyFavouriteGames.DAL.Repo
{
    public class GameRepo : BaseRepo<Game>, IGameRepo
    {
        public GameRepo(MyFavouriteGamesDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Game> GetAll() => dbContext.Games.Include(g => g.VotedUsers);
    }
}
