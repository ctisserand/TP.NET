using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MAUI.Reader.Model;
using MAUI.Reader.Service;
using System.Windows.Input;

using CommunityToolkit.Maui.Alerts;

namespace MAUI.Reader.ViewModel
{
    public partial class ListBooks : INotifyPropertyChanged
    {
        public ListBooks()
        {
            ItemSelectedCommand = new Command(OnItemSelectedCommand);
        }
        public ICommand ItemSelectedCommand { get; private set; }
        public void OnItemSelectedCommand(object book)
        {
        }


        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!
        public ObservableCollection<Book> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;


        public int Count { get; set; }

        [RelayCommand]
        public void CounterClicked()
        {
            Count++;

            Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(new Book());
        }
    }
}
