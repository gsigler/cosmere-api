using API.Cosmere.Data.DAL;
using API.Cosmere.Data.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Cosmere.Repository;

public class AuthorRepository : IRepository<Repository.DTO.Author>
{
    private readonly CosmereContext _context;
    private readonly IMapper _mapper;

    public AuthorRepository(CosmereContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task SaveAsync(Repository.DTO.Author value)
    {
        var author = _mapper.Map<Data.Model.Author>(value);
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
    }

    public async Task<Repository.DTO.Author?> GetAsync(int id)
    {
        var author = await _context.Authors.Include(s => s.Books).SingleOrDefaultAsync(r => r.Id == id);
        return _mapper.Map<DTO.Author>(author);
    }

    public async Task<List<Repository.DTO.Author>> ListAsync()
    {
        var authors = await _context.Authors.Include(author => author.Books).ToListAsync();
        return _mapper.Map<List<DTO.Author>>(authors);
    }
}
