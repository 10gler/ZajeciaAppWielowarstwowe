using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Viedo.WebApp.Models;

namespace Viedo.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult SearchYoutubeVideos(string search)
        {
            /*
             * https://developers.google.com/youtube/v3/getting-started -> Google Developers Console (tu tworzymy klucz, tworząc projekt) 
             * https://developers.google.com/youtube/v3/docs/ -> Dokumentacja -> Źródła wiedzy, Search -> List -> Curl, czyli to:
             * https://developers.google.com/youtube/v3/docs/search/list  
            */

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
            return View(ytVideos);
        }
    }
}