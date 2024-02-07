using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using ASP.Server.Models;

namespace ASP.Server.ViewModels
{
    public class EditBookViewModel
    {
        [Required]
        public int Id { get; set; }
        public String Name { get; set; }
        public string Author { get; set; } // Ajouté
        public decimal Price { get; set; } // Ajouté
        public string Content { get; set; } // Ajouté

        // Ajouter ici tous les champ que l'utilisateur devra remplir pour ajouter un livre

        // Liste des genres séléctionné par l'utilisateur
        [Required(ErrorMessage = "You need at least 1 genre"), MinLength(1)]
        public IEnumerable<int> Genres { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public IEnumerable<Genre> AllGenres { get; init; }
    }
}
