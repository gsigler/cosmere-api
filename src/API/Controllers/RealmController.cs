using API.Cosmere.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("[controller]")]
public class RealmsController : ControllerBase
{
    private readonly ILogger<RealmsController> _logger;
    private IRepository<Realm> _realmRepository;

    public RealmsController(ILogger<RealmsController> logger, IRepository<Realm> realmRepository)
    {
        _logger = logger;
        _realmRepository = realmRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Realm>> Get(int id)
    {
        var realm = await _realmRepository.GetAsync(id);

        if (realm == null)
        {
            return NotFound();
        }

        return realm;
    }

    public async Task<ActionResult<List<Realm>>> List()
    {
        var realms = await _realmRepository.ListAsync();

        if (realms == null)
        {
            return NotFound();
        }

        return realms;
    }

}
