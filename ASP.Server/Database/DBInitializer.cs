using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ASP.Server.Models;

namespace ASP.Server.Database
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext bookDbContext)
        {
            bookDbContext.Database.EnsureCreated();

            if (!bookDbContext.Genres.Any())
            {
                var genres = new List<Genre>
                {
                    new Genre { Nom = "Science-Fiction"},
                    new Genre { Nom = "Classique" },
                    new Genre { Nom = "Romance" },
                    new Genre { Nom = "Thriller" }
                };

                bookDbContext.Genres.AddRange(genres);
                bookDbContext.SaveChanges();
            }

            if (!bookDbContext.Livres.Any())
            {
                var SF = bookDbContext.Genres.FirstOrDefault(g => g.Nom == "Science-Fiction");
                var Classic = bookDbContext.Genres.FirstOrDefault(g => g.Nom == "Classique");
                var Romance = bookDbContext.Genres.FirstOrDefault(g => g.Nom == "Romance");
                var Thriller = bookDbContext.Genres.FirstOrDefault(g => g.Nom == "Thriller");

                var books = new List<Book>
                {
                    new Book { Auteur = "Isaac Asimov", Nom = "Foundation", Prix = 15.99, Contenu = "Premier livre de la série Foundation.", Genres = new List<Genre> { SF } },
                    new Book { Auteur = "Isaac Asimov2", Nom = "Foundation and Empire", Prix = 15.99, Contenu = "Deuxième livre de la série Foundation.", Genres = new List<Genre> { Classic } },
                    new Book { Auteur = "Isaac Asimov3", Nom = "Second Foundation", Prix = 15.99, Contenu = "Troisième livre de la série Foundation.", Genres = new List<Genre> { Romance } },
                    new Book { Auteur = "Isaac Asimov4", Nom = "Foundation's Edge", Prix = 15.99, Contenu = "Quatrième livre de la série Foundation.", Genres = new List<Genre> { Thriller } },
                    new Book { Auteur = "Isaac Asimov5", Nom = "Foundation and Earth", Prix = 15.99, Contenu = "Cinquième livre de la série Foundation.", Genres = new List<Genre> { SF } },
                };

                bookDbContext.Livres.AddRange(books);
                bookDbContext.SaveChanges();
            }
        }
    }
}
