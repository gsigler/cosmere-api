using API.Cosmere.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Cosmere.Repository;

public class IllustratorRepository : IRepository<Repository.DTO.Illustrator>
{
    private readonly CosmereContext _context;
    private readonly IMapper _mapper;

    public IllustratorRepository(CosmereContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<DTO.Illustrator> UpdateAsync(DTO.Illustrator value)
    {
        throw new NotImplementedException();
    }

    public async Task<Repository.DTO.Illustrator?> GetAsync(int id)
    {
        var illustrator = await _context.Illustrators.Include(s => s.Books).SingleOrDefaultAsync(r => r.Id == id);
        return _mapper.Map<DTO.Illustrator>(illustrator);
    }

    public async Task<List<Repository.DTO.Illustrator>> ListAsync()
    {
        var illustrators = await _context.Illustrators.Include(illustrator => illustrator.Books).ToListAsync();
        return _mapper.Map<List<DTO.Illustrator>>(illustrators);
    }
}
