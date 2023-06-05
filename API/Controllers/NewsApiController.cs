using System;
using Application.Interfaces;
using Application.Services;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

[ApiController]
public class NewsApiController : ControllerBase
{
    private Timer _timer;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<NewsApiController> _logger;

    private readonly IDataService _dataService;

    public NewsApiController(IDataService dataService, IServiceScopeFactory serviceScopeFactory, ILogger<NewsApiController> logger)
    {
        this._dataService = dataService;
        this._serviceScopeFactory = serviceScopeFactory;
        this._logger = logger;
    }


    [HttpGet]
    [Route("/api/fetchnews")]
    public async Task<IActionResult> FetchNews()
    {
        await this._dataService.FetchAndStoreData();

        return Ok();
    }
}

