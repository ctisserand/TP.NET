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

            Genre SF, Classic, Romance, Thriller,Autobiography;
            bookDbContext.Genre.AddRange(
                SF = new Genre() { Nom = "Science Fiction" },
                Classic = new Genre() { Nom = "Classic"},
                Romance = new Genre() { Nom = "Romance" },
                Thriller = new Genre() { Nom = "Thriller" },
                Autobiography = new Genre() { Nom = "Autobiography" }

            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book() { Auteur = "Hugo", Nom = "Epique", Prix = 12.5f, Contenu = "ccc", Genres = new() { Thriller } },
                new Book() { Auteur = "Saad", Nom = "Machin", Prix = 10.5f, Contenu = "cccCCCCCCCCCCCCCCCCC", Genres = new() { Classic, Thriller } },
                new Book() { Auteur = "Yessine", Nom = "Truc", Prix = 13.5f, Contenu = "cccCCCCCCCCCCCCCCCCCAAE", Genres = new() { Classic, Romance } },
                new Book() { Auteur = "Yessine", Nom = "Truc du truc", Prix = 15.5f, Contenu = "caeaze", Genres = new() { Classic, Thriller,Romance } }
            );
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}