
using System.Data;
using System.Windows;

namespace FastType
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new StartPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Rating());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Testing());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Registrarion());
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Vxod());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (UserSession.IsUserEnter)
            {
                NonSignUser.Visibility = Visibility.Hidden;
                SignUser.Visibility = Visibility.Visible;
                UsernameTbl.Text = UserSession.Username;

            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Education());
        }
    }
       
}
