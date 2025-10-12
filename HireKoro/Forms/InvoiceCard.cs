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
    public partial class InvoiceCard : UserControl
    {
        string invoiceID { get; set; }
        public InvoiceCard()
        {
            InitializeComponent();
        }

        public InvoiceCard(string invoiceID, string projectName, string currentStatus, DateTime issueDate, DateTime dueDate, float amount, bool showPayment): this()
        {
            this.invoiceID = invoiceID;
            if (showPayment)
            {
                lblInvoiceID.Text = "Invoice ID: " + invoiceID;
                lblProjectName.Text = "Project Name: " + projectName;
                lblCurrentStatus.Text = "Current Status: " + currentStatus;
                lblIssueDate.Text = "Issue Date: " + issueDate.ToString("dd MMMM, yyyy");
                lblDueDate.Text = "Due Date: " + dueDate.ToString("dd MMMM, yyyy");
                lblAmount.Text = "Amount: $" + amount.ToString("F2");
                if (currentStatus == "Paid")
                {
                    btnPayment.Text = "Paid";
                    btnPayment.FillColor = Color.FromArgb(0, 200, 83);
                    btnPayment.Enabled = false;
                }
                else if (currentStatus == "Pending")
                {
                    btnPayment.Text = "Pay Now";
                    btnPayment.FillColor = Color.FromArgb(255, 82, 82);
                    btnPayment.Enabled = true;
                }
                
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            
        }
    }
}
