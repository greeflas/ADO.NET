using System;
using System.Data;

namespace _02_DataTableFromType
{
    class Person
    {
        int id;
        string first_name;
        string last_name;
        DateTime birth_date;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return first_name; }
            set { first_name = value; }
        }

        public string LastName
        {
            get { return last_name; }
            set { last_name = value; }
        }

        public DateTime Birth_date
        {
            get { return birth_date; }
            set { birth_date = value; }
        }

        public static DataTable createIdentity()
        {
            // Create table with fields
            DataTable person = new DataTable("person");

            DataColumn id = new DataColumn("id", typeof(int));
            id.Caption = "Peson id";
            id.ReadOnly = true;
            id.AllowDBNull = false;
            id.Unique = true;
            id.AutoIncrement = true;
            id.AutoIncrementStep = 1;
            id.AutoIncrementSeed = 1;

            DataColumn FirstName = new DataColumn("first_name", typeof(string));
            FirstName.MaxLength = 255;

            DataColumn LastName = new DataColumn("last_name", typeof(string));
            LastName.MaxLength = 255;

            DataColumn BirthDate = new DataColumn("birth_date", typeof(DateTime));

            person.Columns.AddRange(new DataColumn[] { id, FirstName, LastName, BirthDate });

            return person;
        }
    }
}
