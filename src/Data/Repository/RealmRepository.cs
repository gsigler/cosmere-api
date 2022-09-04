using API.Cosmere.Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace API.Cosmere.Data.Model;

public class RealmRepository : IRepository<Realm>
{
    private readonly CosmereContext _context;

    public RealmRepository(CosmereContext context)
    {
        _context = context;
    }
    public async Task SaveAsync(Realm value)
    {
        await _context.Realm.AddAsync(value);
        await _context.SaveChangesAsync();
    }

    public async Task<Realm?> GetAsync(int id)
    {
        return await _context.Realm.SingleOrDefaultAsync(r => r.ID == id);
    }

    public async Task<List<Realm>> ListAsync()
    {
        return await _context.Realm.ToListAsync();
    }
}
