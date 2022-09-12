#nullable disable
using API.Cosmere.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Cosmere.Data;

public class CosmereContext : DbContext
{
    public DbSet<Realm> Realms { get; set; }
    public DbSet<Planet> Planets { get; set; }
    public DbSet<Data.Model.System> Systems { get; set; }
    public DbSet<Data.Model.Book> Books { get; set; }
    public DbSet<Data.Model.Shard> Shards { get; set; }
    public DbSet<Data.Model.Magic> Magics { get; set; }
    public DbSet<Data.Model.Person> People { get; set; }
    public DbSet<Data.Model.Author> Authors { get; set; }
    public DbSet<Data.Model.Illustrator> Illustrators { get; set; }

    public CosmereContext(DbContextOptions<CosmereContext> options) : base(options)
    {

    }
}
