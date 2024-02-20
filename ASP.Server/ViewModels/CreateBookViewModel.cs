using ASP.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.ViewModels
{
    // Un ViewModel représente le contenu envoyé à la vu mais aussi le contenu récupéré a travers une requète HTTP:
    // -> /api/1.0.0/xxx?prop1=123&prop2=azerty&prop3[]=0&prop3[]=1
    public class CreateBookViewModel
    {
        [Required]
        public String Nom { get; set; }

        [Required]
        public String Auteur { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à 0.")]
        public double Prix { get; set; }

        [Required]
        public String Contenu { get; set; }

        // Liste des genres séléctionné par l'utilisateur
        [Required(ErrorMessage = "You need at least 1 genre"), MinLength(1)]
        public IEnumerable<int> Genres { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public IEnumerable<Genre> AllGenres { get; init; }

    }


}
