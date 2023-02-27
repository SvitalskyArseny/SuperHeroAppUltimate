using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SuperHero.ViewModels
{
    class AddCustomViewModel : INotifyPropertyChanged
    {
        public Window ThisWindow { get; set; }

        #region Поля / свойства
        private string imagePath = "..\\..\\..\\icons\\emptyavatar.png";
        public string ImagePath 
        { 
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public string NameField { get; set; }
        public string BiographyField { get; set; }
        public bool IsPublicHero { get; set; }

        public string IntelligenceSlider { get; set; } = "0";
        public string SpeedSlider { get; set; } = "0";
        public string PowerSlider { get; set; } = "0";
        #endregion

        #region Команды
        private RelayCommand chooseFile;

        public RelayCommand ChooseFile
        {
            get
            {
                return chooseFile ?? new RelayCommand(obj =>
                { ShowFileDialog(); });
            }
        }

        private RelayCommand createHero;
        public RelayCommand CreateHero
        {
            get
            {
                return createHero ?? new RelayCommand(obj =>
                { CreateCustomHero(); }, 
                obj => NameField is not null 
                && NameField.Length != 0 
                && BiographyField is not null
                && BiographyField.Length != 0);
            }
        }
        #endregion

        private void ShowFileDialog()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".png",
                Filter = "Image Files(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
            };

            var dialogResult = dialog.ShowDialog();

            if (dialogResult == true)
                ImagePath = Path.GetFullPath(dialog.FileName);
            
        }

        private void CreateCustomHero()
        {
            var stream = new FileStream(Path.GetFullPath(ImagePath), FileMode.Open, FileAccess.Read);
            var creationResult = StandartVM.customsService.AddCustomHero(
                NameField,
                BiographyField,
                stream,
                new(int.Parse(IntelligenceSlider), int.Parse(SpeedSlider), int.Parse(PowerSlider)),
                IsPublicHero);
            if (creationResult.Failure)
                StandartVM.ShowNetworkException("Не удалось создать своего героя");
            else
                CloseCreationWindow();
        }

        private void CloseCreationWindow()
        {
            foreach (Window w in Application.Current.Windows)
                if (w.Name == "CustomHeroCreation")
                    w.DialogResult = true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
