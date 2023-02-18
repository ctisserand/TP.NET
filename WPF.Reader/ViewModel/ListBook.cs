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
        public ICommand PreviousBooks { get; set; }
        public ICommand NextBooks { get; set; }
        public int Offset { get; set; } = 1;
        public int Limit { get; set; } = 2;
        public int End { get; set; } = 1;
        public int NbBooks { get; set; } = 0;

        public void IncreaseOffset() 
        {
            if (Offset+Limit <= NbBooks)
            {
                Offset = Offset + Limit;
            }
        }
        public void DecreaseOffset()
        {
            if (Offset - Limit>0) 
            {
                Offset = Offset - Limit;
            }
            else
            {
                Offset = 1;
            }
        }
        public void CombienAffiches()
        {
            if (End <= NbBooks)
            {
                End = Offset + Limit - 1;
            }
            else
            {
                End = NbBooks;
            }
        }

        public void CountBooks() { NbBooks = Ioc.Default.GetRequiredService<LibraryService>().CounthAllBooks(); }
        public ObservableCollection<Book> AllBooks => Ioc.Default.GetRequiredService<LibraryService>().Books;
        public ObservableCollection<Book> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;
        public ListBook()
        {
            CountBooks();
            CombienAffiches();
            Task.Run(() =>
            {
                Ioc.Default.GetRequiredService<LibraryService>().SearchAllBooks(Offset,Limit);
            });
            PreviousBooks = new RelayCommand(o => {
                DecreaseOffset();
                CombienAffiches();
                Task.Run(() =>
                {
                    Ioc.Default.GetRequiredService<LibraryService>().SearchAllBooks(Offset, Limit);
                });
            });
            NextBooks = new RelayCommand(o => {
                IncreaseOffset();
                CombienAffiches();
                Task.Run(() =>
                {
                    Ioc.Default.GetRequiredService<LibraryService>().SearchAllBooks(Offset, Limit);
                });
            });

            ItemSelectedCommand = new RelayCommand(book => { 
                /* the livre devrais etre dans la variable book */ 
            });
        }
    }
}
