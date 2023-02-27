using SuperHero.ViewModels;
using System.Windows;

namespace SuperHero.Views
{
    /// <summary>
    /// Логика взаимодействия для PublicPlatformWindow.xaml
    /// </summary>
    public partial class PublicPlatformWindow : Window
    {
        public PublicPlatformWindow()
        {
            InitializeComponent();
            DataContext = new PublicPlatformViewModel();
        }
    }
}
