using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    //Permet de notifier l'interface utilisateur des changements de propriété, utilisé pour le data binding bi-directionnel
    public partial class DetailsBook : INotifyPropertyChanged
    {
        //Ici, on récupère le livre en cours, soit CurrentBook
        public Book CurrentBook { get; init; }

        private INavigationService _navigationService;


        public DetailsBook(Book book)
        {
            _navigationService = Ioc.Default.GetService<INavigationService>();
            CurrentBook = book;
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(CurrentBook)));
            Task.Run(async () =>
            {
                await Ioc.Default.GetService<LibraryService>().FetchBookDetails(CurrentBook.Id);

            });
        }

        //Déclenché chaque fois qu'une propriété du ViewModel change
        public event PropertyChangedEventHandler PropertyChanged;


        // Une commande permet de recevoir des évènement de l'IHM
        //RelayCommand permet de prendre une action en paramètre
        //Donc ici, on récupère l'action de l'utilisateur (par exemple, s'il clique sur un bouton) et on détermine le comportement de l'application
        public ICommand ReadBook2Command { get; init; } = new RelayCommand<Book>(x => { });

        // Vous pouvez aussi utiliser cette forme pour définir une commande. La ligne du dessus fait strictement la même chose, choisissez une des 2 formes
        [RelayCommand]
        public void ReadBook(Book book)
        {
        }

        public ICommand GoBackCommand => new RelayCommand(() =>
        {
            if (_navigationService.CanGoBack)
            {
                _navigationService.GoBack();
            }
        });
    }
    public class InDesignDetailsBook() : DetailsBook(new Book())
    {
    }
}
