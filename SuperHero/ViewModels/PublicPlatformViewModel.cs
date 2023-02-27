using SuperHeroProject.domain.model.market;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SuperHero.ViewModels
{
    class PublicPlatformViewModel : INotifyPropertyChanged
    {
        private PlatformHero selectedHero;
        public PlatformHero SelectedHero
        {
            get { return selectedHero; }
            set
            {
                selectedHero = value;
                dislikeMode = false;
                SelectedHeroLikesCount = $"{StandartVM.publicPlatformService.GetListOfLikedUsers(selectedHero.Hero.Id).Value.Count}";
                LikedUsersOfSelectedHero = new(StandartVM.publicPlatformService.GetListOfLikedUsers(selectedHero.Hero.Id).Value);
                if (LikedUsersOfSelectedHero.Contains(StandartVM.localUserDatabase.GetUser().UserName))
                    dislikeMode = true;
                OnPropertyChanged("SelectedHero");
            }
        }

        private string selectedHeroLikesCount;
        public string SelectedHeroLikesCount
        {
            get { return selectedHeroLikesCount; }
            set
            {
                selectedHeroLikesCount = value;
                OnPropertyChanged("SelectedHeroLikesCount");
            }
        }

        private bool dislikeMode;

        private ObservableCollection<PlatformHero> heroes;
        public ObservableCollection<PlatformHero> Heroes
        {
            get { return heroes; }
            set
            {
                heroes = value;
                OnPropertyChanged("Heroes");
            }
        }

        private ObservableCollection<string> likedUsersOfSelectedHero;
        public ObservableCollection<string> LikedUsersOfSelectedHero
        {
            get { return likedUsersOfSelectedHero; }
            set 
            {
                likedUsersOfSelectedHero = value;
                OnPropertyChanged("LikedUsersOfSelectedHero");
            }
        }


        private string selectedUserName;
        public string SelectedUserName
        {
            get { return selectedUserName; }
            set
            {
                selectedUserName = value;
                OnPropertyChanged("SelectedUserName");
            }
        }

        public string UserNameField { get; set; }

        private RelayCommand search;
        public RelayCommand Search
        {
            get
            {
                return search ?? new RelayCommand(obj =>
                { TrySearchUserName(); });
            }
        }


        private RelayCommand like;
        public RelayCommand Like
        {
            get
            {
                return like ?? new RelayCommand(obj =>
                { LikeOrDislikeHero(true); },
                 obj => SelectedHero is not null && !dislikeMode);
            }
        }

        private RelayCommand dislike;
        public RelayCommand Dislike
        {
            get
            {
                return dislike ?? new RelayCommand(obj =>
                { LikeOrDislikeHero(false); },
                 obj => SelectedHero is not null && dislikeMode);
            }
        }


        private RelayCommand backToLastWindow;
        public RelayCommand BackToLastWindow
        {
            get
            {
                return backToLastWindow ?? new RelayCommand(obj =>
                { ShowLastWindow(); }
                    );
            }
        }

        private void ShowLastWindow()
        {
            foreach (Window w in Application.Current.Windows)
                if (w.Name == "Platform")
                    w.Close();
        }

        private void LikeOrDislikeHero(bool like)
        {
            var likeResult = StandartVM.publicPlatformService.SetLikeHero(like, SelectedHero.Hero.Id);
            if (likeResult.Failure)
                MessageBox.Show(likeResult.ErrorMessage, "Ой! Что-то не так", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                dislikeMode = like;
                LikedUsersOfSelectedHero = new(StandartVM.publicPlatformService.GetListOfLikedUsers(selectedHero.Hero.Id).Value);
                SelectedHeroLikesCount = $"{StandartVM.publicPlatformService.GetListOfLikedUsers(selectedHero.Hero.Id).Value.Count}";
            }
        }

        private void TrySearchUserName()
        {
            var searchingResult = StandartVM.publicPlatformService.GetAllHeroesByUserName(UserNameField);
            if (searchingResult.Failure)
                MessageBox.Show(searchingResult.ErrorMessage, "Ой! Что-то не так", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                Heroes = new(searchingResult.Value);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
