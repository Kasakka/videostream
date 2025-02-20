using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using VideoStreaming.Models;

namespace VideoStreaming.Controllers
{
    public class VideoController : Controller
    {
        // TODO: Get videos from a database?
        private static readonly List<Video> Videos = new List<Video>
        {
            new Video { Id = 1, Title = "Sample Video", FilePath = "videos/unreal.mp4" }
        };

        // GET: /Video/Index
        public IActionResult Index()
        {
            return View(Videos);
        }

        // GET: /Video/Details/1
        public IActionResult Details(int id)
        {
            var video = Videos.FirstOrDefault(v => v.Id == id);
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }

        // GET: /Video/Stream/1
        [HttpGet]
        public IActionResult Stream(int id)
        {
            var video = Videos.FirstOrDefault(v => v.Id == id);
            if (video == null)
            {
                return NotFound();
            }
            if (!System.IO.File.Exists(video.FilePath))
            {
                return NotFound();
            }
            var fileStream = new FileStream(video.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return File(fileStream, "video/mp4", enableRangeProcessing: true);
        }
    }
}
