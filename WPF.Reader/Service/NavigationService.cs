using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using WPF.Reader;

namespace WPF.Reader.Service
{
    public interface INavigationService
    {
        bool CanGoBack { get; }
        void GoBack();
        void Navigate<T>(params object[] args);
        public Frame Frame { get; }
    }
    /// <summary>
    /// Aucune raison de toucher a autre chose que <see cref="viewMapping"/> dans cette classe, elle permet de gérer la navigation
    /// </summary>
    public class NavigationService(Frame frame) : INavigationService
    {
        /// <summary>
        /// Vous pouvez rajouter des correspondances ViewModel <-> View ici si vous souhaitez rajouter des pages
        /// </summary>
        private readonly Dictionary<Type, Type> viewMapping = new()
        {
            [typeof(ViewModel.ListBook)] = typeof(Pages.ListBooks),
            [typeof(ViewModel.ReadBook)] = typeof(Pages.ReadBook),
            [typeof(ViewModel.DetailsBook)] = typeof(Pages.DetailsBook)
        };

        public Frame Frame { get; init; } = frame;

        public bool CanGoBack => Frame.CanGoBack;

        public void GoBack() => Frame.GoBack();

        /// <summary>
        /// Permet de changer la page afficher par la <see cref="Frame"/>
        /// </summary>
        /// <typeparam name="T">Le type du ViewModel a afficher</typeparam>
        /// <param name="args">les paramètres pour instancier le ViewModel. /!\ votre ViewModel doit avoir un constructeur compatible avec vos paramètres</param>
        public void Navigate<T>(params object[] args)
        {
            Page p = Activator.CreateInstance(this.viewMapping[typeof(T)]) as Page;
            p.DataContext = Activator.CreateInstance(typeof(T), args);
            Frame.Navigate(p);
        }
    }
}
