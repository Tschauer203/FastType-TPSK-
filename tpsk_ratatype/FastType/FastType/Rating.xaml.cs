using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Rating.xaml
    /// </summary>
    public partial class Rating : Page
    {
        public Rating()
        {
            InitializeComponent();
            FillDataGrid();
        }

        void FillDataGrid()
        {
            // 1. Содать подключение 
            SqlConnection connection = new SqlConnection("Data Source=SQL;Initial Catalog=FastTyap_ArapetianKiselev;Integrated Security=True");
            // 2. Открыть подключение 
            connection.Open();
            // 3. Создать команду (SQL-запрос)
            SqlCommand selectCmd = new SqlCommand("SELECT *FROM View_2",connection);




            // 4. Создать Data Adapter(команда для подключение к БД + ДЛЯ 
            // заполнения таблицы)
            SqlDataAdapter sda = new SqlDataAdapter(selectCmd);
            // 5. Привести данные в табличный вид с помощью DataTable
            DataTable dt = new DataTable("Users");
            // 6. Заполнить таблицу и передать ее в DataGrid
            sda.Fill(dt);
            UserGrid.ItemsSource = dt.DefaultView;
            // 7. Закрыть подключение
            connection.Close();
        }

    }
}
