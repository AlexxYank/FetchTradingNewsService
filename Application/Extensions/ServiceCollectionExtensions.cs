using System;
using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IApiService, ApiService>();

        services.AddScoped<IDataService, DataService>();

        services.AddHostedService<NewsBackgroundService>();
    }
}

