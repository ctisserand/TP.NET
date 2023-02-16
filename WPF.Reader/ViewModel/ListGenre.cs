using CommunityToolkit.Mvvm.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Pages;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListGenre : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }

        public ObservableCollection<Genre> Genres => Ioc.Default.GetRequiredService<LibraryService>().Genres;
        public ObservableCollection<Book> BooksByGenre => Ioc.Default.GetRequiredService<LibraryService>().BooksByGenre;
        public ListGenre()
        {
            Task.Run(() =>
            {
                Ioc.Default.GetRequiredService<LibraryService>().UpdateGenre();
            });
            ItemSelectedCommand = new RelayCommand(genre =>
            {
                Task.Run(() =>
                {
                    Ioc.Default.GetRequiredService<LibraryService>().SearchBooksByGenre((Genre)genre);
                });
            });
        }
    }
}
