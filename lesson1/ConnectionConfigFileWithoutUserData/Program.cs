using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ConnectionConfigFileWithoutUserData
{
    class Program
    {
        static void Main(string[] args)
        {
            string login = string.Empty;
            string password = string.Empty;

            Console.Write("Input login: ");
            login = Console.ReadLine();

            Console.Write("Input password: ");
            password = Console.ReadLine();

            string connectionString = ConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();

            SqlConnection connection = new SqlConnection(connectionString);

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
