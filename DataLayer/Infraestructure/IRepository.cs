using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Infraestructure
{
    public interface IRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        TDbContext _context { get; }

        ICollection<TEntity> All();

        Task<ICollection<TEntity>> AllAsync();

        TEntity Find(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);

        TEntity Update(TEntity updated, object key);

        Task<TEntity> UpdateAsync(TEntity updated, object key);

        int Delete(TEntity entity);

        Task<int> DeleteAsync(TEntity entity);
    }
}
