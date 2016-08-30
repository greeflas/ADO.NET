using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _06_SqlCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM dbo.Category";
            try
            {
                connect.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        Console.WriteLine("{0}\t{1}", 
                                //dr.GetInt32(0), dr.GetString(1)
                                dr[0], dr["CategoryName"]
                            );
                    }
                }
                else
                    Console.WriteLine("Table is empty!");
            }
            catch(Exception error)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[database]: {0}", error.Message);
                Console.ResetColor();
            }
            finally
            {
                if(connect.State != ConnectionState.Closed)
                    connect.Close();
            }
        }
    }
}
