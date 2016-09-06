using System;
using System.Data;

namespace _02_DataTableFromType
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable identity = Person.createIdentity();

            // Person 1
            DataRow person1 = identity.NewRow();
            person1[1] = "Vasya";
            person1[2] = "Pupkin";
            person1[3] = new DateTime(2000, 3, 8);

            identity.Rows.Add(person1);

            // Person 2
            DataRow person2 = identity.NewRow();
            person2[1] = "Sveta";
            person2[2] = "Pupkina";
            person2[3] = new DateTime(1996, 7, 1);

            identity.Rows.Add(person2);

            foreach(DataRow row in identity.Rows)
            {
                Console.WriteLine("{0} {1}", row[1], row[2]);
            }
            Console.WriteLine();
        }
    }
}
