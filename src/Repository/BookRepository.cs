using API.Cosmere.Data.DAL;
using API.Cosmere.Data.Model;
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
    public async Task SaveAsync(DTO.Book value)
    {
        var book = _mapper.Map<Data.Model.Book>(value);
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async Task<DTO.Book?> GetAsync(int id)
    {
        var book = await _context.Books.SingleOrDefaultAsync(r => r.ID == id);
        return _mapper.Map<DTO.Book>(book); ;
    }

    public async Task<List<DTO.Book>> ListAsync()
    {
        var Books = await _context.Books.ToListAsync();
        return _mapper.Map<List<DTO.Book>>(Books);
    }
}
