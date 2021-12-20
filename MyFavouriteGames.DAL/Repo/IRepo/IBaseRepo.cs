using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyFavouriteGames.DAL.Repo.IRepo
{
    public interface IBaseRepo<T>
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetByExpression(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll();
        Task<Result> CreateAsync(T entity);
        Task<Result> UpdateAsync(T entity);
        Task<Result> DeleteAsync(T entity);
    }
}
