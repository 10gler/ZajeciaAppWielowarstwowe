using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Viedo.WebApp.Models;

namespace Viedo.WebApp.Services
{
    public class YoutubeService : IVideoService
    {
        public List<Video> GetVideos(string search)
        {
            var client = new HttpClient();
            YtResponse ytResponse = null;
            var uri = $"https://www.googleapis.com/youtube/v3/search?q={search}&maxResults=5&part=snippet&key=AIzaSyD4Gd3KD8defn2gYQJuKmMnR6TrAVJFJKM";
            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                ytResponse = JsonConvert.DeserializeObject<YtResponse>(response.Content.ReadAsStringAsync().Result);
            }
            var ytVideos = ytResponse.items.Select(i => new Video
            {
                Title = i.snippet.title,
                Description = i.snippet.description,
                VideoId = i.id.videoId,
            }).ToList();

            return ytVideos;
        }
    }
}