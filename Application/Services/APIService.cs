using System;
using System.Net.Http;
using Application.Interfaces;
using Common.Helpers;
using Domain.Models;

namespace Application.Services;

public class ApiService : IApiService
{
    
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        
        _httpClient = new HttpClient();
    }

    public async Task<string> GetDataFromApi()
    {
        try
        {
            string apiUrl = "https://api.polygon.io/v2/reference/news";
            string apiKey = "?apiKey=oLwXbx8i6SDnIEJf_KpWpCxFc5Zvwq5Z";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl + apiKey);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return data;
            }
            else
            {
                // Handle error response
                Console.WriteLine("Error: " + response.StatusCode);
                return null;
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            Console.WriteLine("Exception: " + ex.Message);
            return null;
        }
    }
}

