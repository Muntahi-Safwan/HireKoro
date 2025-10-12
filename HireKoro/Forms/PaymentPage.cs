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
    public partial class PaymentPage : UserControl
    {
        public PaymentPage()
        {
            InitializeComponent();
        }

        public PaymentPage(string invoiceID, string projectName, DateTime issueDate, DateTime dueDate, float amount) : this()
        {
            lblInvoiceID.Text = "Invoice ID: " + invoiceID;
            lblProjectName.Text = "Project Name: " + projectName;
            lblIssueDate.Text = "Issue Date: " + issueDate.ToString("dd MMMM, yyyy");
            lblDueDate.Text = "Due Date: " + dueDate.ToString("dd MMMM, yyyy");
            lblAmount.Text = "Amount: $" + amount.ToString("F2");
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            string cardNumber = txtCardNumber.Text;
            string cardName = txtHolderName.Text;
            string expDate = txtExpiry.Text;
            string cvc = txtCVC.Text;
            // Basic validation
            if (string.IsNullOrWhiteSpace(cardNumber) || string.IsNullOrWhiteSpace(cardName) ||
                string.IsNullOrWhiteSpace(expDate) || string.IsNullOrWhiteSpace(cvc))
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string updateQuery = @"UPDATE INVOICES
                                       SET 
                                            Status = 'Paid',
                                            CardHolderName = @CardHolderName,
                                            CardNumber = @CardNumber,
                                            CardExpiry = @CardExpiry,
                                            CardCVC = @CardCVC
                                        WHERE InvoiceID = @InvoiceID";
                var response = Main.DB.ExecuteDMLQuery(updateQuery);
                if (response > 0)
                {
                    MessageBox.Show("Payment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Main.DB.ExecuteDMLQuery($"INSERT INTO PaymentLog (InvoiceID, Status, Comment) VALUES ({lblInvoiceID.Text}, 'Paid', 'Payment successfully processed for this invoice.');");
                    Main.MyInvoicesPage = new MyInvoices();
                    Main.ChangeWindow(Main.MyInvoicesPage);
                }
                else
                {
                    MessageBox.Show("Payment failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
