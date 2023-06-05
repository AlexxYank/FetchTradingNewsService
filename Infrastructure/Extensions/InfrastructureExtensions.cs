using System;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static void ConfigureInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<FetchTradingNewsDbContext>(options => options.UseSqlServer(ConnectionString.BuildConnection()));

        services.AddScoped<IGenericRepository<NewsArticle>, GenericRepository<NewsArticle>>();
    }

    public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetService<FetchTradingNewsDbContext>();

            dbContext.Database.Migrate();
        }

        return app;
    }
}

