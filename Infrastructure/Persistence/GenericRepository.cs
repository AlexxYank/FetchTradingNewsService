using System;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    internal readonly FetchTradingNewsDbContext _newsDbContext;

    public GenericRepository(FetchTradingNewsDbContext NewsDbContext)
    {
        this._newsDbContext = NewsDbContext;
    }

    public async Task Create(TEntity entity)
       => await this._newsDbContext.Set<TEntity>().AddAsync(entity);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
       => await this._newsDbContext.SaveChangesAsync(cancellationToken);
}

