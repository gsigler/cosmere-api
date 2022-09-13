using API.Cosmere.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Cosmere.Repository;

public class ShardRepository : IRepository<Repository.DTO.Shard>
{
    private readonly CosmereContext _context;
    private readonly IMapper _mapper;

    public ShardRepository(CosmereContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task SaveAsync(Repository.DTO.Shard value)
    {
        var shard = _mapper.Map<Data.Model.Shard>(value);
        await _context.Shards.AddAsync(shard);
        await _context.SaveChangesAsync();
    }

    public async Task<Repository.DTO.Shard?> GetAsync(int id)
    {
        var shard = await _context.Shards
                                  .Include(shard => shard.Vessel)
                                  .Include(shard => shard.Slivers)
                                  .Include(shard => shard.Magics)
                                  .Include(shard => shard.Books)
                                  .Include(shard => shard.Planets)
                                  .SingleOrDefaultAsync(r => r.Id == id);
        return _mapper.Map<DTO.Shard>(shard);
    }

    public async Task<List<Repository.DTO.Shard>> ListAsync()
    {
        var shards = await _context.Shards
                                   .Include(shard => shard.Vessel)
                                   .Include(shard => shard.Slivers)
                                   .Include(shard => shard.Magics)
                                   .Include(shard => shard.Books)
                                   .Include(shard => shard.Planets)
                                   .ToListAsync();
        return _mapper.Map<List<DTO.Shard>>(shards);
    }
}
