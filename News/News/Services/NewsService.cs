using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Collections.Concurrent;
using System.Threading.Tasks;

using News.Models;
using News.ModelsSampleData;

namespace News.Services
{
    public class NewsService
    {

        ConcurrentDictionary<string, NewsGroup> keyValues = new ConcurrentDictionary<string, NewsGroup>();
        private static readonly string apiKey = "11b22480c851414b99c85de1b9afc64a";

        public async Task<NewsGroup> GetNewsAsync(NewsCategory category)
        {


            NewsCacheKey newsCacheKey = new NewsCacheKey(category, DateTime.Now);

            //https://newsapi.org/docs/endpoints/top-headlines
            var uri = $"https://newsapi.org/v2/top-headlines?country=se&category={category}&apiKey={apiKey}";


            var webclient = new WebClient();
            var json = await webclient.DownloadStringTaskAsync(uri);
            NewsApiData nd = Newtonsoft.Json.JsonConvert.DeserializeObject<NewsApiData>(json);

            var newNewsGroup = new NewsGroup
            {
                Category = category,
                Articles = nd.Articles.Select(x => new NewsItem
                {
                    DateTime = x.PublishedAt,
                    Title = x.Title,
                    Description = x.Description,
                    Url = x.Url,
                    UrlToImage = x.UrlToImage
                }).ToList()
            };

            if (newsCacheKey.CacheExist)
            {
                newNewsGroup = NewsGroup.Deserialize(newsCacheKey.FileName);
            }
            else if (!newsCacheKey.CacheExist)
            {
                NewsGroup.Serialize(newNewsGroup, newsCacheKey.FileName);
                keyValues.TryAdd(newsCacheKey.Key, newNewsGroup);
            }

            return newNewsGroup;
        }

    }
}
