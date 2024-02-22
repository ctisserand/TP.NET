using CommunityToolkit.Mvvm.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WPF.Reader.Service;
using WPF.Reader.ViewModel;

namespace WPF.Reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            // Naviguation vers la page ListBooks au démarrage pour afficher la liste des livres
            Ioc.Default.GetService<INavigationService>().Navigate<ListBook>();
        }
    }
}
