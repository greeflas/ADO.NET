using System;
using System.Data.SqlClient;
using System.Data;

namespace SqlConnectionStringBuilderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = "localhost";
            sb.InitialCatalog = "ShopAdo";
            sb.IntegratedSecurity = false;
            sb.UserID = "sa";
            sb.Password = "student";

            SqlConnection connection = new SqlConnection(sb.ToString());

            try
            {
                connection.Open();
                Console.WriteLine("Success!");
            }
            catch (Exception error)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[database]: {0}", error.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
