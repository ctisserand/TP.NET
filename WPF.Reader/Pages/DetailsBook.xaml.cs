using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Reader.Service;

namespace WPF.Reader.Pages
{
    public partial class DetailsBook : Page
    {
        //
        private readonly LibraryService _libraryService = new LibraryService();

        public DetailsBook()
        {
            InitializeComponent();
            //Ajout de la possibilité de loader des livres 
            Loaded += Page_Loaded;
            //this.DataContext = new ViewModel.DetailsBook();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Chargement des livres de manière asynchrone
            await _libraryService.FetchBooksAsync();

        }
    }
}
