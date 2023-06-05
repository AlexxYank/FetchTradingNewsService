using System;
using AutoMapper;
using Common.DTOs.Responses;
using Domain.Models;

namespace Common.Helpers
{
	public static class MapperHelper
	{
        public static NewsArticle MapNewsArticleResponseToEntity(NewsArticleResponse response)
        {
            var newsArticle = new NewsArticle
            {
                ResultId = response.id,
                Publisher = MapPublisherResponseToEntity(response.publisher),
                Title = response.title,
                Author = response.author,
                PublishedUtc = response.published_utc,
                ArticleUrl = new Uri(response.article_url),
                ImageUrl = new Uri(response.image_url),
                Description = response.description,
                AmpUrl = string.IsNullOrEmpty(response.amp_url) ? null :  new Uri(response.amp_url)
            };

            if (response.tickers is not null)
            {
                foreach (var tickerValue in response.tickers)
                {
                    newsArticle.Tickers.Add(new Ticker { Name = tickerValue, NewsArticle = newsArticle });
                }
            }

            if (response.keywords is not null)
            {
                foreach (var keywordValue in response.keywords)
                {
                    newsArticle.Keywords.Add(new Keyword { Name = keywordValue, NewsArticle = newsArticle });
                }
            }

            return newsArticle;
        }

        private static Publisher MapPublisherResponseToEntity(PublisherResponse response)
        {
            return new Publisher
            {
                Name = response.name,
                HomepageUrl = new Uri(response.homepage_url),
                LogoUrl = new Uri(response.logo_url),
                FaviconUrl = new Uri(response.favicon_url)
            };
        }
    }
}

