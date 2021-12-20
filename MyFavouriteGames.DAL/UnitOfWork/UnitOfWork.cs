using MyFavouriteGames.DAL.Context;
using MyFavouriteGames.DAL.Repo;
using MyFavouriteGames.DAL.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavouriteGames.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MyFavouriteGamesDbContext dbContext;
        private IUserRepo userRepo;
        private IGameRepo gameRepo;

        public UnitOfWork(MyFavouriteGamesDbContext dbContext) => this.dbContext = dbContext;

        public IUserRepo UserRepo => userRepo ??= new UserRepo(dbContext);

        public IGameRepo GameRepo => gameRepo ??= new GameRepo(dbContext);

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
