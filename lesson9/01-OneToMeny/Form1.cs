using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace _01_OneToMeny
{
    public partial class Form1 : Form
    {
        CustomerContext context = new CustomerContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var cust = context.Customers
                .Select(c => new {
                    c.CustomerId,
                    FullName = c.FirstName + " " + c.LastName
                })
                .ToList();
            
            cbCustomer.ValueMember = "CustomerId";
            cbCustomer.DisplayMember = "FullName";
            cbCustomer.DataSource = cust;
        }

        private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CustomerId = Convert.ToInt32(cbCustomer.SelectedValue);
            var orders = context.Orders
                        .Where(o => o.CustomerId == CustomerId)
                        .ToList();

            dgvCustomers.DataSource = orders;
        }
    }
}
