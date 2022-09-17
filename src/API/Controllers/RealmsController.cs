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

    [HttpPut("{id}")]
    public async Task<ActionResult<Repository.DTO.Realm>> Put(int id, Repository.DTO.Realm realm)
    {
        if (id != realm.Id)
        {
            return BadRequest("Id's do not match");
        }

        var realmToUpdate = await _realmRepository.GetAsync(id);

        if (realmToUpdate == null)
        {
            return NotFound($"Realm with Id = {id} not found");
        }

        return await _realmRepository.UpdateAsync(realm);
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
