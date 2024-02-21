using System.Collections.Generic;
using System.Linq;
using ASP.Server.Database;
using ASP.Server.Models;
using ASP.Server.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.Server.Controllers
{
    public class BookController(LibraryDbContext libraryDbContext, IMapper mapper) : Controller
    {
        private readonly LibraryDbContext libraryDbContext = libraryDbContext;
        private readonly IMapper mapper = mapper;

        // A vous de faire comme BookController.List mais pour les genres !

        public ActionResult<IEnumerable<Book>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            IEnumerable<Book> ListBooks = libraryDbContext.Books.
                Include(b => b.Authors).
                Include(b => b.Genres);
            return View(ListBooks);
        }

        public ActionResult<CreateBookViewModel> Create(CreateBookViewModel book)
        {
            // Le IsValid est True uniquement si tous les champs de CreateGenreModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                // Completer la création du genre avec toute les information nécéssaire que vous aurez ajoutez, et mettez la liste des gener récupéré de la base aussi
                libraryDbContext.Add(new Book()
                {
                    Name = book.Name,
                    Authors = book.Authors.Select(id => libraryDbContext.Authors.Find(id)).ToList(),
                    Price = book.Price,
                    Content = book.Content,
                    Genres = book.Genres.Select(id => libraryDbContext.Genres.Find(id)).ToList()
                });
                libraryDbContext.SaveChanges();
            }

            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            return View(new CreateBookViewModel()
            {
                AllAuthors = libraryDbContext.Authors, 
                AllGenres = libraryDbContext.Genres
            });
        }
    }
}