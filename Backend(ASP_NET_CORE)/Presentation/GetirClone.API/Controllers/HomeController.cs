using Microsoft.AspNetCore.Mvc;

namespace GetirClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [Route("Get")]
        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, "success");
        }
    }
}
