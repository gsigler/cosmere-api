using API.Cosmere.Data;
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

        // Realms
        var realms = new List<Realm>(){
                new Realm() {Name = "Spiritual"},
                new Realm() {Name = "Physical"},
                new Realm() {Name = "Cognitive"}
            };
        _context.Realms.AddRange(realms);

        // Planets
        var nalthianPlanets = new List<Planet>(){
            new Planet() {Name = "Nalthis"}
        };
        var rosharPlanet = new Planet() { Name = "Roshar" };
        var scadrialPlanet = new Planet() { Name = "Scadrial" };
        // var rosharPlanet2 = rosharPlanet

        var rosharanPlanets = new List<Planet>(){
            new Planet() {Name = "Ashyn"},
            new Planet() {Name = "Braize"},
            rosharPlanet
        };

        _context.Planets.AddRange(nalthianPlanets);
        _context.Planets.AddRange(rosharanPlanets);
        _context.Planets.AddRange(scadrialPlanet);

        // Systems
        var systems = new List<Data.Model.System>(){
            new Data.Model.System() {Name = "Nalthian", Planets = nalthianPlanets},
            new Data.Model.System() {Name = "Rosharan", Planets = rosharanPlanets}
        };

        _context.Systems.AddRange(systems);

        // Authors
        var authors = new List<Data.Model.Author>()
        {
           new Author() { Name = "Brandon Sanderson" }
        };
        // Illustrators
        var illustrators = new List<Data.Model.Illustrator>() {
            new Illustrator() { Name = "Isaac Stewart" }
        };

        _context.Authors.AddRange(authors);
        _context.Illustrators.AddRange(illustrators);

        // Books
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

        var theFinalEmpire = new Data.Model.Book()
        {
            Title = "The Final Empire",
            Authors = authors,
            PublicationDate = DateTime.Parse("July 17, 2006").ToUniversalTime(),
            Pages = 541,
            Planets = new List<Data.Model.Planet>() { scadrialPlanet }
        };


        var books = new List<Data.Model.Book>()
        {
            wayOfKings,
            wordsOfRadiance
        };

        _context.Books.AddRange(books);

        _context.SaveChanges();

        // Book Relationships
        wayOfKings.FollowedBy = wordsOfRadiance;
        wordsOfRadiance.PrecededBy = wayOfKings;


        // People
        var kelsier = new Data.Model.Person()
        {
            Name = "Kelsier"
        };

        var vin = new Data.Model.Person()
        {
            Name = "Vin"
        };
        var people = new List<Data.Model.Person>()
        {
           kelsier,
           vin

        };

        _context.People.AddRange(people);


        // Magics
        var allomancy = new Data.Model.Magic()
        {
            Name = "Allomancy"
        };
        var feruchemy = new Data.Model.Magic()
        {
            Name = "Feruchemy"
        };
        var magics = new List<Data.Model.Magic>()
        {
           allomancy,
           feruchemy
        };
        _context.Magics.AddRange(magics);

        // Shards

        var shards = new List<Data.Model.Shard>()
        {
            new Data.Model.Shard()
            {
                Name = "Ruin",
                Vessel = new Data.Model.Person(){
                    Name = "Sazed"
                },
                Slivers = new List<Data.Model.Person>(){
                    new Data.Model.Person()
                    {
                        Name = "Leras"
                    },
                    new Data.Model.Person()
                    {
                        Name = "Rashek"
                    },
                    kelsier,
                    vin
                },
                Magics = new List<Data.Model.Magic>(){
                    allomancy
                },
                Books = new List<Data.Model.Book>(){
                    theFinalEmpire
                },
                Planets = new List<Data.Model.Planet>(){
                    scadrialPlanet
                }
            }
        };

        _context.Shards.AddRange(shards);

        _context.SaveChanges();


    }

}
