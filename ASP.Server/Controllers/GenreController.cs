using System.Collections.Generic;
using System.Linq;
using ASP.Server.Database;
using ASP.Server.Models;
using ASP.Server.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP.Server.Controllers
{
    public class GenreController(LibraryDbContext libraryDbContext, IMapper mapper) : Controller
    {
        private readonly LibraryDbContext libraryDbContext = libraryDbContext;
        private readonly IMapper mapper = mapper;

        // A vous de faire comme BookController.List mais pour les genres !

        public ActionResult<IEnumerable<Author>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            IEnumerable<Genre> ListGenres = libraryDbContext.Genres.
                Include(g => g.Books);
            return View(ListGenres);
        }

        public ActionResult<CreateGenreViewModel> Create(CreateGenreViewModel genre)
        {
            // Le IsValid est True uniquement si tous les champs de CreateGenreModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                // Completer la création du genre avec toute les information nécéssaire que vous aurez ajoutez, et mettez la liste des gener récupéré de la base aussi
                libraryDbContext.Add(new Genre()
                {
                    Name = genre.Name,
                    Books = genre.Books.Select(id => libraryDbContext.Books.Find(id)).ToList()
                });
                libraryDbContext.SaveChanges();
            }

            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            return View(new CreateGenreViewModel() { AllBooks = libraryDbContext.Books });
        }
    }
}