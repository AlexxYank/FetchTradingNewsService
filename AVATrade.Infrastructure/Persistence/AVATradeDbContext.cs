using System;
using System.Reflection;
using System.Reflection.Emit;
using AVATrade.Application.Interfaces;
using AVATrade.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AVATrade.Infrastructure.Persistence
{
	public class AVATradeDbContext : DbContext, IAVATradeDbContext
    {
		public AVATradeDbContext(DbContextOptions<AVATradeDbContext> options) : base(options)
        {
		}

        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Ticker> Tickers { get; set; }
        public DbSet<Keyword> Keywords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            builder.Entity<NewsArticle>()
                .HasOne(n => n.Publisher)
                .WithOne(p => p.NewsArticle)
                .HasForeignKey<Publisher>(p => p.NewsArticleId);

            builder.Entity<NewsArticle>()
                .HasMany(n => n.Tickers)
                .WithOne(t => t.NewsArticle)
                .HasForeignKey(t => t.NewsArticleId);

            builder.Entity<NewsArticle>()
                .HasMany(n => n.Keywords)
                .WithOne(k => k.NewsArticle)
                .HasForeignKey(k => k.NewsArticleId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ConnectionString.BuildConnection();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}

