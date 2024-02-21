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
    public class BookController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;
        private readonly IMapper mapper;

        public BookController(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            this.libraryDbContext = libraryDbContext;
            this.mapper = mapper;
        }

        public ActionResult<IEnumerable<Book>> List()
        {
            IEnumerable<Book> listBooks = libraryDbContext.Livres.ToList();
            return View(listBooks);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CreateBookViewModel
            {
                AllGenres = libraryDbContext.Genres.ToList() ?? new List<Genre>()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    Nom = viewModel.Nom,
                    Auteur = viewModel.Auteur,
                    Prix = viewModel.Prix,
                    Contenu = viewModel.Contenu,
                    Genres = libraryDbContext.Genres.Where(genre => viewModel.Genres.Contains(genre.Id)).ToList()
                };

                libraryDbContext.Livres.Add(book);
                libraryDbContext.SaveChanges();
                return RedirectToAction(nameof(List));
            }

            //Si le modèle n'est pas valide, on le renvoie à la vue
            var newViewModel = new CreateBookViewModel
            {
                Nom = viewModel.Nom,
                Auteur = viewModel.Auteur,
                Prix = viewModel.Prix,
                Contenu = viewModel.Contenu,
                Genres = viewModel.Genres,
                AllGenres = libraryDbContext.Genres.ToList() ?? new List<Genre>()
            };
            return View(newViewModel);
        }
    }
}
