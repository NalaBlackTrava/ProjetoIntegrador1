using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ProjetoIntegrador.Data
{
    public sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = config.GetConnectionString("Context");
            builder.UseNpgsql(connectionString);
            return new DataContext(builder.Options);
        }
    }
}