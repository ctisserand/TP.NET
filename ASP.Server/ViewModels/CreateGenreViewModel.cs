using System;
using System.Collections.Generic;
using System.Linq;
using ASP.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.ViewModels

{
    public class CreateGenreViewModel
    {
        [Required(ErrorMessage = "Le nom du genre est requis.")]
        [StringLength(100, ErrorMessage = "Le nom du genre ne doit pas dépasser 100 caractères.")]
        public string Nom { get; set; }
    }
}
