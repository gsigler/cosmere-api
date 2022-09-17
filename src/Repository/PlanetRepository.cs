using API.Cosmere.Data;
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
    public async Task<DTO.Planet> UpdateAsync(DTO.Planet value)
    {
        throw new NotImplementedException();
    }

    public async Task<DTO.Planet?> GetAsync(int id)
    {
        var planet = await _context.Planets.Include(planet => planet.Books).SingleOrDefaultAsync(r => r.Id == id);
        var planetDto = _mapper.Map<DTO.Planet>(planet);
        return planetDto;
    }

    public async Task<List<DTO.Planet>> ListAsync()
    {
        var planets = await _context.Planets.Include(planet => planet.Books).ToListAsync();
        return _mapper.Map<List<DTO.Planet>>(planets);
    }
}
