using API.Cosmere.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    private const string baseUrl = "https://localhost:7071";
    private readonly ILogger<PlanetsController> _logger;

    public HomeController(ILogger<PlanetsController> logger)
    {
        _logger = logger;
    }

    public Dictionary<string, string> Home()
    {
        return new Dictionary<string, string>(){
            {"realms", $"{baseUrl}/realms"},
            {"systems",  $"{baseUrl}/systems"},
            {"planets", $"{baseUrl}/planets"}
        };
    }

}