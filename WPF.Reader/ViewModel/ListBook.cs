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
        public ICommand FirstBooks { get; set; }
        public ICommand LastBooks { get; set; }

        public int Offset { get; set; } = 1;
        public int Limit { get; set; } = 2;
        public int End { get; set; } = 1;
        public int NbBooks { get; set; } = 0;
        public bool PreviousIsEnabled { get; set; } = true;
        public bool NextIsEnabled { get; set; } = true;
        public bool FirstIsEnabled { get; set; } = true;
        public bool LastIsEnabled { get; set; } = true;

        public void IncreaseOffset() 
        {
            if (Offset + Limit <= NbBooks)
            {
                Offset += Limit;
            }
        }
        public void DecreaseOffset()
        {
            if (Offset - Limit>0) 
            {
                Offset -= Limit;
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
        public void EnabledButton()
        {
            if (Offset - Limit < 0)
            {
                PreviousIsEnabled = false;
                FirstIsEnabled = false;
            }
            else
            {
                PreviousIsEnabled = true;
                FirstIsEnabled = true;
            }
            if (Offset + Limit > NbBooks)
            {
                NextIsEnabled = false;
                LastIsEnabled = false;
            }
            else
            {
                NextIsEnabled = true;
                LastIsEnabled = true;
            }
        }
        public void RunSearchAllBooks()
        {
            CombienAffiches();
            Task.Run(() =>
            {
                Ioc.Default.GetRequiredService<LibraryService>().SearchAllBooks(Offset, Limit);
            });
            EnabledButton();
        }

        public void CountBooks() { NbBooks = Ioc.Default.GetRequiredService<LibraryService>().CounthAllBooks(); }
        public ObservableCollection<Book> AllBooks => Ioc.Default.GetRequiredService<LibraryService>().Books;
        public ObservableCollection<Book> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;
        public ListBook()
        {
            CountBooks();
            RunSearchAllBooks();
            PreviousBooks = new RelayCommand(x => {
                DecreaseOffset();
                RunSearchAllBooks();
            });
            NextBooks = new RelayCommand(x => {
                IncreaseOffset();
                RunSearchAllBooks();
            });
            FirstBooks = new RelayCommand(x => {
                Offset=1;
                RunSearchAllBooks();
            });
            LastBooks = new RelayCommand(x => {
                Offset= NbBooks-Limit+1;
                RunSearchAllBooks();
            });
        }
    }
}