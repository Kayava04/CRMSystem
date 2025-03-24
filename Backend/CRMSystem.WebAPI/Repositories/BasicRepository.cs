using CRMSystem.WebAPI.Core;
using CRMSystem.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem.WebAPI.Repositories
{
    public class BasicRepository<T>(SchoolDbContext context)
        : IBasicRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<T?> UpdateAsync(Guid id, T entity)
        {
            var existingEntity = await _dbSet.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);

            if (existingEntity == null)
                return null;

            context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();

            return existingEntity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}