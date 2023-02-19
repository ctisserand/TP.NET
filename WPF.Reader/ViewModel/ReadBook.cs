using CommunityToolkit.Mvvm.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WPF.Reader.Model;
using WPF.Reader.Service;
using System.Speech.Synthesis;

namespace WPF.Reader.ViewModel
{
    class ReadBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Book CurrentBook { set;  get; }

        public ReadBook(Book book)
        {
            book.Contenu = Ioc.Default.GetRequiredService<LibraryService>().GetBookById(book).Contenu;
            CurrentBook = book;
        }
    }

    /* Cette classe sert juste a afficher des donnée de test dans le designer */
    class InDesignReadBook : ReadBook
    {
        public InDesignReadBook() : base(new Book() /*{ Title = "Test Book" }*/ ) { }

    }
}
