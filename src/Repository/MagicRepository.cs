using API.Cosmere.Data;
using API.Cosmere.Data.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Cosmere.Repository;

public class MagicRepository : IRepository<Repository.DTO.Magic>
{
    private readonly CosmereContext _context;
    private readonly IMapper _mapper;

    public MagicRepository(CosmereContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<DTO.Magic> UpdateAsync(DTO.Magic value)
    {
        throw new NotImplementedException();
    }

    public async Task<Repository.DTO.Magic?> GetAsync(int id)
    {
        var magic = await _context.Magics.SingleOrDefaultAsync(r => r.Id == id);
        return _mapper.Map<DTO.Magic>(magic);
    }

    public async Task<List<Repository.DTO.Magic>> ListAsync()
    {
        var magics = await _context.Magics.ToListAsync();
        return _mapper.Map<List<DTO.Magic>>(magics);
    }
}
