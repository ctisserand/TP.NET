using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ASP.Server.Models;
using ASP.Server.ViewModels;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace ASP.Server.Controllers
{
    public class BookController(LibraryDbContext libraryDbContext, IMapper mapper) : Controller
    {
        private readonly LibraryDbContext libraryDbContext = libraryDbContext;

        public ActionResult<IEnumerable<Book>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            IEnumerable<Book> ListBooks = libraryDbContext.Books;
            return View(ListBooks);
        }

        public ActionResult Create(CreateBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    Title = model.Name,
                    Author = model.Author,
                    Price = model.Price,
                    Content = model.Content,
                };

                // Ajouter les genres sélectionnés par l'utilisateur
                foreach (var genreId in model.Genres)
                {
                    var genre = libraryDbContext.Genre.Find(genreId);
                    if (genre != null)
                    {
                        book.Genres.Add(genre);
                    }
                }
                libraryDbContext.Books.Add(book);
                libraryDbContext.SaveChanges();

                return RedirectToAction(nameof(List)); // Rediriger vers la liste des livres après l'ajout
            }

            // Préparer de nouveau les genres pour le cas où la validation échoue

            return View(new CreateBookViewModel() { AllGenres = libraryDbContext.Genre.ToList() });

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var bookToDelete = libraryDbContext.Books.Find(id);
            if (bookToDelete == null)
            {
                return NotFound();
            }

            libraryDbContext.Books.Remove(bookToDelete);
            libraryDbContext.SaveChanges();

            return RedirectToAction(nameof(List)); // Rediriger vers la liste des livres après la suppression
        }

    }
}
