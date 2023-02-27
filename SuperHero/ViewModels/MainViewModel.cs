using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using SuperHero.Views;
using System.Windows;
using SuperHero;
using SuperHero.ViewModels;
using SuperHeroProject.domain.model.hero;

namespace SuperHeroUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<Hero> heroesCopy;

        private ObservableCollection<Hero> heroes;
        public ObservableCollection<Hero> Heroes
        {
            get { return heroes; }
            set
            {
                heroes = value;
                OnPropertyChanged("Heroes");
            }
        }
        
        private Hero selectedHero;
        public Hero SelectedHero
        {
            get { return selectedHero; }
            set
            {
                selectedHero = value;
                OnPropertyChanged("SelectedHero");
            }
        }

        private string searchExpression;
        public string SearchExpression
        {
            get { return searchExpression; }
            set
            {
                Heroes = StandartVM.SearchHeroes(heroesCopy, value);
                searchExpression = value;
                OnPropertyChanged("SearchExpression");
            }
        }

        public string CurrentUser { get; set; }

        public MainViewModel()
        {
            var heroes = StandartVM.apiService.GetAllHeroes();
            if (heroes.Failure)
                StandartVM.ShowNetworkException("Не удалось загрузить список всех героев");
            else
            {
                Heroes = new(heroes.Value);
                heroesCopy = new(heroes.Value);
            }
            CurrentUser = StandartVM.localUserDatabase.GetUser().UserName;
        }           

        #region Комнды
        private RelayCommand openFavouritesWindow;
        public RelayCommand OpenFavouritesWindow
        {
            get
            {
                return openFavouritesWindow ?? new RelayCommand(obj =>
                    { OpenWindowWithOwnerProperties(new FavouritesWindow()); });
            }
        }

        private RelayCommand openCustomHeroesWindow;
        public RelayCommand OpenCustomHeroesWindow
        {
            get
            {
                return openCustomHeroesWindow ?? new RelayCommand(obj =>
                    { OpenWindowWithOwnerProperties(new CustomHeroesWindow()); });
            }
        }

        private RelayCommand addToFavourites;
        public RelayCommand AddToFavourites
        {
            get
            {
                return addToFavourites ?? new RelayCommand(obj =>
                { AddToFavouritesMethod(selectedHero.Id); },
                 obj => SelectedHero is not null);
            }
        }

        private RelayCommand logoutAccaunt;
        public RelayCommand LogoutAccaunt
        {
            get
            {
                return logoutAccaunt ?? new RelayCommand(obj =>
                { LogoutAccauntMethod(); });
            }
        }
        #endregion

        private void LogoutAccauntMethod()
        {
            StandartVM.localUserDatabase.logOut();
            var test = StandartVM.localUserDatabase.GetUser();
            ShowAuthorizationWindow();
        }

        private void AddToFavouritesMethod(string id)
        {
            var addingResult = StandartVM.favouritesService.AddHeroToFavouritesById(id);
            if (addingResult.Failure)
                StandartVM.ShowNetworkException("Не удалось добавить героя в избранное");
        }

        private void OpenWindowWithOwnerProperties(Window newWindow)
        {
            newWindow.Owner = Application.Current.MainWindow;
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newWindow.WindowState = Application.Current.MainWindow.WindowState;
            newWindow.Height = Application.Current.MainWindow.Height;
            newWindow.Width = Application.Current.MainWindow.Width;
            Application.Current.MainWindow.Hide();
            newWindow.ShowDialog();
            Application.Current.MainWindow.Show();
        }

        private void ShowAuthorizationWindow()
        {
            var newWindow = new AuthorisationWindow();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
