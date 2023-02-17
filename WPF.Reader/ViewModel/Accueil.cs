using CommunityToolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class Accueil : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Frame Frame => Ioc.Default.GetRequiredService<INavigationService>().Frame;

        public ICommand GoBack { get; init; } = new RelayCommand(x => { Ioc.Default.GetRequiredService<INavigationService>().Frame.GoBack(); });
        public ICommand GoToListOfBooks { get; init; } = new RelayCommand(x => {
            var service = Ioc.Default.GetRequiredService<INavigationService>();
            if (service.Frame.CanGoBack)
            {
                service.Frame.RemoveBackEntry();
                var entry = service.Frame.RemoveBackEntry();
                while (entry != null)
                {
                    entry = service.Frame.RemoveBackEntry();
                }
            }
            service.Navigate<ListBook>();
        });
        public ICommand GoToListOfGenres { get; init; } = new RelayCommand(x => {
            var service = Ioc.Default.GetRequiredService<INavigationService>();
            if (service.Frame.CanGoBack)
            {
                service.Frame.RemoveBackEntry();
                var entry = service.Frame.RemoveBackEntry();
                while (entry != null)
                {
                    entry = service.Frame.RemoveBackEntry();
                }
            }
            service.Navigate<ListGenre>();
        });

    }
}
