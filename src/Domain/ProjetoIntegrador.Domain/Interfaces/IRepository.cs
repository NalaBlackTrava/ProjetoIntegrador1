namespace ProjetoIntegrador.Domain.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> Query { get; }
        ValueTask<T> FindAsync(long id);
        Task<T> SaveAsync(T entity);
        Task<T> UpsetAsync(T entity);
        void Remove(T entity);
        Task SaveChangesAsync();
        Task<T> UpdateAsync(T entity);
    }
}
