using Microsoft.EntityFrameworkCore;

namespace MyMovies
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options):base(options)
        {

        }
        
        public DbSet<Movie> Movies { get; set; } = null!;
    }
    
    public class Movie
    {
        public int? Id { get; set; }
        public string Title { get; set; } = "";
        public int Year { get; set; }
    }
}