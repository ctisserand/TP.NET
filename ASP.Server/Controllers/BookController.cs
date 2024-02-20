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
            IEnumerable<Book> ListBooks = libraryDbContext.Livres;
            return View(ListBooks);
        }

        public ActionResult<CreateBookViewModel> Create(CreateBookViewModel book)
        {
            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi
                libraryDbContext.Add(new Book() {  });
                libraryDbContext.SaveChanges();
            }

            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            return View(new CreateBookViewModel() { AllGenres = libraryDbContext.Genres});
        }
    }
}
