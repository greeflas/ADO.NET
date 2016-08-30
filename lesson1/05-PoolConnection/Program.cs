using System;
using System.Configuration;
using System.Data.SqlClient;

namespace _05_PoolConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connectionString);
            sb.MaxPoolSize = 5;

            // Pooling true
            sb.Pooling = true;
            SqlConnection connect = new SqlConnection(sb.ToString());
            DateTime start = DateTime.Now;
            for(uint i = 0; i < 1000; i++)
            {
                connect.Open();
                connect.Close();
            }
            TimeSpan finish = DateTime.Now - start;
            Console.WriteLine("Result: {0}", finish.Milliseconds);

            // Pooling false
            sb.Pooling = false;
            connect = new SqlConnection(sb.ToString());
            start = DateTime.Now;
            for (uint i = 0; i < 1000; i++)
            {
                connect.Open();
                connect.Close();
            }
            finish = DateTime.Now - start;
            Console.WriteLine("Result: {0}", finish.Milliseconds);
        }
    }
}
