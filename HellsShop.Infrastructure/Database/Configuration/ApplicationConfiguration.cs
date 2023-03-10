using HellsShop.Application.Services.Interfaces;
using HellsShop.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HellsShop.Infrastructure.Database.Configuration
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString, Assembly mappingAssembly)
        {
            services.AddDbContext<DatabaseContext>(opt =>
            {
                opt.UseSqlite(connectionString, config =>
                {
                    config.MigrationsAssembly(mappingAssembly.GetName().Name);
                    config.MigrationsHistoryTable("migration_history", "dbo");
                });

                opt.EnableDetailedErrors(true);
                opt.ConfigureWarnings(e =>
                {
                    e.Default(WarningBehavior.Log);
                });
            });
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IPriceRepository,PriceRepository>();
            return services;
        }

        public static IApplicationBuilder UseMigrations(this IApplicationBuilder app)
        {
            var databse = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DatabaseContext>();

            databse.Database.Migrate();

            return app;
        }
    }
}
