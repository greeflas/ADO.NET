using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _03_DataTableFromDb
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionStr);

            SqlCommand cmd = new SqlCommand("SELECT * FROM Manufacturer", connect);
            DataTable Manufacturer = new DataTable("Manufacturer");

            try
            {
                connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Manufacturer.Columns.Add( new DataColumn(reader.GetName(i), reader.GetFieldType(i)) );
                }

                while (reader.Read())
                {
                    DataRow row = Manufacturer.NewRow();

                    for (int i = 0; i < reader.FieldCount; i++)
                        row[i] = reader[i];

                    Manufacturer.Rows.Add(row);
                }
            }
            catch (Exception error)
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

            foreach (DataRow row in Manufacturer.Rows)
            {
                Console.WriteLine("{0}\n{1}", row[0], row[1]);
                Console.WriteLine();
            }
        }
    }
}
