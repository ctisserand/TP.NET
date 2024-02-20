using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ASP.Server.Models;

namespace ASP.Server.Database
{

    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext bookDbContext)
        {

            if (bookDbContext.Books.Any())
                return;

            Genre SF, Classic, Romance, Thriller;
            bookDbContext.Genre.AddRange(
                SF = new Genre(),
                Classic = new Genre(),
                Romance = new Genre(),
                Thriller = new Genre()
            );
            bookDbContext.SaveChanges();

            // Une fois les modèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book() { },
                new Book() { },
                new Book() { },
                new Book() { }
            );
            new Book() { Author = "J.K. Rowling", Name = "Harry Potter à l'école des sorciers", Price = 10.99f, Content = "Harry Potter est un jeune orphelin qui découvre qu'il est un sorcier.", Genres = new() { Classic, SF } },
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}