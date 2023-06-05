using System;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces
{
	public interface IFetchTradingNewsDbContext : IDisposable
    {
        void OnModelCreating(ModelBuilder builder);

        void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
    }
}

