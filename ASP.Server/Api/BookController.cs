using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Server.Database;
using ASP.Server.Models;
using AutoMapper;
using ASP.Server.Dtos;
using AutoMapper.QueryableExtensions;

namespace ASP.Server.Api
{

    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class BookController(LibraryDbContext libraryDbContext, IMapper mapper) : ControllerBase
    {
        private readonly LibraryDbContext libraryDbContext = libraryDbContext;
        private readonly IMapper mapper = mapper;

        // Methode a ajouter : 
        // - GetBooks
        [HttpGet]
        public ActionResult<IEnumerable<BookListDto>> GetBooks([FromQuery] List<int> genreIds, [FromQuery] int limit = 10, [FromQuery] int offset = 0)
        {
            IQueryable<Book> query = libraryDbContext.Livres; 
            if (offset >= 0 && limit <= 100) 
            {
                if (genreIds.Any()) // Vérifie s'il y a des IDs de genre
                {
                    query = query.Where(b => b.Genres.Any(g => genreIds.Contains(g.Id)));
                }

                var books = query
                            .Include(b => b.Genres)
                            .OrderBy(b => b.Id)
                            .Skip(offset)
                            .Take(limit)
                            .ProjectTo<BookListDto>(mapper.ConfigurationProvider) // Utilisez BookListDto ici
                            .ToList();

                return Ok(books);
            }
            else
            {
                return BadRequest("Offset and limit are not valid");
            }
        }



        // - GetBook
        //   - Entrée: Id du livre

        [HttpGet]
        public ActionResult<BookDto> GetBook([FromQuery] int id)
        {
            var book = libraryDbContext.Livres
                .Include(b => b.Genres)
                .FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                return Ok(mapper.Map<BookDto>(book));
            }
            else
            {
                return NotFound();
            }
        }
        //   - Sortie: Object livre entier

        // - GetGenres
        //   - Entrée: Rien
        [HttpGet]
        public ActionResult<IEnumerable<GenreDTo>> GetGenres()
        {
            var genres = libraryDbContext.Genres
                .ProjectTo<GenreDTo>(mapper.ConfigurationProvider)
                .ToList();

            return Ok(genres);
        }
        //   - Sortie: Liste des genres

        // Aide:
        // Pour récupéré un objet d'une table :
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.First()
        // Pour récupéré des objets d'une table :
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.ToList()
        // Pour faire une requète avec filtre:
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Skip().<Selecteurs>
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Take().<Selecteurs>
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Where(x => x == y).<Selecteurs>
        // Pour récupérer une 2nd table depuis la base:
        //   - .Include(x => x.yyyyy)
        //     ou yyyyy est la propriété liant a une autre table a récupéré
        //
        // Exemple:
        //   - Ex: libraryDbContext.MyObjectCollection.Include(x => x.yyyyy).Where(x => x.yyyyyy.Contains(z)).Skip(i).Take(j).ToList()

        // DTOs
        // transformation "à la main":
        //      my_array.Select(item => new ItemDto() { prop1 = item.prop1, prop2 = item.prop2, ... })
        // transformation avec AutoMapper
        //      Rajouter le mapping dans MappingProfile.cs
        //      this.mapper.Map<List<ItemDto>>(my_array);

        // Je vous montre comment faire la 1er, a vous de la compléter et de faire les autres !
        /*public ActionResult<IEnumerable<BookDto>> GetBooks()
        {
            // Exemple sans dependence externe
            // return libraryDbContext.Books.Select(b => new BookDto { Id = b.Id });
            // Exemple avec AutoMapper
            // return mapper.Map<List<BookDto>>(libraryDbContext.Books);
            throw new NotImplementedException("You have to do it your self");
        }
        */
    }
}

