using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Domain.Interfaces;

namespace ProjetoIntegrador.Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DataContext _context;
        public readonly DbSet<T> _set;

        public Repository(DataContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public IQueryable<T> Query => _set.AsQueryable();

        public ValueTask<T> FindAsync(long id)
        {
            return _set.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _set.Remove(entity);
        }

        public async Task<T> SaveAsync(T entity)
        {
            _set.Add(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpsetAsync(T entity)
        {
            if (entity.Id < 1)
                await SaveAsync(entity);
            else
                await UpdateAsync(entity);
            return entity;
        }
    }
}
