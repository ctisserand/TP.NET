using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ASP.Server.Dtos
{
    public class GenreDto
    {
        //TODO : Ajouter les propriétés nécessaires pour afficher les genres
        public int Id { get; set; }
        public String Name { get; set; }
        public IEnumerable<BookWithoutAllDto> Books { get; set; }
    }
    
    public class GenreWithoutBooksDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
    
    public class CreateGenreDto
    {
        [Required]
        public String Name { get; set; }
        public IEnumerable<int> Books { get; set; }
    }
    
    
    public class UpdateGenreDto
    {
        public string Name { get; set; }
        public IEnumerable<int> Books { get; set; }
    }
}
