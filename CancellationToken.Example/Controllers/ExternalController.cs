using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CancellationToken.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Thread.Sleep(new TimeSpan(0, 0, 5));

            return Ok("Hello World");
        }
    }
}
