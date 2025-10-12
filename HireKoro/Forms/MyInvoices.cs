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
    public partial class MyInvoices : UserControl
    {
        public MyInvoices()
        {
            InitializeComponent();
            LoadInvoices();
        }

        internal void LoadInvoices()
        {
            string query = "";
            try
            {
                flpInvoices.Controls.Clear();
                if (Main.userRole == "Client")
                {
                    query = $@"SELECT 
                                i.InvoiceID,
                                p.ProjectName,
                                i.PaymentStatus AS CurrentStatus,
                                i.IssueDate,
                                i.DueDate,
                                i.Amount
                            FROM INVOICES i
                            JOIN PROJECTS p ON i.ProjectID = p.ProjectID
                            WHERE p.ClientID = {Main.CurrentUserId}";
                } else if(Main.userRole == "Freelancer")
                {
                    query = $@"SELECT 
                                i.InvoiceID,
                                p.ProjectName,
                                i.PaymentStatus AS CurrentStatus,
                                i.IssueDate,
                                i.DueDate,
                                i.Amount
                            FROM INVOICES i
                            JOIN PROJECTS p ON i.ProjectID = p.ProjectID
                            WHERE p.FreelancerID = {Main.CurrentUserId}";
                }

                var response = Main.DB.ExecuteQueryTable(query);
                int count = 0;
                while (count < response.Rows.Count)
                {
                    string invoiceID = response.Rows[count]["InvoiceID"].ToString();
                    string projectName = response.Rows[count]["ProjectName"].ToString();
                    string currentStatus = response.Rows[count]["CurrentStatus"].ToString();

                    DateTime issueDate = DateTime.Parse(response.Rows[count]["IssueDate"].ToString());
                    DateTime dueDate = DateTime.Parse(response.Rows[count]["DueDate"].ToString());
                    float amount = float.Parse(response.Rows[count]["Amount"].ToString());

                    InvoiceCard invoiceCard = new InvoiceCard(invoiceID, projectName, currentStatus, issueDate, dueDate, amount, true);

                    flpInvoices.Controls.Add(invoiceCard);
                    count++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading invoices: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
