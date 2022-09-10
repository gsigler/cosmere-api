using API.Cosmere.Data.Model;
using API.Cosmere.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly ILogger<AuthorsController> _logger;
    private IRepository<Repository.DTO.Author> _authorRepository;

    public AuthorsController(ILogger<AuthorsController> logger, IRepository<Repository.DTO.Author> authorRepository)
    {
        _logger = logger;
        _authorRepository = authorRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Repository.DTO.Author>> Get(int id)
    {
        var author = await _authorRepository.GetAsync(id);

        if (author == null)
        {
            return NotFound();
        }

        return author;
    }

    public async Task<ActionResult<List<Repository.DTO.Author>>> List()
    {
        var authors = await _authorRepository.ListAsync();

        if (authors == null)
        {
            return NotFound();
        }

        return authors;
    }

}
