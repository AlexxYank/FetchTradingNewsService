using System;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    internal readonly FetchTradingNewsDbContext _TradingNews;

    public GenericRepository(FetchTradingNewsDbContext TradingNews)
    {
        this._TradingNews = TradingNews;
    }

    public async Task Create(TEntity entity)
       => await this._TradingNews.Set<TEntity>().AddAsync(entity);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
       => await this._TradingNews.SaveChangesAsync(cancellationToken);
}

