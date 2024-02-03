using CommunityToolkit.Mvvm.DependencyInjection;
using MAUI.Reader.ViewModel;
using MAUI.Reader.Service;

namespace MAUI.Reader
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Si vous avez besoin de rajouter des services, vous pouvez le déclarer ici
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<INavigationService>(new NavigationService())
                .AddSingleton(new LibraryService())
                .BuildServiceProvider());

            MainPage = new AppShell();
        }
    }
}
