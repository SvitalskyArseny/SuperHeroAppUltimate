using SuperHero.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using SuperHeroProject.domain.model.custom;

namespace SuperHero.ViewModels
{
    class CustomsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CustomHero> customHeroes;
        public ObservableCollection<CustomHero> CustomHeroes
        {
            get { return customHeroes; }
            set
            {
                customHeroes = value;
                OnPropertyChanged("CustomHeroes");
            }
        }

        private CustomHero selectedHero;
        public CustomHero SelectedHero
        {
            get { return selectedHero; }
            set
            {
                selectedHero = value;
                OnPropertyChanged("SelectedHero");
            }
        }

        public CustomsViewModel()
        {
            ReloadCustomHeroesList();
        }

        #region Команды
        private RelayCommand openHeroCreationWindow;
        public RelayCommand OpenHeroCreationWindow
        {
            get
            {
                return openHeroCreationWindow ?? new RelayCommand(obj =>
                {
                    if (new AddCustomHeroWindow().ShowDialog() == true)
                        ReloadCustomHeroesList();
                }
                    );
            }
        }

        private RelayCommand openPublicPlatform;
        public RelayCommand OpenPublicPlatform
        {
            get
            {
                return openPublicPlatform ?? new RelayCommand(obj =>
                { ShowPublicPlatformWindow(); }
                    );
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

        private RelayCommand deleteCustomHero;
        public RelayCommand DeleteCustomHero
        {
            get
            {
                return deleteCustomHero ?? new RelayCommand(obj =>
                { DeleteCustomHeroMethod(); },
                 obj => SelectedHero is not null);
            }
        }
        #endregion

        private void ShowMainWindow()
        {
            foreach (Window w in Application.Current.Windows)
                if (w.Name == "Customs")
                    w.Close();
        }

        private void ShowPublicPlatformWindow()
        {
            var newWindow = new PublicPlatformWindow();
            newWindow.Owner = Application.Current.MainWindow;
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newWindow.WindowState = Application.Current.MainWindow.WindowState;
            newWindow.Height = Application.Current.MainWindow.Height;
            newWindow.Width = Application.Current.MainWindow.Width;
            
            foreach (Window w in Application.Current.Windows)
                if (w.Name == "Customs")
                    w.Hide();
            newWindow.ShowDialog();
            foreach (Window w in Application.Current.Windows)
                if (w.Name == "Customs")
                    w.Show();
        }

        private void DeleteCustomHeroMethod()
        {
            var delResult = StandartVM.customsService.DeleteCustomHeroById(SelectedHero.Id);
            StandartVM.publicPlatformService.DeleteHeroFromPlatform(SelectedHero.Id);
            if (delResult.Failure)
                StandartVM.ShowNetworkException("Не удалось удалить героя");
            else
                CustomHeroes.Remove(SelectedHero);
        }

        private void ReloadCustomHeroesList()
        {
            var heroesResult = StandartVM.customsService.GetAllCustomHeroes();
            if (heroesResult.Failure)
                StandartVM.ShowNetworkException("Не удалось получить список кастомных героев");
            else
                CustomHeroes = new ObservableCollection<CustomHero>(heroesResult.Value) ;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
