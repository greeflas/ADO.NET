using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _01_DataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["region"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionStr);

            DataSet ds = new DataSet();

            const string SELECT_REGIONS = "SELECT * FROM dbo.Region;";
            const string SELECT_CITIES = "SELECT * FROM dbo.City;";
            SqlDataAdapter adapter = new SqlDataAdapter(SELECT_REGIONS + SELECT_CITIES, connect);

            adapter.Fill(ds);

            int table_count = ds.Tables.Count;
            Console.WriteLine("Tables count: {0}", table_count);
            Console.WriteLine("Table name: {0}", ds.Tables[0].TableName);
            Console.WriteLine("Table name: {0}", ds.Tables[1].TableName);

            DataTable RegionTable = ds.Tables["Table"];
            Console.WriteLine();
            foreach (DataRow row in RegionTable.Rows)
                Console.WriteLine("id: {0} \nName: {1}\n", row[0], row[1]);

            DataTable CityTable = ds.Tables[1];
            Console.WriteLine();
            foreach (DataRow row in CityTable.Rows)
                Console.WriteLine("id: {0} \nName: {1}\n", row[0], row[2]);
        }
    }
}
