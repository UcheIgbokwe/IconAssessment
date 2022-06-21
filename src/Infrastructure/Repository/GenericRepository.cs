using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Infrastructure.Repository;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataContext _dbcontext;
        internal DbSet<T> _dbSet;
        public readonly ILogger _logger;
        public GenericRepository(DataContext dbContext, ILogger logger)
        {
            _dbcontext = dbContext;
            _logger = logger;
            _dbSet = dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }
        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public void Attach(T entity)
        {
            _dbSet.Attach(entity);
        }
        public void AttachRange(IEnumerable<T> entities)
        {
            _dbSet.AttachRange(entities);
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }
        public IQueryable<T> GetQuery()
        {
            return _dbSet.AsQueryable();
        }
    }
}