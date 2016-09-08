using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _01_DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionStr);

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.Category", connect);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            adapter.DeleteCommand = builder.GetDeleteCommand();
            adapter.InsertCommand = builder.GetInsertCommand();
            adapter.UpdateCommand = builder.GetUpdateCommand(true);

            Console.WriteLine("Delete - {0}\n", adapter.DeleteCommand.CommandText);
            Console.WriteLine("Insert - {0}\n", adapter.InsertCommand.CommandText);
            Console.WriteLine("Update - {0}\n", adapter.UpdateCommand.CommandText);

            DataTable Category = new DataTable("Category");
            adapter.Fill(Category);

            foreach (DataColumn col in Category.Columns)
                Console.Write("{0}\t", col.ColumnName);

            Console.WriteLine("\n----------------------------");

            foreach (DataRow row in Category.Rows)
                Console.WriteLine("{0}\t{1}", row[0], row[1]);
        }
    }
}
