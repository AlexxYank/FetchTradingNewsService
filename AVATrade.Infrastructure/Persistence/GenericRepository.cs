using System;
using AVATrade.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AVATrade.Infrastructure.Persistence;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    internal readonly AVATradeDbContext _AVATradeDbContext;

    public GenericRepository(AVATradeDbContext AVATradeDbContext)
    {
        this._AVATradeDbContext = AVATradeDbContext;
    }

    public async Task<List<TEntity>> GetAllList()
        => await this._AVATradeDbContext.Set<TEntity>().ToListAsync();
}

