using System;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class NewsBackgroundService : INewsBackgroundService, IHostedService
{
    private Timer _timer;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<NewsBackgroundService> _logger;

    public NewsBackgroundService(IServiceScopeFactory serviceScopeFactory, ILogger<NewsBackgroundService> logger)
    {
        this._serviceScopeFactory = serviceScopeFactory;
        this._logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        TimeSpan interval = TimeSpan.FromHours(1);
        _timer = new Timer(ExecuteFetchNews, null, TimeSpan.Zero, interval);

        return Task.CompletedTask;
    }

    private async void ExecuteFetchNews(object state)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var dataService = scope.ServiceProvider.GetRequiredService<IDataService>();
            try
            {
                await dataService.FetchAndStoreData();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching news.");
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        _timer?.Dispose();

        return Task.CompletedTask;
    }
}

