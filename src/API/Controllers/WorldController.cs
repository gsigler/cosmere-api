using API.Cosmere.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("[controller]")]
public class WorldController : ControllerBase
{
    private readonly ILogger<WorldController> _logger;
    private IRepository<Realm> _realmRepository;

    public WorldController(ILogger<WorldController> logger, IRepository<Realm> realmRepository)
    {
        _logger = logger;
        _realmRepository = realmRepository;
    }

    public IActionResult Get()
    {
        // var realm = new Realm { Name = "Spiritual" };
        // _realmRepository.Save(realm);

        return Ok(_realmRepository.List());
    }

}
