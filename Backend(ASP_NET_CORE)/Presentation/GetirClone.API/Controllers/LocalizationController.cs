using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GetirClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationController : ControllerBase
    {

        [Route("GetMessages")]
        [HttpGet]
        public IActionResult GetMessages(string lang, [FromQuery] string ns = "common")
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "locales", lang.ToLower(), $"{ns.ToLower()}.json");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var content = System.IO.File.ReadAllText(filePath, Encoding.UTF8);
            return Content(content, "application/json");
        }
    }
}
