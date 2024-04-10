using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql;
using ProjetoIntegrador.Data;
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
            var repositoryInterfaces = typeof(IRepository<>).Assembly.GetTypes().Where(x => x.IsInterface && x.GetInterfaces().FirstOrDefault()?.IsGenericType == true
            && x.GetInterfaces().FirstOrDefault()?.GetGenericTypeDefinition() == typeof(IRepository<>));
            var infraTypes = typeof(Repository<>).Assembly.GetTypes();

            foreach (var repositoryInterface in repositoryInterfaces)
            {
                var infraType = infraTypes.First(x => repositoryInterface.IsAssignableFrom(x));
                services.AddScoped(repositoryInterface, infraType);
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