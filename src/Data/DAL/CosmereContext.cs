#nullable disable
using API.Cosmere.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Cosmere.Data.DAL
{
    public class CosmereContext : DbContext
    {
        public CosmereContext(DbContextOptions<CosmereContext> options) : base(options)
        {

        }
        public DbSet<Realm> Realms { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Data.Model.System> Systems { get; set; }

    }
}