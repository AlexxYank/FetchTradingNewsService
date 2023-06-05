using System;
using Application.Interfaces;
using Common.Helpers;
using Domain.Models;

namespace Application.Services;

/// <summary>
/// Fetch data from Api, Deserialize json and mapps the data to entity class, stores the data in Database
/// </summary>
public class DataService : IDataService
{
    private readonly IGenericRepository<NewsArticle> _newsArticleRepository;
    private readonly IApiService _apiService;

    public DataService(IGenericRepository<NewsArticle> newsArticleRepository, IApiService apiService)
    {
        this._newsArticleRepository = newsArticleRepository;
        this._apiService = apiService;
    }

    public async Task FetchAndStoreData()
    {
        var response = await this._apiService.FetchDataFromApi();

        var rootResponse = JsonHelper.DeserializeJson(response);

        foreach (var item in rootResponse.results)
        {
            var data = MapperHelper.MapNewsArticleResponseToEntity(item);

            await this._newsArticleRepository.Create(data);
        }

        await this._newsArticleRepository.SaveChangesAsync();
    }
}

