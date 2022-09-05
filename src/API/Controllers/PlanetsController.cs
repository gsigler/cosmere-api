using API.Cosmere.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlanetsController : ControllerBase
{
    private readonly ILogger<PlanetsController> _logger;
    private IRepository<Repository.DTO.Planet> _planetRepository;

    public PlanetsController(ILogger<PlanetsController> logger, IRepository<Repository.DTO.Planet> planetRepository)
    {
        _logger = logger;
        _planetRepository = planetRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Repository.DTO.Planet>> Get(int id)
    {
        var planet = await _planetRepository.GetAsync(id);

        if (planet == null)
        {
            return NotFound();
        }

        return planet;
    }

    public async Task<ActionResult<List<Repository.DTO.Planet>>> List()
    {
        var planets = await _planetRepository.ListAsync();

        if (planets == null)
        {
            return NotFound();
        }

        return planets;
    }

}
