using API.Cosmere.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RealmsController : ControllerBase
{
    private readonly ILogger<RealmsController> _logger;
    private IRepository<Repository.DTO.Realm> _realmRepository;

    public RealmsController(ILogger<RealmsController> logger, IRepository<Repository.DTO.Realm> realmRepository)
    {
        _logger = logger;
        _realmRepository = realmRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Repository.DTO.Realm>> Get(int id)
    {
        var realm = await _realmRepository.GetAsync(id);

        if (realm == null)
        {
            return NotFound();
        }

        return realm;
    }

    public async Task<ActionResult<List<Repository.DTO.Realm>>> List()
    {
        var realms = await _realmRepository.ListAsync();

        if (realms == null)
        {
            return NotFound();
        }

        return realms;
    }

}
