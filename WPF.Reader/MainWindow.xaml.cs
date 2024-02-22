using System;
using System.Windows;

namespace WPF.Reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Naviguation vers la page ListBooks au démarrage pour afficher la liste des livres
            MainFrame.Navigate(new Uri("Pages/ListBooks.xaml", UriKind.Relative));

        }
    }
}
