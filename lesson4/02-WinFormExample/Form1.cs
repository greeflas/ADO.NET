using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _02_WinFormExample
{
    public partial class Form1 : Form
    {
        string connectionStr;
        SqlConnection connect;

        SqlDataAdapter adapter;
        SqlCommandBuilder builder;
        DataTable Category;

        public Form1()
        {
            InitializeComponent();

            connectionStr = ConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            connect = new SqlConnection(connectionStr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM dbo.Category", connect);
            adapter.RowUpdated += Adapter_RowUpdated;

            builder = new SqlCommandBuilder(adapter);

            adapter.DeleteCommand = builder.GetDeleteCommand();
            adapter.InsertCommand = builder.GetInsertCommand();
            adapter.UpdateCommand = builder.GetUpdateCommand(true);

            Category = new DataTable("Category");
            adapter.Fill(Category);

            dataGridViewCategory.DataSource = Category;
        }

        private void Adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if(e.Errors == null && e.StatementType == StatementType.Insert)
            {
                // IDENT_CURRENT('table_name') --all sessions
                // SCOPE_IDENTITY() --current session
                string query = "SELECT CategoryId FROM dbo.Category WHERE CategoryId = IDENT_CURRENT('dbo.Category')";
                SqlCommand cmd = new SqlCommand(query, connect);

                if(connect.State != ConnectionState.Open)
                    connect.Open();

                int id = (int)cmd.ExecuteScalar();

                e.Row["CategoryId"] = id;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            adapter.Update(Category);
            MessageBox.Show("Change saved!", "Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
