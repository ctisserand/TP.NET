using Microsoft.EntityFrameworkCore;
using ASP.Server.Models;


namespace ASP.Server.Database
{
    public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; internal set; }
        public DbSet<Author> Authors { get; internal set; }
    }
}