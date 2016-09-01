using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace _01_SqlCommand
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
            cmd.CommandText = "dbo.GetManufacturer";

            try
            {
                connect.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("id: {0} \nName: {1}\n", dr[0], dr[1]);
                    }
                }
                else
                    Console.WriteLine("Table is empty!");
            }
            catch(Exception error)
            {
                Console.WriteLine("[Database] {0}", error.Message);
            }
            finally
            {
                if(connect.State != ConnectionState.Closed)
                    connect.Close();
            }
        }
    }
}
