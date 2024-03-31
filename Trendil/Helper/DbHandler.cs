using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Trendil.Helper
{
    public class DbHandler
    {
        private static MySqlConnection connection;
        private static string server;
        private static string database;
        private static string username;
        private static string password;
        private static string connectionString;
       
        public static void ConnectionSet()
        {
            server = "p3nlmysql109plsk.secureserver.net";  //Server Host
            database = "TendrilDB";   //Database Name
            username = "Tendril";     //MySQL Server User Name
            password = "Tendril456123";     //MySQL Server Password
            connectionString = "SERVER=" + server + ";Port=3306;" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
        }
        public static DataTable Get(string sql)
        {
            
            connection = new MySqlConnection(connectionString);
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Open();
                DataTable table = new DataTable();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                table.Load(rdr);
                connection.Close();

                return table;
            }
            catch (MySqlException ex)
            {
                connection.Close();
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                
            }
            return null;
        }

        public static bool NonExcute(string sql)
        {
            connection = new MySqlConnection(connectionString);
            bool isSuccess = false;
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Open();
                DataTable table = new DataTable();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                isSuccess = true;
            }
            catch (MySqlException ex)
            {
                connection.Close();
                isSuccess = false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                
            }
            return isSuccess;
        }
    }

}