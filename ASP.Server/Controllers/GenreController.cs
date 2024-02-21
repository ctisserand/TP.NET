using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ASP.Server.Models;

namespace ASP.Server.Controllers
{
    public class GenreController : Controller
    {
        private readonly LibraryDbContext _libraryDbContext;

        public GenreController(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        //lister les genres
        public IActionResult List()
        {
            var genres = _libraryDbContext.Genres.ToList();
            return View(genres);
        }

        //formulaire pour ajouter un nouveau genre
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Fonction pour ajouter un nouveau genre
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateGenreViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var genre = new Genre
                {
                    Nom = viewModel.Nom
                };

                _libraryDbContext.Genres.Add(genre);
                _libraryDbContext.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            // Si le formulaire n'est pas valide, on retourne à la vue
            return View(viewModel);
        }
    }
}