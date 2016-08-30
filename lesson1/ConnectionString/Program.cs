using System;
using System.Data.SqlClient;
using System.Data;

namespace ConnectionString
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                @"Data source = localhost;
                Initial Catalog = ShopAdo;
                Integrated Security = false;
                user = sa;
                password = student;
                Connect Timeout = 15;";

            try
            {
                connection.Open();
                Console.WriteLine("Success!");
            }
            catch(Exception error)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[database]: {0}", error.Message);
            }
            finally
            {
                if(connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
