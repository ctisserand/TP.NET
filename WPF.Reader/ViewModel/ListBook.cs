using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }


        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!
        public ObservableCollection<Book> Books => LibraryService.Instance.Books;

        public ListBook()
        {
            ItemSelectedCommand = new RelayCommand(obj =>
            {
                LibraryService.Instance.CurrentBook = obj as Book;
                Navigator.Instance.CurrentPage = PageEnum.DETAIL;
            });
        }
    }
}
