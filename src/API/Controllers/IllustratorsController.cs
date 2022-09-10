using API.Cosmere.Data.Model;
using API.Cosmere.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IllustratorsController : ControllerBase
{
    private readonly ILogger<IllustratorsController> _logger;
    private IRepository<Repository.DTO.Illustrator> _illustratorRepository;

    public IllustratorsController(ILogger<IllustratorsController> logger, IRepository<Repository.DTO.Illustrator> illustratorRepository)
    {
        _logger = logger;
        _illustratorRepository = illustratorRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Repository.DTO.Illustrator>> Get(int id)
    {
        var illustrator = await _illustratorRepository.GetAsync(id);

        if (illustrator == null)
        {
            return NotFound();
        }

        return illustrator;
    }

    public async Task<ActionResult<List<Repository.DTO.Illustrator>>> List()
    {
        var illustrators = await _illustratorRepository.ListAsync();

        if (illustrators == null)
        {
            return NotFound();
        }

        return illustrators;
    }

}
