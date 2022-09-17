using API.Cosmere.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Cosmere.Repository;

public class BookRepository : IRepository<DTO.Book>
{
    private readonly CosmereContext _context;
    private readonly IMapper _mapper;

    public BookRepository(CosmereContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DTO.Book> UpdateAsync(DTO.Book value)
    {
        throw new NotImplementedException();
    }

    public async Task<DTO.Book?> GetAsync(int id)
    {
        var book = await _context.Books
                    .Include(book => book.Planets)
                    .Include(book => book.FollowedBy)
                    .Include(book => book.PrecededBy)
                    .Include(book => book.Authors)
                    .Include(book => book.Illustrators)
                    .SingleOrDefaultAsync(r => r.Id == id);
        return _mapper.Map<DTO.Book>(book);
    }

    public async Task<List<DTO.Book>> ListAsync()
    {
        var books = await _context.Books
                        .Include(book => book.Planets)
                        .Include(book => book.Authors)
                        .Include(book => book.Illustrators)
                        .ToListAsync();
        return _mapper.Map<List<DTO.Book>>(books);
    }
}
