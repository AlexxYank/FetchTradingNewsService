using System;

namespace Application.Interfaces;

public interface INewsBackgroundService
{
    Task StartAsync(CancellationToken cancellationToken);

    Task StopAsync(CancellationToken cancellationToken);
}

