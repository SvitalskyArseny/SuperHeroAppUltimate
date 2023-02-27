using Ninject;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using SuperHeroProject;
using SuperHeroProject.domain.model.hero;
using SuperHeroProject.domain.services.interfaces;
using SuperHeroProject.domain.repositories.interfaces;

namespace SuperHero.ViewModels
{
    public static class StandartVM
    {
        public static StandardKernel container = new(new Program.MainModule());
        public static IHeroService apiService = container.Get<IHeroService>();
        public static IFavouritesService favouritesService = container.Get<IFavouritesService>();
        public static ICustomHeroService customsService = container.Get<ICustomHeroService>();
        public static IAuthService authorizationService = container.Get<IAuthService>();
        public static IUserRepository localUserDatabase = container.Get<IUserRepository>();

        public static void ShowNetworkException(string text)
        {
            MessageBox.Show($"Ой! {text}.\nПроверьте подключение к сети и повторите попытку.", 
                "Ошибка подключения",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public static void ShowAuthorizationException(string text)
        {
            MessageBox.Show($"Не удалось авторизоваться: \n{text}",
                "Ошибка авторизации",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }

        public static void ShowRegistrationException(string text)
        {
            MessageBox.Show($"Не удалось зарегистрироваться: \n{text}",
                "Ошибка авторизации",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }

        public static ObservableCollection<Hero> SearchHeroes(ObservableCollection<Hero> list, string searchExpr)
        {
            return new(list
                .Where(hero => hero.Name.ToLower().Contains(searchExpr.ToLower())));
        }
    }
}
