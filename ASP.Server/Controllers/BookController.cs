using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net;

namespace ASP.Server.Controllers
{
    public class CreateBookModel
    {
        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }
        public int Id { get; set; }
        public string Contenu { get; set; }
        public String Auteur { get; set; }
        public float Prix { get; set; }

        // Liste des genres séléctionné par l'utilisateur
        public List<int> GenresSelectionne { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public List<Genre> AllGenres { get; init;  }
    }

    public class BookController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public ActionResult<List<Object>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            List<Book> ListBooks = this.libraryDbContext.Books.Include(b => b.Genres).Include(b => b.Auteur).ToList();
            var AllGenres = this.libraryDbContext.Genre.ToList();
            var AllAuteurs = this.libraryDbContext.Auteurs.ToList();

            List<Object> values = new List<Object>();
            values.Add(ListBooks);
            values.Add(AllGenres);
            values.Add(AllAuteurs);
            return View(values);
        }

        public ActionResult<CreateBookModel> Create(CreateBookModel book)
        {
            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                // Il faut intéroger la base pour récupérer l'ensemble des objets genre qui correspond aux id dans CreateBookModel.Genres
                List<Genre> genres = this.libraryDbContext.Genre.Where(x => book.GenresSelectionne.Contains(x.Id)).ToList();
                // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi
                var trouve = this.libraryDbContext.Auteurs.Where(x => book.Auteur == x.Nom).ToList();
                if (trouve.Count == 0)
                {
                    Auteur a = new Auteur() { Nom = book.Auteur };
                    this.libraryDbContext.Add(a);
                    this.libraryDbContext.SaveChanges();
                    trouve.Add(a);
                }
                this.libraryDbContext.Add(new Book()
                { Auteur = trouve[0], Nom = book.Name, Prix = book.Prix, Contenu = book.Contenu, Genres = genres }
                );
                this.libraryDbContext.SaveChanges();
                return RedirectToAction("List");

            }


            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            return View(new CreateBookModel() { AllGenres = this.libraryDbContext.Genre.ToList()} );
        }
        public ActionResult Edit(int Id)
        {
            var book = this.libraryDbContext.Books.Include(b => b.Genres).Include(b => b.Auteur).Where(b => b.Id == Id).First();
            return View(new CreateBookModel() { Id = Id, Name = book.Nom, Auteur=book.Auteur.Nom, Prix = book.Prix, Contenu = book.Contenu, AllGenres = this.libraryDbContext.Genre.ToList() }); ;

        }
        [HttpPost]
        public ActionResult Edit(CreateBookModel book)
        {
            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                // Il faut intéroger la base pour récupérer l'ensemble des objets genre qui correspond aux id dans CreateBookModel.Genres
                List<Genre> genres = this.libraryDbContext.Genre.Where(x => book.GenresSelectionne.Contains(x.Id)).ToList();
                // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi
                var bookEdit = this.libraryDbContext.Books.Include(b => b.Genres).Include(b => b.Auteur).Where(b => b.Id == book.Id).First();
                var trouve = this.libraryDbContext.Auteurs.Where(x => book.Auteur == x.Nom).ToList();
                if (trouve.Count == 0)
                {
                    Auteur a = new Auteur() { Nom = book.Auteur };
                    this.libraryDbContext.Add(a);
                    this.libraryDbContext.SaveChanges();
                    trouve.Add(a);
                }
                bookEdit.Auteur = trouve[0];
                bookEdit.Nom = book.Name;
                bookEdit.Prix = book.Prix;
                bookEdit.Contenu = book.Contenu;
                bookEdit.Genres = genres;
                this.libraryDbContext.Update(bookEdit);
                this.libraryDbContext.SaveChanges();
            }


            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var book = this.libraryDbContext.Books.Include(b => b.Genres).Include(b => b.Auteur).Where(b => b.Id == id).First();
            this.libraryDbContext.Remove(book);
            this.libraryDbContext.SaveChanges();
            return RedirectToAction("List");
        }


    }
}
