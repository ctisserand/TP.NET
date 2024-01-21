using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    /// <summary>
    /// Aucune raison de toucher a cette classe, mais vous pouvez par contre utilisé les propriété GoBack et GoToHome
    /// </summary>
    partial class Navigator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

#pragma warning disable CA1822
        public Frame Frame => Ioc.Default.GetRequiredService<INavigationService>().Frame;
        public bool IsHome() => Ioc.Default.GetRequiredService<INavigationService>().CanGoBack;
#pragma warning restore CA1822

        [RelayCommand(CanExecute = "IsHome")]
        public void GoBack() { Frame.GoBack(); }


        [RelayCommand(CanExecute = "IsHome")]
        public void GoToHome() {
            if (Frame.CanGoBack)
            {
                Frame.RemoveBackEntry();
                var entry = Frame.RemoveBackEntry();
                while (entry != null)
                {
                    entry = Frame.RemoveBackEntry();
                }
            }
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<ListBook>();
        }
    }
}
