using System;
using Microsoft.Extensions.DependencyInjection;

namespace AVATrade.Application.Extensions
{
	public static class ServiceCollectionExtensions
	{
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            //services.AddScoped<ILoggerService, LoggerService>();
        }
    }
}

