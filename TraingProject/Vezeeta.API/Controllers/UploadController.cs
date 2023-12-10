using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Vezeeta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public UploadController( IWebHostEnvironment hostEnvironment) 
        {
            _hostEnvironment = hostEnvironment;
        }
        [HttpPost("UploadFile"), DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("image/jpg", "application/json")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return Content("file not selected");
                string webRootPath = _hostEnvironment.WebRootPath;
                string contentRootPath = _hostEnvironment.ContentRootPath;
                var folderName = Path.Combine(webRootPath, "Images");
                var ContentfolderName = Path.Combine(contentRootPath, "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    return Ok(new { dbPath = fileName });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
