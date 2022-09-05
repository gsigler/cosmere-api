using API.Cosmere.Data.DAL;
using API.Cosmere.Data.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Cosmere.Repository;

public class SystemRepository : IRepository<Repository.DTO.System>
{
    private readonly CosmereContext _context;
    private readonly IMapper _mapper;

    public SystemRepository(CosmereContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task SaveAsync(Repository.DTO.System value)
    {
        var system = _mapper.Map<Data.Model.System>(value);
        await _context.Systems.AddAsync(system);
        await _context.SaveChangesAsync();
    }

    public async Task<Repository.DTO.System?> GetAsync(int id)
    {
        var system = await _context.Systems.Include(s => s.Planets).SingleOrDefaultAsync(r => r.ID == id);
        return _mapper.Map<DTO.System>(system);
    }

    public async Task<List<Repository.DTO.System>> ListAsync()
    {
        var systems = await _context.Systems.Include(system => system.Planets).ToListAsync();
        return _mapper.Map<List<DTO.System>>(systems);
    }
}
