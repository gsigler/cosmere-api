using API.Cosmere.Data.Model;
using API.Cosmere.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Cosmere.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShardsController : ControllerBase
{
    private readonly ILogger<ShardsController> _logger;
    private IRepository<Repository.DTO.Shard> _shardRepository;

    public ShardsController(ILogger<ShardsController> logger, IRepository<Repository.DTO.Shard> shardRepository)
    {
        _logger = logger;
        _shardRepository = shardRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Repository.DTO.Shard>> Get(int id)
    {
        var shard = await _shardRepository.GetAsync(id);

        if (shard == null)
        {
            return NotFound();
        }

        return shard;
    }

    public async Task<ActionResult<List<Repository.DTO.Shard>>> List()
    {
        var shards = await _shardRepository.ListAsync();

        if (shards == null)
        {
            return NotFound();
        }

        return shards;
    }

}
