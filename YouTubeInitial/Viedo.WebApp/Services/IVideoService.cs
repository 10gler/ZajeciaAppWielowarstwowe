using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viedo.WebApp.Models;

namespace Viedo.WebApp.Services
{
    public interface IVideoService
    {
        List<Video> GetVideos(string search);
    }
}
