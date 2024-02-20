using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Auteur { get; set; }
        public double Prix { get; set; }
        public string Contenu { get; set; }
        public List<string> Genres { get; set; } 

        public BookDto()
        {
            Genres = new List<string>(); 
        }
    }
}
