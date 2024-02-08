using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using System.Collections.Generic;
using System.Linq;
using ASP.Server.Models;
using ASP.Server.ViewModels;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.Controllers
{
    public class CreateGenreModel
    {
        [Required(ErrorMessage = "Le nom du genre est requis.")]
        public string Name { get; set; }
    }

    public class EditGenreModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class GenreController : Controller
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GenreController(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public ActionResult<IEnumerable<Genre>> List()
        {
            IEnumerable<Genre> listGenres = _libraryDbContext.Genre.ToList();
            return View(listGenres);
        }

        public ActionResult Create()
        {
            var model = new CreateGenreModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateGenreModel genre)
        {
            if (ModelState.IsValid)
            {
                _libraryDbContext.Add(new Genre() { Name = genre.Name });
                _libraryDbContext.SaveChanges();
                return RedirectToAction(nameof(List));
            }

            return View(genre);
        }
        public ActionResult<EditGenreModel> Edit(EditGenreModel genre)
        {
            var genreToEdit = _libraryDbContext.Genre.Single(g => g.Id == genre.Id );


            if (ModelState.IsValid)
            {

                genreToEdit.Name = genre.Name;
                _libraryDbContext.SaveChanges();
                return RedirectToAction("List");

            };

            return View(new EditGenreModel()
            { Id = genreToEdit.Id, Name = genreToEdit.Name });

        }
    }
}
