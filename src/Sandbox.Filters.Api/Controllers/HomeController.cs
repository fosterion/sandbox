using Microsoft.AspNetCore.Mvc;
using Sandbox.Filters.Api.Filters;

namespace Sandbox.Filters.Api.Controllers;

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
    [ServiceFilter(typeof(ExceptionFilter))]
    public IActionResult Throw()
    {
        throw new Exception("Exception in HomeController.");
    }
}
