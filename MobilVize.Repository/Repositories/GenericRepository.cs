using Microsoft.EntityFrameworkCore;
using MobilVize.Core.Entities;
using MobilVize.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _appDbContext;
        protected readonly  DbSet<T> _dbSet;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }

        public async Task<T> GetByIdAsyncTask(Guid id)
        {
            return await _dbSet.Where(x=>x.Id==id).AsNoTracking().FirstOrDefaultAsync();
        }

        public IQueryable<T> GetAllAsyncQueryable()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<T> WhereQueryable(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<bool> AnyAsyncTask(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task AddAsyncTask(T entity)
        {
           
            await _dbSet.AddAsync(entity);
            
            
        }

        public async Task AddRangeAsyncTask(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
