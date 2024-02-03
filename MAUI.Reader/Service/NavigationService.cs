using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUI.Reader;
using MAUI.Reader.Model;

namespace MAUI.Reader.Service
{
    public interface INavigationService
    {
        bool CanGoBack { get; }
        void GoBack();
        void Navigate<T>(params object[] args);
    }
    /// <summary>
    /// Aucune raison de toucher a autre chose que <see cref="viewMapping"/> dans cette classe, elle permet de gérer la navigation
    /// </summary>
    public class NavigationService() : INavigationService
    {
        /// <summary>
        /// Vous pouvez rajouter des correspondances ViewModel <-> View ici si vous souhaitez rajouter des pages
        /// </summary>
        private readonly Dictionary<Type, Type> viewMapping = new()
        {
            [typeof(ViewModel.ListBooks)] = typeof(Pages.ListBooks),
            [typeof(ViewModel.ReadBook)] = typeof(Pages.ReadBook),
            [typeof(ViewModel.DetailsBook)] = typeof(Pages.DetailsBook)
        };

        public bool CanGoBack => App.Current?.MainPage?.Navigation.NavigationStack.Count > 0;

        public async void GoBack() => await App.Current.MainPage.Navigation.PopAsync();

        /// <summary>
        /// Permet de changer la page afficher par la <see cref="Frame"/>
        /// </summary>
        /// <typeparam name="T">Le type du ViewModel a afficher</typeparam>
        /// <param name="args">les paramètres pour instancier le ViewModel. /!\ votre ViewModel doit avoir un constructeur compatible avec vos paramètres</param>
        public async void Navigate<T>(params object[] args)
        {
            ContentPage p = Activator.CreateInstance(this.viewMapping[typeof(T)]) as ContentPage;
            p.BindingContext = Activator.CreateInstance(typeof(T), args);
            await App.Current.MainPage.Navigation.PushAsync(p);
        }
    }
}
