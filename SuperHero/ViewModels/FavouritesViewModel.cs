using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using SuperHeroProject.domain.model.hero;

namespace SuperHero.ViewModels
{
    class FavouritesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Hero> favouriteHeroes;
        public ObservableCollection<Hero> FavouriteHeroes
        {
            get { return favouriteHeroes; }
            set
            {
                favouriteHeroes = value;
                OnPropertyChanged("FavouriteHeroes");
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

        public FavouritesViewModel()
        {
            var list = StandartVM.favouritesService.GetAllHeroesFromFavourites();
            if (list.Success)
                FavouriteHeroes = new(list.Value);
            else
                StandartVM.ShowNetworkException("Не удалось получить список избранных героев");
        }

        #region Команды
        private RelayCommand deleteFromFavourites;
        public RelayCommand DeleteFromFavourites
        {
            get
            {
                return deleteFromFavourites ?? new RelayCommand(obj =>
                { DeleteFromFavouritesMethod(); },
                 obj => SelectedHero is not null);
            }
        }

        private RelayCommand backToMainWindow;
        public RelayCommand BackToMainWindow
        {
            get
            {
                return backToMainWindow ?? new RelayCommand(obj =>
                { ShowMainWindow(); }
                    );
            }
        }
        #endregion

        private void DeleteFromFavouritesMethod()
        {
            var delResult = StandartVM.favouritesService.DeleteHeroFromFavouritesById(SelectedHero.Id);
            if (delResult.Failure)
                StandartVM.ShowNetworkException("Не удалось удалить героя из избранного");
            else
                FavouriteHeroes.Remove(SelectedHero);
        }

        private void ShowMainWindow()
        {
            foreach (Window w in Application.Current.Windows)
                if (w.Name == "Favourites")
                    w.Close();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
