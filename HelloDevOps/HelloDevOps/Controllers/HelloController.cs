using Microsoft.AspNetCore.Mvc;

namespace HelloDevOps.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {     
        private readonly ILogger<HelloController> _logger;

        public HelloController(ILogger<HelloController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                message = "Hello DevOps World!",
                timestamp = DateTime.UtcNow,
                version = "1.0.0"
            });
        }
    }
}
