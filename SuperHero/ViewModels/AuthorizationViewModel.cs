using SuperHeroUI;
using System.Windows;

namespace SuperHero.ViewModels
{
    class AuthorizationViewModel
    {
        public string LoginField { get; set; }
        public string PasswordField { get; set; }

        public AuthorizationViewModel()
        {
            if (StandartVM.localUserDatabase.isLogged())
                ShowMainWindow();
        }

        #region Команды
        private RelayCommand authorization;
        public RelayCommand Authorization
        {
            get
            {
                return authorization ?? new RelayCommand(obj =>
                { Authorize(); });
            }
        }

        private RelayCommand registration;
        public RelayCommand Registration
        {
            get
            {
                return registration ?? new RelayCommand(obj =>
                { Register(); });
            }
        }
        #endregion

        private void Register()
        {
            if (!IsLoginPasswordFieldsIsNull())
            {
                var registrationResult = StandartVM.authorizationService.RegisterUser(LoginField, PasswordField);
                if (registrationResult.Failure)
                    StandartVM.ShowRegistrationException(registrationResult.ErrorMessage);
                else
                    ShowMainWindow();
            }
        }

        private void Authorize()
        {
            if (!IsLoginPasswordFieldsIsNull())
            {
                var authorizationResult = StandartVM.authorizationService.LoginUser(LoginField, PasswordField);
                if (authorizationResult.Failure)
                    StandartVM.ShowAuthorizationException(authorizationResult.ErrorMessage);
                else
                    ShowMainWindow();
            }
        }

        private bool IsLoginPasswordFieldsIsNull()
        {
            if (LoginField is null || PasswordField is null)
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми!");
                return true;
            }
            return false;
        }

        private void ShowMainWindow()
        {
            var mainWindow = new MainWindow();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}
