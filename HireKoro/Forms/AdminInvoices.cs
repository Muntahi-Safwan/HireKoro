using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HireKoro.Forms
{
    public partial class AdminInvoices : UserControl
    {
        public AdminInvoices()
        {
            InitializeComponent();
            this.LoadInvoices();
        }

        internal void LoadInvoices(string query = "select I.InvoiceID , P.Title , I.Status , I.Amount , I.IssueDate , I.DueDate  from INVOICES AS I , PROJECTS AS P WHERE I.ProjectID = P.ProjectID ")
        {
            try
            {
                var response = Main.DB.ExecuteQueryTable(query);
                dgvInvoices.DataSource = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading projects: " + ex.Message);
            }
        }
    }
}
