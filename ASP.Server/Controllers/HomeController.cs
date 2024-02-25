using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ASP.Server.ViewModels;
using System.ComponentModel.DataAnnotations;
using ASP.Server.Database;
using ASP.Server.Service;
using System.Threading.Tasks;
using System.Data.Entity;




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
        public int WordCount { get; set; }

    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private readonly IMapper mapper = mapper;

        private readonly LibraryDbContext libraryDbContext;

        private LibraryService libaryService;
        private object _context;

        public HomeController(ILogger<HomeController> logger, LibraryDbContext libraryDbContext, LibraryService libaryService)
        {
            _logger = logger;
            this.libraryDbContext = libraryDbContext;
            this.libaryService = libaryService;
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

        /*public IActionResult Index()
        {
            var books = libraryDbContext.Books.ToList();

            // Calcul des statistiques
            int totalBooks = books.Count;

            int maxWords = libraryDbContext.Books.Max(b => b.WordCount);
            // var maxWordCount = books.Max(b => b.Content.WordCount());

            //  int maxWordCount = libraryDbContext.Books.Max(book => book.WordCount);
            // ViewBag.MaxWords = maxWordCount;

            /* var maxWordCount = libraryDbContext.Books.Max(book => book.WordCount); // Remplacez 'WordCount' par le nom de votre propriété

             var statModel = new StatisticModel
             {
                 NbLivreTotal = libraryDbContext.Books.Count(),
                 nbMaxMot = maxWordCount,

             };

             ViewBag.MaxWordCount = maxWordCount;

            // return View(statModel);


             var minWordCount = books.Min(b => b.Content.WordCount());
             var averageWordCount = books.Average(b => b.Content.WordCount());

             var wordCounts = books.Select(b => b.Content.WordCount()).OrderBy(count => count).ToList();
             double medianWordCount;
             int middleIndex = wordCounts.Count / 2;

             if (wordCounts.Count % 2 != 0)
             {
                 medianWordCount = wordCounts[middleIndex];
             }
             else
             {
                 medianWordCount = (wordCounts[middleIndex - 1] + wordCounts[middleIndex]) / 2.0;
             }

             // Nombre de livres par auteur
            /* var booksPerAuthor = books
                 .SelectMany(b => b.Authors.Select(a => new { a.Name, BookName = b.Name }))
                 .GroupBy(x => x.Name)
                 .Select(group => new { Author = group.Key, Count = group.Count() })
                 .ToList();*/

        // Passez les statistiques à la vue
        /*ViewBag.TotalBooks = totalBooks;
        ViewBag.MaxWords = maxWords; 

        /* ViewBag.MaxWordCount = maxWordCount;
         ViewBag.MinWordCount = minWordCount;
         ViewBag.AverageWordCount = averageWordCount;
         ViewBag.MedianWordCount = medianWordCount;
       //  ViewBag.BooksPerAuthor = booksPerAuthor;*/




        //return View();
        //}

        public IActionResult Index()
        {
            var viewModel = new StatisticsViewModel(); 
          viewModel.TotalBooks = libraryDbContext.Books.Count();

           

            return View(viewModel);
        }



        public async Task<IActionResult> Statistics()
        {
            var viewModel = new StatisticsViewModel(); // Remplacez MonViewModel par le modèle approprié
            // Obtention du nombre total de livres
            int totalBooks = await libraryDbContext.Books.CountAsync();

            // Obtention du nombre de livres par auteur
            /*  var booksPerAuthor = await libraryDbContext.Authors
                  .Include(Author => livre.Auteur)
                  .GroupBy(livre => livre.Auteur.Nom)
                  .Select(group => new { Author = group.Key, Count = group.Count() })
                  .ToDictionaryAsync(g => g.Author, g => g.Count);*/

            // Obtention des statistiques sur le nombre de mots
            var wordCounts = await libraryDbContext.Books
                .Select(book => book.Content.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length)
                .ToListAsync();

            var maxWords = wordCounts.Max();
            var minWords = wordCounts.Min();
            var averageWords = wordCounts.Average();

            // Calcul de la médiane
            var orderedWordCounts = wordCounts.OrderBy(x => x).ToList();
            int middleIndex = orderedWordCounts.Count / 2;
            var medianWords = orderedWordCounts.Count % 2 != 0
                ? orderedWordCounts[middleIndex]
                : (orderedWordCounts[middleIndex - 1] + orderedWordCounts[middleIndex]) / 2.0;

            // Construction du viewModel avec toutes les statistiques
          //  var viewModel = new StatisticsViewModel
            {
              /*  TotalBooks = totalBooks,
                // BooksPerAuthor = booksPerAuthor,
                MaxWords = maxWords,
                MinWords = minWords,
                AverageWords = averageWords,
                MedianWords = medianWords*/
            };

            return View(viewModel);
        }


    }
}
