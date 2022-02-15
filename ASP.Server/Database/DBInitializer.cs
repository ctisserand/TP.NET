using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
                SF = new Genre()
                {
                    Name = "SF",
                    Description = "Romance bla bla bla"
                },
                Classic = new Genre()
                {
                    Name="classic",
                    Description = "Romance bla bla bla"
                },
                Romance = new Genre()
                {
                    Name = "Romance",
                    Description = "Romance bla bla bla"
                },
                Thriller = new Genre()
                {
                    Name = "Thriller",
                    Description = " Thriller bla bla bla"
                }
            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book()
                {
                    Name ="kalila wa demna",
                    Author = "Antonin",
                    Price = "49",
                    Content ="livre de show ",
                    Genders = new List<Genre> {SF}
                }, 
                new Book()
                {
                    Name = "Harry Potter",
                    Author = "Khadijat",
                    Price = "49",
                    Content = "livre de show ",
                    Genders = new List<Genre> { Classic }
                },
                new Book()
                {
                    Name = "Voyage au bout de la nuit",
                    Author = "Lotfi",
                    Price = "49",
                    Content = "livre de show ",
                    Genders = new List<Genre> { Romance }
                },
                new Book()
                {
                    Name = "Le seigneur des anneaux",
                    Author = "Rachid",
                    Price = "49",
                    Content = "livre de show ",
                    Genders = new List<Genre> { Thriller }
                }
            );
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}