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
    /// Логика взаимодействия для Registrarion.xaml
    /// </summary>
    public partial class Registrarion : Page
    {
        public Registrarion()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QuerySql.AddUser("INSERT INTO Users(Username,UserEmail,UserPassword) VALUES (@username,@email,@password)", Username, Email, Password);

            NavigationService.Navigate(new Vxod());
        }
    }
}
