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
                    new Genre { Nom = "Thriller" },
                    new Genre { Nom = "Fantasy" },
                    new Genre { Nom = "Horror" },
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
                var Fantasy = bookDbContext.Genres.FirstOrDefault(g => g.Nom == "Fantasy");
                var Horror = bookDbContext.Genres.FirstOrDefault(g => g.Nom == "Horror");

                var books = new List<Book>
                {
                    new Book { Auteur = "Lionel Vincent", Nom = "Foundation", Prix = 15.99, Contenu = "Premier livre de la série Foundation.", Genres = new List<Genre> { SF } },
                    new Book { Auteur = "Mon Ex copine", Nom = "Foundation and Empire", Prix = 15.99, Contenu = "Deuxième livre de la série Foundation.", Genres = new List<Genre> { Classic } },
                    new Book { Auteur = "Elodie Bantos", Nom = "Second Foundation", Prix = 15.99, Contenu = "Troisième livre de la série Foundation.", Genres = new List<Genre> { Romance } },
                    new Book { Auteur = "Dounia Zoubid", Nom = "Foundation's Edge", Prix = 15.99, Contenu = "Quatrième livre de la série Foundation.", Genres = new List<Genre> { Thriller } },
                    new Book { Auteur = "Yehoudi Vincent", Nom = "Foundation and Earth", Prix = 15.99, Contenu = "Cinquième livre de la série Foundation.", Genres = new List<Genre> { SF } },
                    new Book { Auteur = "Paul Mirabel", Nom = "Get Out", Prix = 25.99, Contenu = "Ceci est le contenu du film", Genres = new List<Genre> { Fantasy } },
                };

                bookDbContext.Livres.AddRange(books);
                bookDbContext.SaveChanges();
            }
        }
    }
}
