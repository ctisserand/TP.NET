using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Server.Models;
using Microsoft.Extensions.Options;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace ASP.Server.Database
{
    public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genre { get; internal set; }
    }
}