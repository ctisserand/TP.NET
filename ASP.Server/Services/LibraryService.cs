using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.Server.Api;
using ASP.Server.Model;
using static System.Net.Mime.MediaTypeNames;


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
            return new BookNoContenu { Id = book.Id, Auteur = book.Auteur.Nom, Nom = book.Nom, Prix = book.Prix, Genres = genres };
        }

        public static BookDto ConvertToBookDto(Book book)
        {
            List<GenreDto> genres = new List<GenreDto>();
            book.Genres.ForEach(g => genres.Add(new GenreDto() { Id = g.Id, Nom = g.Nom, }));
            return new BookDto { Id = book.Id, Auteur = book.Auteur.Nom, Nom = book.Nom, Prix = book.Prix, Contenu = book.Contenu, Genres = genres };
        }

        public static GenreDto ConvertToGenreDto(Genre genre)
        {
            return new GenreDto { Id = genre.Id, Nom = genre.Nom};
        }
        public static int wordCount(string text)
        {
            int wordCount = 0, index = 0;

            // skip whitespace until first word
            while (index < text.Length && char.IsWhiteSpace(text[index]))
                index++;

            while (index < text.Length)
            {
                // check if current char is part of a word
                while (index < text.Length && !char.IsWhiteSpace(text[index]))
                    index++;

                wordCount++;

                // skip whitespace until next word
                while (index < text.Length && char.IsWhiteSpace(text[index]))
                    index++;
            }
            return wordCount;
        }
        public static double Median(List<string> items)
        {
            List<int> tailleByContenu = new List<int>();
            foreach (string i in items)
            {
                tailleByContenu.Add(wordCount(i));
            }
            var data = tailleByContenu.OrderBy(n => n).ToArray();
            if (data.Length % 2 == 0)
                return (data[data.Length / 2 - 1] + data[data.Length / 2]) / 2.0;
            return data[data.Length / 2];
        }

    }
}
