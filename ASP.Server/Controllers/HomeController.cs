using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP.Server.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ASP.Server.Database;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Service;
using ASP.Server.Model;

namespace ASP.Server.Controllers
{
    public class StatisticModel
    {
        [Required]
        [Display(Name = "Nom")]
        public int NbLivreTotal { get; set; }
        public Dictionary<string, int> nbLivreAuteur { get; set; }

        public int nbMaxMot { get; set; }
        public int nbMinMot { get; set; }
        public double nbMedianMot { get; set; }
        public double nbMoyenneMot { get; set; }




        // Liste des genres séléctionné par l'utilisateur

        // Liste des genres a afficher à l'utilisateur
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibraryDbContext libraryDbContext;

        public HomeController(ILogger<HomeController> logger, LibraryDbContext libraryDbContext)
        {
            _logger = logger;
            this.libraryDbContext = libraryDbContext;

        }

        public ActionResult<StatisticModel> Index()
        {
            StatisticModel stats = new StatisticModel();
            stats.nbLivreAuteur= new Dictionary<string, int>(); 
            stats.NbLivreTotal = this.libraryDbContext.Books.Count();
            stats.nbMaxMot = this.libraryDbContext.Books.Max(b => LibraryService.wordCount(b.Contenu));
            stats.nbMinMot = this.libraryDbContext.Books.Min(b => LibraryService.wordCount(b.Contenu));
            stats.nbMedianMot = LibraryService.Median(this.libraryDbContext.Books.Select(b => b.Contenu).ToList());
            stats.nbMoyenneMot = this.libraryDbContext.Books.Average(b => LibraryService.wordCount(b.Contenu));
            var listeAuteur=this.libraryDbContext.Auteurs.Select(a => a.Nom).ToList();
            foreach (string auteur in listeAuteur)
            {
                var request = this.libraryDbContext.Books.Where(b => b.Auteur.Nom == auteur);
                int nombre = 0;
                if (request != null)
                    nombre = request.ToList().Count();

                stats.nbLivreAuteur.Add(auteur, nombre);
            }

        

            //stats.nbLivreAuteur=this.l
            return View(stats);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
