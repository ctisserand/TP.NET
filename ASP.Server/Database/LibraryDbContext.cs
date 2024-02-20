using Microsoft.EntityFrameworkCore;
using ASP.Server.Models;

namespace ASP.Server.Database
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Livres { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
