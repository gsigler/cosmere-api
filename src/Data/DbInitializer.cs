using API.Cosmere.Data.DAL;
using API.Cosmere.Data.Model;

namespace API.Cosmere.Data;

public class DbInitializer
{
    private readonly CosmereContext _context;

    public DbInitializer(CosmereContext context)
    {
        _context = context;

    }

    public void Run()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();


        var realms = new List<Realm>(){
                new Realm() {Name = "Spiritual"},
                new Realm() {Name = "Physical"},
                new Realm() {Name = "Cognitive"}
            };
        _context.Realms.AddRange(realms);

        var nalthianPlanets = new List<Planet>(){
            new Planet() {Name = "Nalthis"}
        };

        var rosharanPlanets = new List<Planet>(){
            new Planet() {Name = "Ashyn"},
            new Planet() {Name = "Braize"},
            new Planet() {Name = "Roshar"}
        };

        var systems = new List<Data.Model.System>(){
            new Data.Model.System() {Name = "Nalthian", Planets = nalthianPlanets},
            new Data.Model.System() {Name = "Rosharan", Planets = rosharanPlanets}
        };

        _context.Systems.AddRange(systems);
        _context.Planets.AddRange(nalthianPlanets);
        _context.Planets.AddRange(rosharanPlanets);

        _context.SaveChanges();
    }

}
