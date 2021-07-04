using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FastType
    ///<summary>
    ///Представляет статический методы для
    ///реализации SQL-ЗАПРОСОВ
    ///</summary>

{
    static class QuerySql
    {
        internal static DataTable SelectPassedUsers(string selectCmd,TextBox email,PasswordBox pass)
        {
            SqlConnection connection = new SqlConnection("Data Source=SQL;Initial Catalog=FastTyap_ArapetianKiselev;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand(selectCmd, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           
            DataTable dt = new DataTable("Users");
            da.Fill(dt);
            
            return dt;

        }
        /// <summary>
    /// Регестрирует пользователей системы 
    /// </summary>
    /// <param name="insertQuery">SQL запрос на добавления данных</param>
    /// <param name="username">Ввод имени пользователя</param>
    /// <param name="Email">Ввод электроной почты пользователя</param>
    /// <param name="password">Ввод пароля пользователя</param>
        internal static void AddUser(string insertQuery, TextBox username, TextBox email, PasswordBox password )
        {
            // INSERT INTO
            //1.Создать и открыть подключение к БД
            SqlConnection connection = new SqlConnection("Data Source=SQL;Initial Catalog=FastTyap_ArapetianKiselev;Integrated Security=True");
            connection.Open();


            //2.Создать команду и добавить параметр
            SqlCommand cmd = new SqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@username",username.Text);
            cmd.Parameters.AddWithValue("@email", email.Text);
            cmd.Parameters.AddWithValue("@password", password.Password);
            //3.выполнить команду и закрыть подключение.
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Пользователь авторизировался");

        }
        /// <summary>
        /// Тест скорсоти печати
        /// </summary>
        /// <param name="insertCmd">SQL-запрос на добавление данных  </param>
        /// <param name="speed">Вывод скрости ввода</param>
        /// <param name="accuracy"> Вывод точности ввода</param>
        /// <param name="status">Вычисляем статус</param>

        internal static void AddUserTypingResult(string insertCmd, TextBlock speed, TextBlock accuracy,Enum status)
        {
            SqlConnection connection = new SqlConnection("Data Source=SQL;Initial Catalog=FastTyap_ArapetianKiselev;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand(insertCmd, connection);
            cmd.Parameters.AddWithValue("@userid",UserSession.Userld);
            cmd.Parameters.AddWithValue("@speed",speed.Text);
            cmd.Parameters.AddWithValue("@accuracy",accuracy.Text);
            cmd.Parameters.AddWithValue("@status",status);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
