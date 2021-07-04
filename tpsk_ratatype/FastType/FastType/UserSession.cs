using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FastType
{
    internal static class UserSession
    {
        internal static int Userld { get; set; }
        internal static string Username { get; set; }
        internal static bool IsUserEnter = false;
        internal static void GetUserInfo(TextBox username)
        
        {
            IsUserEnter = true;
            Username = username.Text;

            SqlConnection connection = new SqlConnection("Data Source=SQL;Initial Catalog=FastTyap_ArapetianKiselev;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT UserId,Username FROM Users WHERE Username='"+Username+"'", connection); 
            SqlDataReader reader = cmd.ExecuteReader();
            //если одна или более строк
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Userld = reader.GetInt32(0);
                    
                }
            }
            connection.Close();
        }
    }

  
}
