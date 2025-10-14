using Guna.UI2.WinForms;
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
            this.load_ProjectName();
            
            


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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query =$"select I.InvoiceID , P.Title , I.Status , I.Amount , I.IssueDate , I.DueDate  from INVOICES AS I , PROJECTS AS P WHERE I.ProjectID = P.ProjectID and ( InvoiceID like '{this.txtSearch.Text}%' or Title like '{this.txtSearch.Text}%');";
            this.LoadInvoices(query);
        }

        internal void ClearALL()
        {
            this.txtInvoiceID.Clear();
            this.cmbprojectn.SelectedIndex = -1;
            this.cmbStatus.SelectedIndex = -1;
            this.txtAmount.Clear();
           

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearALL();
        }

        private void load_ProjectName(string query = "select  * from PROJECTS")
        {
         
            try
            {
                var DT = Main.DB.ExecuteQueryTable(query);
                this.cmbprojectn.DataSource = DT;
                this.cmbprojectn.DisplayMember = "Title";
                this.cmbprojectn.ValueMember = "ProjectID";
             

            }
            catch (Exception ex) { MessageBox.Show($"ERROR {ex.Message}"); }
        }

       

        

        private void cmbprojectn_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.txtInvoiceID.Text = this.dgvInvoices.CurrentRow.Cells["InvoiceID"].Value.ToString();
            if (MessageBox.Show("Are you sure you want to delete this project?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string query = $"DELETE FROM INVOICES WHERE InvoiceID = {this.txtInvoiceID.Text};";
                    var response = Main.DB.ExecuteDMLQuery(query);
                    dgvInvoices.DataSource = response;
                    this.LoadInvoices();
                    MessageBox.Show("Project deleted successfully!");
                    this.ClearALL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting projects: " + ex.Message);
                }
            }
        }














        private void CreateProject()
        {
            try
            {
                string query = $@"INSERT INTO INVOICES (ProjectID, Status, Amount, 
                                 IssueDate, DueDate) 
                                 VALUES ( '{cmbprojectn.SelectedValue.ToString()}', '{cmbStatus.Text}', 
                                 '{txtAmount.Text}', '{dptIssueDate.Value:yyyy-MM-dd}', '{dtpDueDate.Value:yyyy-MM-dd}')";

                Main.DB.ExecuteDMLQuery(query);
                MessageBox.Show("Project created successfully!");
                LoadInvoices();
                ClearALL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating project: " + ex.Message);
            }
        }

        private void UpdateProject()
        {
            try
            {
                string query = $@"UPDATE INVOICES SET 
                                
                                 ProjectID = '{cmbprojectn.SelectedValue.ToString()}',
                                 Status = '{cmbStatus.Text}',
                                 Amount = '{txtAmount.Text}',
                                 IssueDate = '{dptIssueDate.Value:yyyy-MM-dd}',
                                 DueDate = '{dtpDueDate.Value:yyyy-MM-dd}'
                                 WHERE InoviceID = {txtInvoiceID.Text}";

                Main.DB.ExecuteDMLQuery(query);
                MessageBox.Show("INVOICES updated successfully!");
                LoadInvoices();
                ClearALL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating project: " + ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool isUpdateMode = !string.IsNullOrEmpty(txtInvoiceID.Text.Trim());

            if (isUpdateMode)
            {
                UpdateProject();
            }
            else
            {
                CreateProject();
            }
        }

        private void cmbprojectn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==(char)Keys.Enter)
            {
                this.load_ProjectName($"select  * from PROJECTS where Title like '{this.cmbprojectn.Text}%'");

            }
        }

        private void cmbprojectn_TextChanged(object sender, EventArgs e)
        {
            if(this.cmbprojectn.Text == "")
            {
                this.load_ProjectName();
               
            }
        }

        private void dgvInvoices_DoubleClick(object sender, EventArgs e)
        {
            this.txtInvoiceID.Text = this.dgvInvoices.CurrentRow.Cells["InvoiceID"].Value.ToString();
            this.cmbStatus.Text = this.dgvInvoices.CurrentRow.Cells["Status"].Value.ToString();
            this.txtAmount.Text = this.dgvInvoices.CurrentRow.Cells["Amount"].Value.ToString();
            this.dptIssueDate.Text = this.dgvInvoices.CurrentRow.Cells["IssueDate"].Value.ToString();
            this.dtpDueDate.Text = this.dgvInvoices.CurrentRow.Cells["DueDate"].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
