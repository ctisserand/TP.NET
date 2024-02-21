using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASP.Server.Models;

namespace ASP.Server.ViewModels
{
    public class CreateGenreViewModel
    {
        [Required]
        public String Name { get; set; }

        // Ajouter ici tous les champ que l'utilisateur devra remplir pour ajouter un livre

        // Liste des genres séléctionné par l'utilisateur
        [Required(ErrorMessage = "You need at least 1 genre"), MinLength(1)]
        public IEnumerable<int> Books { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public IEnumerable<Book> AllBooks { get; init; }
    }
}