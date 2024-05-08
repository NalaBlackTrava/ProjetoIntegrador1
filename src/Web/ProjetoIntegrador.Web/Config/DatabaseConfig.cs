using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql;
using ProjetoIntegrador.Data;
using ProjetoIntegrador.Domain.Entity;
using ProjetoIntegrador.Domain.Interfaces;

namespace ProjetoIntegrador.Config
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services,
            IConfiguration config)
        {
            var connection = new NpgsqlConnectionStringBuilder(config.GetConnectionString("FinancialAdvisorContext"));
            connection.Database = "FinancialAdvisor";
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(connection.ToString(),
                       b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName));
                options.EnableSensitiveDataLogging(true);
                options.UseLazyLoadingProxies();
                options.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            var infraTypes = typeof(IRepository<>).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(DomainEntity)));

            foreach (var @type in infraTypes)
            {
                var addType = typeof(Repository<>).MakeGenericType(@type);
                var interfaceType = typeof(IRepository<>).MakeGenericType(@type);
                services.AddScoped(interfaceType, addType);
            }

            return services;
        }

        public static IApplicationBuilder UseEnsureMigrations(this IApplicationBuilder app, IConfiguration config)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var context = serviceScope.ServiceProvider.GetService<DataContext>();
            var connection = new NpgsqlConnectionStringBuilder(config.GetConnectionString("Context"));
            connection.Database = "ProjetoIntegrador";
            context.Database.SetConnectionString(connection.ConnectionString);
            if (context == null) return app;

            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            return app;
        }
    }
}