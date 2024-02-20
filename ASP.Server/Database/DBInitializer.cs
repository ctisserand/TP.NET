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

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book() { },
                new Book() {Author = "xxx", Title = "yyy", Price = 12.34, Content = "ccc", Genres = new() { Romance, Thriller } },
                new Book() {Author = "Super Author", Title = "Super Title", Price = 12.34, Content = "Super Content", Genres = new() { Romance, Thriller } },
                new Book() {Author = "bad Author", Title = "bad Title", Price = 12.34, Content = "bad Content", Genres = new() { Romance, Thriller } }
            );
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}