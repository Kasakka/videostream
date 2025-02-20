using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using VideoStreaming.Models;

namespace VideoStreaming.Controllers
{
    public class VideoController : Controller
    {
        private List<Video> GetVideos()
        {
            string videoFolder = Path.Combine(Directory.GetCurrentDirectory(), "videos");

            if (!Directory.Exists(videoFolder))
            {
                Directory.CreateDirectory(videoFolder);
            }

            var videoFiles = Directory.GetFiles(videoFolder, "*.mp4");

            var videos = videoFiles.Select((file, index) => new Video
            {
                Id = index + 1,
                Title = Path.GetFileNameWithoutExtension(file),
                FilePath = file
            }).ToList();

            return videos;
        }

        // GET: /Video/Index
        public IActionResult Index()
        {
            var videos = GetVideos();
            return View(videos);
        }

        // GET: /Video/Details/1
        public IActionResult Details(int id)
        {
            var videos = GetVideos();
            var video = videos.FirstOrDefault(v => v.Id == id);
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
            var videos = GetVideos();
            var video = videos.FirstOrDefault(v => v.Id == id);
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
