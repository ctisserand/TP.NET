using System.Collections.ObjectModel;
using WPF.Reader.Model;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        private static LibraryService instance;
        public static LibraryService Instance
        {
            get
            {
                if (instance == null)
                    instance = new LibraryService();

                return instance;
            }
        }

        public Book CurrentBook { get; set; }


        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut pas réaffecter la variable Books, mais juste lui ajouer et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>() {
            new Book() { }
        };

        // C'est aussi ici que vous ajouterez les requète réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la vriable Books !
    }
}
