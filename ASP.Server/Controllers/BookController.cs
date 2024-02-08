using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using System.Collections.Generic;
using System.Linq;
using ASP.Server.Models;
using ASP.Server.ViewModels;
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


        public ActionResult Edit(EditBookViewModel model)
        {
            var bookToModify = libraryDbContext.Books.Include(book => book.Genres).SingleOrDefault(book => book.Id == model.Id);
            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis

            if (ModelState.IsValid)
            {
                var book = libraryDbContext.Books
                    .Include(b => b.Genres)
                    .FirstOrDefault(b => b.Id == model.Id);

                if (book == null)
                {
                    return NotFound();
                }

                // Mettre à jour les propriétés du livre avec les valeurs du modèle
                book.Title = model.Name;
                book.Author = model.Author;
                book.Price = model.Price;
                // Mettre à jour d'autres propriétés si nécessaire

                // Mettre à jour les genres associés au livre
                book.Genres.Clear();
                foreach (var genreId in model.Genres)
                {
                    var genre = libraryDbContext.Genre.Find(genreId);
                    if (genre != null)
                    {
                        book.Genres.Add(genre);
                    }
                }

                // Enregistrer les modifications dans la base de données
                libraryDbContext.SaveChanges();
                

                return RedirectToAction("List", "Book"); // Rediriger vers la liste des livres après la modification
            }

            // Si le modèle n'est pas valide, retourner le formulaire avec les erreurs
            return View(new EditBookViewModel()
            {
                Id = bookToModify.Id,
                Name = bookToModify.Name,
                Author = bookToModify.Author,
                Price = bookToModify.Price,
                Content = bookToModify.Content,
                AllGenres = libraryDbContext.Genre.ToList()
            });
        }

    }
}
