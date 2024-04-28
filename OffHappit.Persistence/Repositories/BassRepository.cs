using Microsoft.EntityFrameworkCore;
using OffHappit.Application.Contracts;
using OffHappit.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Persistence.Repositories
{
    public class BassRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly OffHappitsDbContext _dbContext;
        public BassRepository(OffHappitsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            var createdEntity = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            var listOfEntities = await _dbContext.Set<T>().ToListAsync();
            return listOfEntities;
        }

        public async  Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
