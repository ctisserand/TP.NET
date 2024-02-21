using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.Dtos
{
        public class AuthorDto
        {
                public int Id { get; set; }
                public String Name { get; set; }
                public IEnumerable<BookWithoutAllDto> Books { get; set; }
        }
        
        public class AuthorWithoutBooksDto
        {
                public int Id { get; set; }
                public String Name { get; set; }
        }
        
        public class CreateAuthorDto
        {
                [Required]
                public String Name { get; set; }
        }
}