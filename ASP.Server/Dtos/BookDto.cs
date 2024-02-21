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
        public String Name { get; set; }
        public IEnumerable<AuthorWithoutBooksDto> Authors { get; set; }
        public double Price { get; set; }
        public String Content { get; set; }
        public IEnumerable<GenreWithoutBooksDto> Genres { get; set; }
    }
    
    public class BookWithoutAuthorsDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
        public String Content { get; set; }
        public IEnumerable<GenreWithoutBooksDto> Genres { get; set; }
    }
    
    public class BookWithoutGenresDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public IEnumerable<AuthorWithoutBooksDto> Authors { get; set; }
        public double Price { get; set; }
        public String Content { get; set; }
    }
    
    public class BookWithoutContentDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public IEnumerable<AuthorWithoutBooksDto> Authors { get; set; }
        public double Price { get; set; }
        public IEnumerable<GenreWithoutBooksDto> Genres { get; set; }
    }
    
    public class BookWithoutAuthorsAndGenresDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
        public String Content { get; set; }
    }
    
    public class BookWithoutAllDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
    }


    //TODO : Ajouter les propriétés nécessaires pour afficher les livres
    
    public class CreateBookDto
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public IEnumerable<int> Authors { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public String Content { get; set; }
        [Required] 
        public IEnumerable<int> Genres { get; set; }
    }

    public class UpdateBookDto
    {
        public String Name { get; set; }
        public IEnumerable<int> Authors { get; set; }
        public double Price { get; set; }
        public String Content { get; set; }
        public IEnumerable<int> Genres { get; set; }
    }
}
