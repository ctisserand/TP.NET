using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using Windows.Web.Http;
using WPF.Reader.Model;
using WPF.Reader.OpenApi;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        //Création de la possibilité de faire des requêtes HTTP pour récupérer les livres depuis l'API web
        private readonly HttpClient _httpClient = new HttpClient();

        //Création d'un observable 
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>() {};

        public LibraryService() {
            UpdateBooks();
        }

        public void UpdateBooks()
        {
            Task.Run(async () => await FetchBooksAsync());
        }

        public async Task FetchBooksAsync()
        {
            try
            {
                string url = "https://localhost:5001/api/Book/GetBooks"; // Récupération de tous les livres
                Uri uri = new Uri(url); //Création d'un objet URI
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    //Lecture des données récupérées
                    var json = await response.Content.ReadAsStringAsync();
                    //Transformation des données récupérées JSON en listes d'objets
                    var books = JsonConvert.DeserializeObject<List<Book>>(json);
                    if (books != null)
                    {
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            Books.Clear();
                            foreach (var book in books)
                            {
                                //Ajout des livres dans notre liste d'objets
                                Books.Add(book);
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer l'exception (par exemple, en affichant un message d'erreur)
                Console.WriteLine(ex.Message);
            }
        }
    }
}
