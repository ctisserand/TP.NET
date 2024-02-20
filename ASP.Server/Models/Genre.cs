using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Server.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du genre est requis.")]
        public String Nom { get; set; }
        public List<Book> Livres { get; set; }

        public Genre() {
            Livres = new List<Book>();
        }
    }

}

