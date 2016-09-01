using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _02_CommandOutputParam
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionStr);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "dbo.InsertCategory";
            cmd.Parameters.AddWithValue("@CategoryName", "C#").Direction = 
                ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@CategoryId", 0).Direction =
                ParameterDirection.Output;

            try
            {
                connect.Open();

                int count = cmd.ExecuteNonQuery();
                Console.WriteLine("Count: {0}", count);
                Console.WriteLine("\nCategoryId: {0}", 
                    cmd.Parameters["@CategoryId"].Value);
            }
            catch(Exception error)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[database] {0}", error.Message);
                Console.ResetColor();
            }
            finally
            {
                if (connect.State != ConnectionState.Closed)
                    connect.Close();
            }
        }
    }
}
