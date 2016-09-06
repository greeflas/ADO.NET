using System;
using System.Data;

namespace _01_DataColumn
{
    class Program
    {
        static void Main(string[] args)
        {
            // DataTable
            DataTable table = new DataTable("Test");

            table.Columns.Add("id", typeof(int));
            table.Columns.Add("name", typeof(string));

            // DataColumn
            DataColumn date = new DataColumn("date", typeof(DateTime));
            table.Columns.Add(date);

            foreach(DataColumn col in table.Columns)
            {
                Console.WriteLine("{0}, {1}", col.ColumnName, col.DataType);
            }

            // DataRow
            DataRow row = table.NewRow();

            row[0] = 1;
            row[1] = "yo yo yo";
            row["date"] = DateTime.Now;

            table.Rows.Add(row);

            foreach(DataRow r in table.Rows)
            {
                Console.WriteLine("\n{0}\n{1}\n{2:d}", r[0], r[1], r["date"]);
            }
        }
    }
}
