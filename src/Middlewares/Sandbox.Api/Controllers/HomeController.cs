using Microsoft.AspNetCore.Mvc;

namespace Sandbox.Api.Controllers;

[ApiController]
[Route("home")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("throw")]
    public IActionResult Throw()
    {
        throw new Exception("Exception in HomeController.");
    }
}
