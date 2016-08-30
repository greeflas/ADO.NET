using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ConnectionConfigFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            SqlConnection connection =  new SqlConnection(connectionString);

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
