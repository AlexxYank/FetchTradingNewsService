using System;
using AVATrade.Application.Interfaces;
using AVATrade.Domain.Models;
using AVATrade.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AVATrade.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static void ConfigureInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<AVATradeDbContext>(options => options.UseSqlServer(ConnectionString.BuildConnection()));

        services.AddScoped<IGenericRepository<NewsArticle>, GenericRepository<NewsArticle>>();

        services.AddScoped<IGenericRepository<Publisher>, GenericRepository<Publisher>>();

        services.AddScoped<IGenericRepository<Ticker>, GenericRepository<Ticker>>();

        services.AddScoped<IGenericRepository<Keyword>, GenericRepository<Keyword>>();
    }
}

