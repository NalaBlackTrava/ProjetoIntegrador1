using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ProjetoIntegrador.Data
{
    public class DataContext : DbContext
    {
        public DbContext Context { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Context = this;
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.ApplyConfigurationsFromAssembly(typeof(DataContext).GetTypeInfo().Assembly);
        }
    }
}