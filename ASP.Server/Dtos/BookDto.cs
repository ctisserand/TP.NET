using ASP.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace ASP.Server.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public IEnumerable<int> Authors { get; set; }
        public double Price { get; set; }
        public string Content { get; set; }
    }
    
    public class BookWithGenresDto
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public IEnumerable<int> Authors { get; set; }
        public double Price { get; set; }
        public string Content { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
    }

    //TODO : Ajouter les propriétés nécessaires pour afficher les livres
    
    public class CreateBookDto
    {
        [Required]
        public String Title { get; set; }
        [Required]
        public IEnumerable<int> Authors { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Content { get; set; }
        [Required] 
        public IEnumerable<int> Genres { get; set; }
    }

    public class UpdateBookDto
    {
        public String Title { get; set; }
        public IEnumerable<int> Authors { get; set; }
        public double Price { get; set; }
        public string Content { get; set; }
        public IEnumerable<int> Genres { get; set; }
    }

}
