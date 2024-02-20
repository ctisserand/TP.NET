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
            bookDbContext.Genres.AddRange(
                SF = new Genre() { Name = "SF" },
                Classic = new Genre() { Name = "Classic" },
                Romance = new Genre() { Name = "Romance" },
                Thriller = new Genre() { Name = "Thriller" }
            );
            bookDbContext.SaveChanges();
            
            Author JJ, JKR, JRR , JP;
            bookDbContext.Authors.AddRange(
                JJ = new Author(){Name = "James Joyce" },
                JKR = new Author(){Name = "J.K. Rowling" },
                JRR = new Author(){Name = "J.R.R. Tolkien" },
                JP = new Author(){Name = "Jean-Pierre" }
            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book() { Authors = new () {JJ}, Title = "Ulysse", Price = 10.99,
                    Content = "Le contenu de Ulysse", Genres = new() { Thriller } },
                new Book() { Authors = new () {JKR} , Title = "MOMO", Price = 10.99,
                    Content = "Le contenu de MOMO", Genres = new() { Classic } },
                new Book() { Authors = new () {JRR}, Title = "ToTo", Price = 10.99,
                    Content = "Le contenu de ToTo", Genres = new() { SF } },
                new Book() { Authors = new () {JP}, Title = "TiTi", Price = 10.99,
                    Content = "Le contenu de TiTi", Genres = new() { Romance } }
            );
            // Vous pouvez initialiser la BDD ici
            bookDbContext.SaveChanges();
        }
    }
}