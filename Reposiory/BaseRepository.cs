using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Reposiory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly KitStemDBContext _dbContext;

        public BaseRepository(KitStemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected DbSet<T> _dbSet
        {
            get
            {
                var dbSet = GetDbSet<T>();
                return dbSet;
            }
        }

        protected DbSet<T> GetDbSet<T>() where T : BaseEntity
        {
            var dbSet = _dbContext.Set<T>();
            return dbSet;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void CheckCancellationToken(CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                throw new OperationCanceledException("Request was cancelled");
        }

        #region GetQueryable
        public IQueryable<T> GetQueryable(CancellationToken cancellationToken = default)
        {
            CheckCancellationToken(cancellationToken);
            var queryable = GetQueryable<T>();
            return queryable;
        }

        public IQueryable<T> GetQueryable<T>() where T : BaseEntity
        {
            IQueryable<T> queryable = GetDbSet<T>();
            return queryable;
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate)
        {
            var queryable = GetQueryable<T>();
            if (predicate != null) queryable = queryable.Where(predicate);
            return queryable;
        }
        #endregion
    }
}
