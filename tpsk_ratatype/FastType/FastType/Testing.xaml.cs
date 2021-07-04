using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastType
{
    /// <summary>
    /// Логика взаимодействия для Testing.xaml
    /// </summary>
    public partial class Testing : Page
    {
        public Testing()
        {
            InitializeComponent();
        }

        private void StartTyping_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartTesting_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StartTesting());
        }
    }
}
