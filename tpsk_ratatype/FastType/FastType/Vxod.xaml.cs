using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Vxod.xaml
    /// </summary>
    public partial class Vxod : Page
    {
        public Vxod()
        {
            InitializeComponent();
        }

        private void REG_Click(object sender, RoutedEventArgs e)
        {
            if (UserName.Text.Length > 0)
            {
                if (Password.Password.Length > 0)
                {
                    //создаем пустую таблицу
                    //вызываем из квэрискюэль запрос
                    //метод возврорщаем в заполненую таблицу 
                    //заполненую таблицу присваеваем в пустую
                    //построчно осуществляем поиск пользователя по веденому имени и паролю
                    DataTable dtUser = QuerySql.SelectPassedUsers("SELECT Username, UserPassword FROM Users WHERE Username='"+UserName.Text+"' AND UserPassword='"+Password.Password+"'", UserName,Password );
                    if (dtUser.Rows.Count > 0)
                    {
                        MessageBox.Show("Пользователь авторизовался");
                        UserSession.GetUserInfo(UserName);
                        this.NavigationService.Navigate(new StartPage());
                    }
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите почту или имя пользователя");
        }
    }
}
