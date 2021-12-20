using Microsoft.EntityFrameworkCore;
using MyFavouriteGames.DAL.Context;
using MyFavouriteGames.DAL.Repo.IRepo;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyFavouriteGames.DAL.Repo
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        protected readonly MyFavouriteGamesDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public BaseRepo(MyFavouriteGamesDbContext dbContext) => (this.dbContext, dbSet) = (dbContext, dbContext.Set<T>());

        public virtual IQueryable<T> GetAll() => dbSet;

        public virtual async Task<T> GetByIdAsync(int id) => await dbSet.FindAsync(id);

        public virtual IQueryable<T> GetByExpression(Expression<Func<T, bool>> filter) => dbSet.Where(filter);

        public virtual async Task<Result> CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return await SaveChangesAsync();
        }

        public virtual async Task<Result> DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            return await SaveChangesAsync();
        }

        public virtual async Task<Result> UpdateAsync(T entity)
        {
            dbSet.Remove(entity);
            return await SaveChangesAsync();
        }

        private async Task<Result> SaveChangesAsync()
        {
            try
            {
                await dbContext.SaveChangesAsync();
                return new Result(true);
            }
            catch (Exception e)
            {
                return new Result(false, e.Message);
            }
        }
    }
}
