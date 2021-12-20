using Microsoft.EntityFrameworkCore;
using MyFavouriteGames.DAL.Context;
using MyFavouriteGames.DAL.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavouriteGames.DAL.Repo
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        protected readonly MyFavouriteGamesDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public BaseRepo(MyFavouriteGamesDbContext dbContext) => (this.dbContext, dbSet) = (dbContext, this.dbContext.Set<T>());

        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
