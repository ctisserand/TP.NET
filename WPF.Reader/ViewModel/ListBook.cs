using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WPF.Reader.Model;
using WPF.Reader.Service;
using System.Windows;
using System.Collections.Generic;
using Windows.Web.Http;
using System.Threading.Tasks;
using System;

namespace WPF.Reader.ViewModel
{
    public partial class ListBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [RelayCommand]
        public void ItemSelected(Book book)
        {
        }

        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!
        public ObservableCollection<Book> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;
    }
}
