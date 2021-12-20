using Microsoft.EntityFrameworkCore;
using MyFavouriteGames.DAL.Context;
using MyFavouriteGames.DAL.Models;
using MyFavouriteGames.DAL.Repo.IRepo;
using System.Linq;

namespace MyFavouriteGames.DAL.Repo
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(MyFavouriteGamesDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<User> GetAll() => dbContext.Users.Include(g => g.VotedGames);
    }
}
