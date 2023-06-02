using System;
using AVATrade.Domain.Models;
using Newtonsoft.Json;

namespace AVATrade.Common.DTOs.Responses;

public class APINewsResponse
{
    [JsonProperty("results")]
    public NewsArticle[] Results { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("request_id")]
    public string RequestId { get; set; }

    [JsonProperty("count")]
    public long Count { get; set; }

    [JsonProperty("next_url")]
    public Uri NextUrl { get; set; }
}

