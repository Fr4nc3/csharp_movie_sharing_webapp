using MovieSharing.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieSharing.Data
{
    /// <summary>
    /// MovieSharing context and db connection
    /// </summary>
    public class MovieSharingContext : DbContext
    {
        public MovieSharingContext(DbContextOptions<MovieSharingContext> options)
    : base(options)
        {
            // This will cause the Database and Tables to be created.
            Database.EnsureCreated();
        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Imperson> Imperson { get; set; }


    }
}
