using API.Cosmere.Data;
using API.Cosmere.Data.DAL;
using API.Cosmere.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<CosmereContext>(options =>
            options.UseNpgsql("Host=localhost:5432;Database=CosmereDB;Username=postgres;Password=password"));

builder.Services.AddScoped<IRepository<API.Cosmere.Repository.DTO.Realm>, RealmRepository>();
builder.Services.AddScoped<IRepository<API.Cosmere.Repository.DTO.Planet>, PlanetRepository>();
builder.Services.AddScoped<IRepository<API.Cosmere.Repository.DTO.System>, SystemRepository>();
builder.Services.AddScoped<IRepository<API.Cosmere.Repository.DTO.Book>, BookRepository>();
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
