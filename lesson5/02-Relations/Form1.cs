using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _02_Relations
{
    public partial class Form1 : Form
    {
        string connectionStr;
        SqlConnection connect;
            
        DataSet ds;
        DataTable RegionTable, CityTable;
        SqlDataAdapter RegionAdapter, CityAdapter;
        BindingSource bsRegion, bsCity;

        void InitSchema()
        {
            ds = new DataSet();

            RegionTable = new DataTable("Region");
            CityTable = new DataTable("City");

            bsRegion = new BindingSource();
            bsCity = new BindingSource();

            const string SELECT_REGIONS = "SELECT * FROM dbo.Region";
            RegionAdapter = new SqlDataAdapter(SELECT_REGIONS, connect);
            RegionAdapter.FillSchema(RegionTable, SchemaType.Mapped);

            SqlCommandBuilder RegionCmd = new SqlCommandBuilder(RegionAdapter);
            RegionAdapter.InsertCommand = RegionCmd.GetInsertCommand();
            RegionAdapter.UpdateCommand = RegionCmd.GetUpdateCommand();
            RegionAdapter.DeleteCommand = RegionCmd.GetDeleteCommand();

            const string SELECT_CITY = "SELECT * FROM dbo.City";
            CityAdapter = new SqlDataAdapter(SELECT_CITY, connect);
            CityAdapter.FillSchema(CityTable, SchemaType.Mapped);

            SqlCommandBuilder CityCmd = new SqlCommandBuilder(CityAdapter);
            RegionAdapter.InsertCommand = CityCmd.GetInsertCommand();
            RegionAdapter.UpdateCommand = CityCmd.GetUpdateCommand();
            RegionAdapter.DeleteCommand = CityCmd.GetDeleteCommand();

            ds.Tables.Add(RegionTable);
            ds.Tables.Add(CityTable);

            DataRelation relation = new DataRelation("RegionCity", 
                ds.Tables[0].Columns["RegionId"],
                ds.Tables[1].Columns["RegionId"]);

            ForeignKeyConstraint FK = new ForeignKeyConstraint("RegionCity-FK",
                ds.Tables[0].Columns["RegionId"],
                ds.Tables[1].Columns["RegionId"]);
            FK.DeleteRule = Rule.Cascade;
            FK.UpdateRule = Rule.Cascade;
            ds.Tables[1].Constraints.Add(FK);
            ds.EnforceConstraints = true;
            ds.Relations.Add(relation);

            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["RegionId"] };
            ds.Tables[0].Columns["RegionId"].AutoIncrement = true;
            ds.Tables[0].Columns["RegionId"].Unique = true;
            ds.Tables[0].Columns["RegionId"].AutoIncrementStep = -1;
            ds.Tables[0].Columns["RegionId"].AutoIncrementSeed = -1;

            ds.Tables[1].PrimaryKey = new DataColumn[] { ds.Tables[1].Columns["CityId"] };
            ds.Tables[1].Columns["CityId"].AutoIncrement = true;
            ds.Tables[1].Columns["CityId"].Unique = true;
            ds.Tables[1].Columns["CityId"].AutoIncrementStep = -1;
            ds.Tables[1].Columns["CityId"].AutoIncrementSeed = -1;
        }

        void FormBinding()
        {
            bsRegion.DataSource = ds;
            bsRegion.DataMember = "Region";
            dataGridViewRegions.DataSource = bsRegion;

            bsCity.DataSource = bsRegion;
            bsCity.DataMember = "RegionCity";
            dataGridViewCities.DataSource = bsCity;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitSchema();
            RegionAdapter.Fill(RegionTable);
            CityAdapter.Fill(CityTable);
            FormBinding();
        }

        public Form1()
        {
            InitializeComponent();

            connectionStr = ConfigurationManager.ConnectionStrings["region"].ConnectionString;
            connect = new SqlConnection(connectionStr);
        }
    }
}
