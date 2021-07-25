using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF.Reader.ViewModel
{
    internal class NavigatorInstance : INotifyPropertyChanged
    {
        private void PageModel_StaticPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Instance)));
        }

        public Navigator Instance { get => Navigator.Instance; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    enum PageEnum
    {
        LIST,
        DETAIL,
        READ
    }
    class Navigator : INotifyPropertyChanged
    {
        private static readonly Navigator instance;
        public static Navigator Instance { get => instance; }
        public PageEnum CurrentPage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand GoBack { get; set; }
        public ICommand GoTo { get; set; }

        static Navigator()
        {
            instance = new Navigator();
        }
        public Navigator()
        {
            GoBack = new RelayCommand(x => CurrentPage = PageEnum.LIST);
            GoTo = new RelayCommand(x => { CurrentPage = Enum.Parse<PageEnum>((String)x); });
        }
    }
}
