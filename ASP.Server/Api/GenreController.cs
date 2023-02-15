using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Server.Database;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ASP.Server.Service;

namespace ASP.Server.Api
{

    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly LibraryDbContext libraryDbContext;

        public GenreController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }


        [Route("/api/[controller]")]
        public ActionResult<List<GenreDto>> GetGenres()
        {
            List<Genre> listGenres = this.libraryDbContext.Genre.Include(b => b.Livres).ToList();
            List<GenreDto> genreDtos = new List<GenreDto>();
            listGenres.ForEach(genre => genreDtos.Add(LibraryService.ConvertToGenreDto(genre)));
            return genreDtos;
        }
    }
}

