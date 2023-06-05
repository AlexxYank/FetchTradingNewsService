using System;

namespace Application.Interfaces;

public interface IApiService
{
    Task<string> FetchDataFromApi();
}

