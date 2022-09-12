using API.Cosmere.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("/")]
[Route("api/")]
public class HomeController : ControllerBase
{
    private const string baseUrl = "https://localhost:7071/api";
    private readonly ILogger<PlanetsController> _logger;

    public HomeController(ILogger<PlanetsController> logger)
    {
        _logger = logger;
    }

    public SortedDictionary<string, string> Home()
    {
        return new SortedDictionary<string, string>(){
            {"realms", $"{baseUrl}/realms"},
            {"systems",  $"{baseUrl}/systems"},
            {"planets", $"{baseUrl}/planets"},
            {"books", $"{baseUrl}/books"},
            {"people", $"{baseUrl}/people"},
            {"magic", $"{baseUrl}/magics"},
        };
    }

}
