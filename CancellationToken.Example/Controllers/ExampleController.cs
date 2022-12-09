using Microsoft.AspNetCore.Mvc;

namespace CancellationToken.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ExampleController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet("a")]
        public async Task<IActionResult> GetA()
        {
            var result = await _httpClient.GetAsync("https://localhost:7164/api/external");

            var content = await result.Content.ReadAsStringAsync();

            return Ok(content);
        }

        [HttpGet("b")]
        public async Task<IActionResult> GetB()
        {
            System.Threading.CancellationToken token = HttpContext.RequestAborted;
            var result = await _httpClient.GetAsync("https://localhost:7164/api/external", token);

            var content = await result.Content.ReadAsStringAsync();

            return Ok(content);
        }
    }
}
