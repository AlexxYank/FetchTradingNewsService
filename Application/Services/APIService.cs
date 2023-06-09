﻿using System;
using System.Net.Http;
using Application.Interfaces;
using Common.Constants;
using Common.Helpers;
using Domain.Models;

namespace Application.Services;

/// <summary>
/// Requests data from Api
/// </summary>
public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        
        _httpClient = new HttpClient();
    }

    public async Task<string> FetchDataFromApi()
    {
        try
        {
            string apiUrl = AppConstants.EnvironmentVariables.PolygonApi.Url
                + AppConstants.EnvironmentVariables.PolygonApi.Key;

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return data;
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
            return null;
        }
    }
}

