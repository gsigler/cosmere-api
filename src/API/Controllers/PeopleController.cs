using API.Cosmere.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly ILogger<PeopleController> _logger;
    private IRepository<Repository.DTO.Person> _personRepository;

    public PeopleController(ILogger<PeopleController> logger, IRepository<Repository.DTO.Person> personRepository)
    {
        _logger = logger;
        _personRepository = personRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Repository.DTO.Person>> Get(int id)
    {
        var person = await _personRepository.GetAsync(id);

        if (person == null)
        {
            return NotFound();
        }

        return person;
    }

    public async Task<ActionResult<List<Repository.DTO.Person>>> List()
    {
        var people = await _personRepository.ListAsync();

        if (people == null)
        {
            return NotFound();
        }

        return people;
    }

}
