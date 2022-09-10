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
        var rosharPlanet = new Planet() { Name = "Roshar" };
        // var rosharPlanet2 = rosharPlanet

        var rosharanPlanets = new List<Planet>(){
            new Planet() {Name = "Ashyn"},
            new Planet() {Name = "Braize"},
            rosharPlanet
        };

        _context.Planets.AddRange(nalthianPlanets);
        _context.Planets.AddRange(rosharanPlanets);

        var systems = new List<Data.Model.System>(){
            new Data.Model.System() {Name = "Nalthian", Planets = nalthianPlanets},
            new Data.Model.System() {Name = "Rosharan", Planets = rosharanPlanets}
        };

        _context.Systems.AddRange(systems);

        var authors = new List<Data.Model.Author>()
        {
           new Author() { Name = "Brandon Sanderson" }
        };

        var illustrators = new List<Data.Model.Illustrator>() {
            new Illustrator() { Name = "Isaac Stewart" }
        };

        _context.Authors.AddRange(authors);
        _context.Illustrators.AddRange(illustrators);

        var wayOfKings = new Data.Model.Book()
        {
            Title = "The Way of Kings",
            Authors = authors,
            Illustrators = illustrators,
            PublicationDate = DateTime.Parse("August 31, 2010").ToUniversalTime(),
            Pages = 1007,
            WordCount = 384265,
            Planets = new List<Data.Model.Planet>() { rosharPlanet }
        };



        var wordsOfRadiance = new Data.Model.Book()
        {
            Title = "Words of Radiance",
            Authors = authors,
            Illustrators = illustrators,
            PublicationDate = DateTime.Parse("March 4, 2014").ToUniversalTime(),
            Pages = 1087,
            WordCount = 398238,
            Planets = new List<Data.Model.Planet>() { rosharPlanet }
        };


        var books = new List<Data.Model.Book>()
        {
            wayOfKings,
            wordsOfRadiance
        };

        _context.Books.AddRange(books);

        _context.SaveChanges();

        wayOfKings.FollowedBy = wordsOfRadiance;
        wordsOfRadiance.PrecededBy = wayOfKings;

        _context.SaveChanges();



    }

}
