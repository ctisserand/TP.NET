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

        [Required(ErrorMessage = "Le nom du livre est requis.")]
        public String Nom { get; set; }

        [Required(ErrorMessage = "Le nom de l'auteur est requis.")]
        public String Auteur { get; set; }
        public double Prix { get; set; }

        [Required(ErrorMessage = "Le contenu du livre est requis.")]
        public String Contenu { get; set; } 
        public List<Genre> Genres { get; set; }
        
        public Book() { 
            Genres = new List<Genre>();
        }   

    }
}