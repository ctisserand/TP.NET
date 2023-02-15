using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.Server.Api;
using ASP.Server.Model;


namespace ASP.Server.Service
{
    class LibraryService
    {
        private static LibraryService instance;
        public static LibraryService Instance { get
            {
                if (instance == null)
                    instance = new LibraryService();
                return instance;
            }
        }

        public static BookNoContenu ConvertToBookNoContenu(Book book)
        {
            List<GenreDto> genres = new List<GenreDto>();
            book.Genres.ForEach(g => genres.Add(new GenreDto() { Id = g.Id, Nom = g.Nom, })) ;
            return new BookNoContenu { Id = book.Id, Auteur = book.Auteur, Nom = book.Nom, Prix = book.Prix, Genres = genres };
        }

        public static BookDto ConvertToBookDto(Book book)
        {
            List<GenreDto> genres = new List<GenreDto>();
            book.Genres.ForEach(g => genres.Add(new GenreDto() { Id = g.Id, Nom = g.Nom, }));
            return new BookDto { Id = book.Id, Auteur = book.Auteur, Nom = book.Nom, Prix = book.Prix, Contenu = book.Contenu, Genres = genres };
        }

        public static GenreDto ConvertToGenreDto(Genre genre)
        {
            return new GenreDto { Id = genre.Id, Nom = genre.Nom};
        }

    }
}
