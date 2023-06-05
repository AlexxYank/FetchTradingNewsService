using System;

namespace Application.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task Create(TEntity entity);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}

