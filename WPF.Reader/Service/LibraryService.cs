using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using WPF.Reader.Model;
using WPF.Reader.ViewModel.Api;
using WPF.Reader.ViewModel.Model;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouter et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()
        public ObservableCollection<Genre> Genres { get; set; } = new ObservableCollection<Genre>();

        // C'est aussi ici que vous ajouterez les requête réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
        // Faite bien attention a ce que votre requête réseau ne bloque pas l'interface 

        public async void UpdateGenre()
        {
            var genres = await new GenreApi().GenreGetGenresAsync();
            Application.Current.Dispatcher.Invoke(() => {
                Genres.Clear();
                foreach (GenreDto genre in genres)
                {
                    Genres.Add(new Genre(genre.Nom, genre.Id));
                }
            });
        }

        public ObservableCollection<Book> BooksByGenre { get; set; } = new ObservableCollection<Book>();

        public async void SearchBooksByGenre(Genre genre)
        {
            List<int> idsGenre = new List<int>();
            idsGenre.Add(genre.IdGenre);
            var books = await new BookApi().BookGetBooksAsync(idsGenre);
            Application.Current.Dispatcher.Invoke(() =>
            {
                BooksByGenre.Clear();
                foreach (BookNoContenu book in books)
                {
                    Book b = new Book()
                    {
                        Id = book.Id,
                        Auteur = book.Auteur,
                        Nom = book.Nom,
                        Prix = book.Prix,
                        Contenu = "",
                        Genres = book.Genres
                    };
                    b.GenresInString();
                    BooksByGenre.Add(b);
                }
            }); 
        }

        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();

        public async void SearchAllBooks()
        {
            var books = await new BookApi().BookGetBooksAsync();
            Application.Current.Dispatcher.Invoke(() =>
            {
                Books.Clear();
                foreach (BookNoContenu book in books)
                {
                    Book b = new Book()
                    {
                        Id = book.Id,
                        Auteur = book.Auteur,
                        Nom = book.Nom,
                        Prix = book.Prix,
                        Contenu = "",
                        Genres = book.Genres
                    };
                    b.GenresInString();
                    Books.Add(b);
                }
            });
        }

        public BookDto GetBookById(Book book)
        {
            return new BookApi().BookBookAsync(book.Id).Result;
        }

    }
}
