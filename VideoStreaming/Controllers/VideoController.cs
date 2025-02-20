using Microsoft.AspNetCore.Mvc;

namespace VideoStreaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private const string VideoFilePath = "videos/unreal.mp4";

        [HttpGet("stream")]
        public IActionResult StreamVideo()
        {
            if (!System.IO.File.Exists(VideoFilePath))
            {
                return NotFound();
            }

            var fileStream = new FileStream(VideoFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return File(fileStream, "video/mp4", enableRangeProcessing: true);
        }
    }
}