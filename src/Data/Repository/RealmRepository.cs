using API.Cosmere.Data.DAL;

namespace API.Cosmere.Data.Model;

public class RealmRepository : IRepository<Realm>
{
    private readonly CosmereContext _context;

    public RealmRepository(CosmereContext context)
    {
        _context = context;
    }
    public void Save(Realm value)
    {
        _context.Realm.Add(value);
        _context.SaveChanges();
    }

    public List<Realm> List()
    {
        return _context.Realm.ToList();
    }
}
