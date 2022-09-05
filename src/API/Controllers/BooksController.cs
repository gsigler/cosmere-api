using API.Cosmere.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private IRepository<Repository.DTO.Book> _BookRepository;

    public BooksController(ILogger<BooksController> logger, IRepository<Repository.DTO.Book> BookRepository)
    {
        _logger = logger;
        _BookRepository = BookRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Repository.DTO.Book>> Get(int id)
    {
        var Book = await _BookRepository.GetAsync(id);

        if (Book == null)
        {
            return NotFound();
        }

        return Book;
    }

    public async Task<ActionResult<List<Repository.DTO.Book>>> List()
    {
        var Books = await _BookRepository.ListAsync();

        if (Books == null)
        {
            return NotFound();
        }

        return Books;
    }

}
