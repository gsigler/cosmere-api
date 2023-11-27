using API.Data.Cosmere.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("/")]
[Route("api/")]
public class HomeController : ControllerBase
{
    // private const string baseUrl = "https://localhost:7071/api";
    private readonly ILogger<PlanetsController> _logger;
    private readonly AppConfig _config;

    public HomeController(ILogger<PlanetsController> logger, IOptions<AppConfig> config)
    {
        _logger = logger;
        _config = config.Value;
    }

    public SortedDictionary<string, string> Home()
    {
        return new SortedDictionary<string, string>(){
            {"realms", $"{_config.BaseUrl}/realms"},
            {"systems",  $"{_config.BaseUrl}/systems"},
            {"planets", $"{_config.BaseUrl}/planets"},
            {"books", $"{_config.BaseUrl}/books"},
            {"people", $"{_config.BaseUrl}/people"},
            {"magic", $"{_config.BaseUrl}/magics"},
            {"shards",  $"{_config.BaseUrl}/shards"},
        };
    }

}
