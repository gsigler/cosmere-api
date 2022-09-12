using API.Cosmere.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MagicsController : ControllerBase
{
    private readonly ILogger<MagicsController> _logger;
    private IRepository<Repository.DTO.Magic> _magicRepository;

    public MagicsController(ILogger<MagicsController> logger, IRepository<Repository.DTO.Magic> magicRepository)
    {
        _logger = logger;
        _magicRepository = magicRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Repository.DTO.Magic>> Get(int id)
    {
        var magic = await _magicRepository.GetAsync(id);

        if (magic == null)
        {
            return NotFound();
        }

        return magic;
    }

    public async Task<ActionResult<List<Repository.DTO.Magic>>> List()
    {
        var people = await _magicRepository.ListAsync();

        if (people == null)
        {
            return NotFound();
        }

        return people;
    }

}
