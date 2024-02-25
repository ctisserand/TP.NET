using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace ASP.Server.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
      //  public int WordCount { get; set; }

        // Mettez ici les propriété de votre livre: Nom, Autheur, Prix, Contenu et Genres associés
        // N'oublier pas qu'un livre peut avoir plusieur genres

        public string Name { get; set; }
        public List<Author> Authors { get; set; }
        public double Price { get; set; }
        public string Content { get; set; }
        public List<Genre> Genres { get; set; }



        [NotMapped]
        public int WordCount
        {
            get { return !string.IsNullOrEmpty(Content) ? Content.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length : 0; }
        }

        public Book()
        {
            Genres = new List<Genre>();
        }
    }



}