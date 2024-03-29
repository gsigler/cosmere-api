using API.Cosmere.Data;
using API.Cosmere.Repository;
using API.Data.Cosmere.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<DatabaseConfig>(
    builder.Configuration.GetRequiredSection("DB"));
builder.Services.Configure<AppConfig>(
    builder.Configuration.GetRequiredSection("APP"));
var dbConfig = builder.Configuration.GetRequiredSection("DB").Get<DatabaseConfig>();
var cs = $"Host={dbConfig.Host};Username={dbConfig.User};Password={dbConfig.Password};Database={dbConfig.Name}";
builder.Services.AddDbContext<CosmereContext>(options =>
            options.UseNpgsql(cs));


builder.Services.AddScoped<IRepository<API.Cosmere.Repository.DTO.Realm>, RealmRepository>();
builder.Services.AddScoped<IRepository<API.Cosmere.Repository.DTO.Planet>, PlanetRepository>();
builder.Services.AddScoped<IRepository<API.Cosmere.Repository.DTO.System>, SystemRepository>();
builder.Services.AddScoped<IRepository<API.Cosmere.Repository.DTO.Book>, BookRepository>();
builder.Services.AddScoped<IRepository<API.Cosmere.Repository.DTO.Author>, AuthorRepository>();
builder.Services.AddScoped<IRepository<API.Cosmere.Repository.DTO.Illustrator>, IllustratorRepository>();
builder.Services.AddScoped<IRepository<API.Cosmere.Repository.DTO.Person>, PersonRepository>();
builder.Services.AddScoped<IRepository<API.Cosmere.Repository.DTO.Magic>, MagicRepository>();
builder.Services.AddScoped<IRepository<API.Cosmere.Repository.DTO.Shard>, ShardRepository>();

builder.Services.AddTransient<DbInitializer>();


var app = builder.Build();


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var initializer = services.GetRequiredService<DbInitializer>();
initializer.Run();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }