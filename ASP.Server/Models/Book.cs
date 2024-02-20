using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASP.Server.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        // Mettez ici les propriété de votre livre: Nom, Autheur, Prix, Contenu et Genres associés
        // N'oublier pas qu'un livre peut avoir plusieur genres
        
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public double Price { get; set; }
        public string Content { get; set; }
        public List<Genre> Genres { get; set; }
    }
}