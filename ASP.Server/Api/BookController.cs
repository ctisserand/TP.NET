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
        //   - Entrée: Optionel -> Liste d'Id de genre, limit -> defaut à 10, offset -> défaut à 0
        //     Le but de limit et offset est dé créer un pagination pour ne pas retourner la BDD en entier a chaque appel
        //   - Sortie: Liste d'object contenant uniquement: Auteur, Genres, Titre, Id, Prix
        //     la liste restourner doit être compsé des élément entre <offset> et <offset + limit>-
        //     Dans [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20] si offset=8 et limit=5, les élément retourner seront : 8, 9, 10, 11, 12

        // - GetBook
        //   - Entrée: Id du livre
        //   - Sortie: Object livre entier

        // - GetGenres
        //   - Entrée: Rien
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
        [HttpGet("/api/book")]
        public async Task<ActionResult<IEnumerable<BookWContentDto>>> GetBooks([FromQuery] List<int>? genreIds = null,
            [FromQuery] int limit = 10, [FromQuery] int offset = 0)
        {
            var query = libraryDbContext.Books.AsQueryable();
            if (genreIds != null && genreIds.Count > 0)
            {
                query = query.Where(b => b.Genres.Any(bg => genreIds.Contains(bg.Id)));
            }

            var books = await query.Skip(offset).Take(limit).ProjectTo<BookWContentDto>(mapper.ConfigurationProvider).ToListAsync();
            return Ok(books);
            // Exemple sans dependence externe
            // return libraryDbContext.Books.Select(b => new BookDto { Id = b.Id });|||
            // Exemple avec AutoMapper
            // return mapper.Map<List<BookDto>>(libraryDbContext.Books);
            throw new NotImplementedException("You have to do it your self");
        }
        
        [HttpGet("/api/book/{id}")]
        public ActionResult<BookDto> GetBook(int id)
        {
            var book = libraryDbContext.Books.Where(b => b.Id == id).ProjectTo<BookDto>(mapper.ConfigurationProvider).FirstOrDefault();
            return Ok(book);
            throw new NotImplementedException("You have to do it your self");
        }

        [HttpGet("/api/genres")]
        public ActionResult<IEnumerable<GenreDto>> GetGenres()
        {
            var genres = libraryDbContext.Genres.ProjectTo<GenreDto>(mapper.ConfigurationProvider).ToListAsync();
            return Ok(genres);
            throw new NotImplementedException("You have to do it your self");
        }
    }
}