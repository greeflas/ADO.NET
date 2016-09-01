using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _03_ExecuteScalar
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionStr);

            SqlCommand cmd = new SqlCommand(
//                "CREATE TABLE test_table (id INT IDENTITY PRIMARY KEY, name NVARCHAR(10))",
                  "SELECT COUNT(*) AS count FROM dbo.Manufacturer",
                  connect
            );

            try
            {
                connect.Open();

                //                cmd.ExecuteNonQuery();
                object o = cmd.ExecuteScalar();
                Console.WriteLine("Success!");
                Console.WriteLine("Count manufacturer: {0}", o);
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
