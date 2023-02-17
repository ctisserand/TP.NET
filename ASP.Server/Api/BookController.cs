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
    public class BookDto
    {
        [Required]
        public string Nom { get; set; }
        public int Id { get; set; }
        public string Contenu { get; set; }
        public string Auteur { get; set; }
        public float Prix { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public List<GenreDto> Genres { get; init; }
    }

    public class BookNoContenu
    {
        [Required]
        public string Nom { get; set; }
        public int Id { get; set; }
        public string Auteur { get; set; }
        public float Prix { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public List<GenreDto> Genres { get; init; }
    }

    public class GenreDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }

    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }


        [Route("/api/[controller]")]
        public ActionResult<List<BookNoContenu>> GetBooks([FromQuery] List<int> genre, [FromQuery] int offset = 1, [FromQuery] int limit = 20)
        {
            HttpContext.Response.Headers.Add("Pagination", offset + "-" + (offset + limit) + "/" + this.libraryDbContext.Books.Count());

            bool filter = false;
            if(genre!=null)
                filter = genre.Count >0;
            List<Book> listBooks;
            if (filter)
                listBooks = this.libraryDbContext.Books.Include(b => b.Genres).Where(b => b.Id >= offset && b.Genres.Any(x => genre.Any(y => y == x.Id))).OrderBy(b => b.Id).Take(limit).ToList();
            else listBooks = this.libraryDbContext.Books.Include(b => b.Genres).Where(b => b.Id >= offset).OrderBy(b => b.Id).Take(limit).ToList();
            List<BookNoContenu> booksNoContenu = new List<BookNoContenu>();
            listBooks.ForEach(book => booksNoContenu.Add(LibraryService.ConvertToBookNoContenu(book)));
            return booksNoContenu;
        }

        [Route("/api/[controller]/{id}")]
        public ActionResult<BookDto> Book(int id = 1)
        {
            try
            {
                return LibraryService.ConvertToBookDto(this.libraryDbContext.Books.Include(b => b.Genres).Where(b => b.Id == id).FirstOrDefault());
            }
            catch
            {
                return NotFound("Pas de book avec id n°" + id);
            }
        }
    }
}

