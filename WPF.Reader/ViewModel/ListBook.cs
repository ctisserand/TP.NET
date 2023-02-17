using CommunityToolkit.Mvvm.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }

        public ObservableCollection<Book> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;

        public ListBook()
        {
            Task.Run(() =>
            {
                Ioc.Default.GetRequiredService<LibraryService>().SearchAllBooks();
            });
            ItemSelectedCommand = new RelayCommand(book => { 
                /* the livre devrais etre dans la variable book */ 
            });
        }
    }
}
