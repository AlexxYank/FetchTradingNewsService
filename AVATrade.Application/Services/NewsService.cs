using System;
using AVATrade.Application.Interfaces;
using AVATrade.Domain.Models;

namespace AVATrade.Application.Services;

public class NewsService : INewsService
{
    private readonly IGenericRepository<NewsArticle> _newsRepository;

    public NewsService(IGenericRepository<NewsArticle> newsRepository)
    {
        this._newsRepository = newsRepository;
    }

    public async Task<NewsArticle> GetNews()
    {
        //TODO
        return null;
    }
}

