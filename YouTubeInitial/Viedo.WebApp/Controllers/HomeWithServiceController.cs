using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viedo.WebApp.Services;

namespace Viedo.WebApp.Controllers
{
    public class HomeWithServiceController : Controller
    {
        private IVideoService _vdieoService;

        public HomeWithServiceController(IVideoService vdieoService)
        {
            _vdieoService = vdieoService;
        }

        public ActionResult SearchYoutubeVideos(string search)
        {
            return View(_vdieoService.GetVideos(search));
        }
    }
}