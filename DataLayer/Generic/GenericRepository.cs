using DataLayer.Infraestructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Generic
{
    public class GenericRepository<TDbContext, TEntity> : IRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        public TDbContext _context { get; private set; }

        public GenericRepository(TDbContext context)
        {
            _context = context;
        }

        public virtual TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual ICollection<TEntity> All()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual async Task<ICollection<TEntity>> AllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public int Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.FirstOrDefault(filter);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.FirstOrDefaultAsync(filter);
        }

        public virtual TEntity Update(TEntity updated, object key)
        {
            if (updated == null)
                return null;

            TEntity existing = _context.Set<TEntity>().Find(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                _context.Entry(existing).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return existing;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity updated, object key)
        {
            if (updated == null)
                return default(TEntity);

            TEntity existing = await _context.Set<TEntity>().FindAsync(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                _context.Entry(existing).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return existing;
        }
    }
}
