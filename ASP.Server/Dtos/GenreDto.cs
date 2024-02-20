using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ASP.Server.Dtos
{
    public class GenreDto
    {
        //TODO : Ajouter les propriétés nécessaires pour afficher les genres
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class GenreWithBooksDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BookDto> Books { get; set; }
    }
    
    public class CreateGenreDto
    {
        [Required]
        public string Name { get; set; }
    }
    
    public class UpdateGenreDto
    {
        public string Name { get; set; }
    }
    
    public class UpdateGenreWithBooksDto
    {
        public string Name { get; set; }
        [Required]
        public IEnumerable<int> Books { get; set; }
    }
}
