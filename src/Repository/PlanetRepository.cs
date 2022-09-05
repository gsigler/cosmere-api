using API.Cosmere.Data.DAL;
using API.Cosmere.Data.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Cosmere.Repository;

public class PlanetRepository : IRepository<DTO.Planet>
{
    private readonly CosmereContext _context;
    private readonly IMapper _mapper;

    public PlanetRepository(CosmereContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task SaveAsync(DTO.Planet value)
    {
        var planet = _mapper.Map<Data.Model.Planet>(value);
        await _context.Planets.AddAsync(planet);
        await _context.SaveChangesAsync();
    }

    public async Task<DTO.Planet?> GetAsync(int id)
    {
        var planet = await _context.Planets.SingleOrDefaultAsync(r => r.ID == id);
        var planetDto = _mapper.Map<DTO.Planet>(planet);
        return planetDto;
    }

    public async Task<List<DTO.Planet>> ListAsync()
    {
        var planets = await _context.Planets.ToListAsync();
        return _mapper.Map<List<DTO.Planet>>(planets);
    }
}