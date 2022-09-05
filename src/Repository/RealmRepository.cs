using API.Cosmere.Data.DAL;
using API.Cosmere.Data.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Cosmere.Repository;

public class RealmRepository : IRepository<Repository.DTO.Realm>
{
    private readonly CosmereContext _context;
    private readonly IMapper _mapper;

    public RealmRepository(CosmereContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task SaveAsync(Repository.DTO.Realm value)
    {
        var realm = _mapper.Map<Data.Model.Realm>(value);
        await _context.Realms.AddAsync(realm);
        await _context.SaveChangesAsync();
    }

    public async Task<Repository.DTO.Realm?> GetAsync(int id)
    {
        var realm = await _context.Realms.SingleOrDefaultAsync(r => r.ID == id);
        return _mapper.Map<DTO.Realm>(realm);
    }

    public async Task<List<Repository.DTO.Realm>> ListAsync()
    {
        var realms = await _context.Realms.ToListAsync();
        return _mapper.Map<List<DTO.Realm>>(realms);
    }
}
