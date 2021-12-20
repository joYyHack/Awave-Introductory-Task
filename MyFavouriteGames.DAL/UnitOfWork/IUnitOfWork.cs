using MyFavouriteGames.DAL.Repo.IRepo;

namespace MyFavouriteGames.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepo UserRepo { get; }
        IGameRepo GameRepo { get; }
    }
}
