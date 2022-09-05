using API.Cosmere.Data.Model;
using API.Cosmere.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("[controller]")]
public class SystemsController : ControllerBase
{
    private readonly ILogger<SystemsController> _logger;
    private IRepository<Repository.DTO.System> _systemRepository;

    public SystemsController(ILogger<SystemsController> logger, IRepository<Repository.DTO.System> systemRepository)
    {
        _logger = logger;
        _systemRepository = systemRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Repository.DTO.System>> Get(int id)
    {
        var system = await _systemRepository.GetAsync(id);

        if (system == null)
        {
            return NotFound();
        }

        return system;
    }

    public async Task<ActionResult<List<Repository.DTO.System>>> List()
    {
        var systems = await _systemRepository.ListAsync();

        if (systems == null)
        {
            return NotFound();
        }

        return systems;
    }

}
