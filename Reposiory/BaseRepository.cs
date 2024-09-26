using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Reposiory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly KitStemDBContext _dbContext;
        private DbSet<T> _dbSet;

        public BaseRepository(KitStemDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task add(T entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task deleteById(int id)
        {
            T entity = await getById(id);
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> getAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> getById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

    }
}
