using API.Cosmere.Data;
using API.Cosmere.Data.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Cosmere.Repository;

public class PersonRepository : IRepository<Repository.DTO.Person>
{
    private readonly CosmereContext _context;
    private readonly IMapper _mapper;

    public PersonRepository(CosmereContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<DTO.Person> UpdateAsync(DTO.Person value)
    {
        throw new NotImplementedException();
    }

    public async Task<Repository.DTO.Person?> GetAsync(int id)
    {
        var person = await _context.People.SingleOrDefaultAsync(r => r.Id == id);
        return _mapper.Map<DTO.Person>(person);
    }

    public async Task<List<Repository.DTO.Person>> ListAsync()
    {
        var persons = await _context.People.ToListAsync();
        return _mapper.Map<List<DTO.Person>>(persons);
    }
}
