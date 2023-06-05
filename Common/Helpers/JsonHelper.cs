using System;
using System.Text.Json;
using AutoMapper;
using Common.DTOs.Responses;
using Domain.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Common.Helpers
{
	public static class JsonHelper
	{
		public static RootResponse DeserializeJson(string json)
		{
            RootResponse article = JsonConvert.DeserializeObject<RootResponse>(json);

            return article;
        }


    }
}

