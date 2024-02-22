using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.Model;

namespace WPF.Reader.ViewModel
{
    //Permet de notifier l'interface utilisateur des changements de propriété, utilisé pour le data binding bi-directionnel
    public partial class DetailsBook(Book book) : INotifyPropertyChanged
    {
        //Déclenché chaque fois qu'une propriété du ViewModel change
        public event PropertyChangedEventHandler PropertyChanged;

        //Ici, on récupère le livre en cours, soit CurrentBook
        public Book CurrentBook { get; init; } = book;


        // Une commande permet de recevoir des évènement de l'IHM
        //RelayCommand permet de prendre une action en paramètre
        //Donc ici, on récupère l'action de l'utilisateur (par exemple, s'il clique sur un bouton) et on détermine le comportement de l'application
        public ICommand ReadBook2Command { get; init; } = new RelayCommand<Book>(x => { });

        // Vous pouvez aussi utiliser cette forme pour définir une commande. La ligne du dessus fait strictement la même chose, choisissez une des 2 formes
        [RelayCommand]
        public void ReadBook(Book book)
        {
        }
    }
    public class InDesignDetailsBook : DetailsBook
    {
        public InDesignDetailsBook() : base(new Book() /*{ Title = "Test Book" }*/) { }
    }
}
