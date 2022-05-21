using Microsoft.EntityFrameworkCore;
using MyMovies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MovieContext>(o => o.UseSqlite(builder.Configuration.GetConnectionString("MovieDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("movies", async (MovieContext db) =>
    await db.Movies.ToListAsync()
);

app.MapGet("movies/{id}", async (MovieContext db, int id) =>
    await db.Movies.FindAsync(id)
);

app.MapPost("movies", async (MovieContext db, Movie movie) => {
    await db.Movies.AddAsync(movie);
    await db.SaveChangesAsync();
    return Results.Accepted();
});

app.MapPut("movies/{id}", async (MovieContext db, int id, Movie movie) => 
{
    if (movie.Id == null) movie.Id = id;
    if (id != movie.Id) return Results.BadRequest();

    db.Update(movie);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("movies/{id}", async (MovieContext db, int id) => 
{
    var movie = await db.Movies.FindAsync(id);
    if (movie == null) return Results.NotFound();

    db.Movies.Remove(movie);
    await db.SaveChangesAsync();

    return Results.NoContent();
});





app.MapControllers();

app.Run();
