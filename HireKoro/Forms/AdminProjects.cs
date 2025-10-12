using System;
using System.Collections;
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
    public partial class AdminProjects : UserControl
    {
        public AdminProjects()
        {
            InitializeComponent();
            this.LoadProjects();
            this.load_Clientname();
            this.load_Freelancername();
        }

        internal void LoadProjects(string query = "SELECT P.ProjectID, P.Title, P.ProjectStatus, P.ProjectHours,  P.StartDate,  P.Cost,   P.ProjectDescription,  C.Name AS ClientName,  F.Name AS FreelancerName FROM PROJECTS P JOIN USERS C ON P.ClientID = C.UserID LEFT JOIN USERS F ON P.FreelancerID = F.UserID;")
        {
            try
            {
                var response = Main.DB.ExecuteQueryTable(query);
                dgvProjects.DataSource = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading projects: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = $"SELECT P.ProjectID, P.Title, P.ProjectStatus, P.ProjectHours,  P.StartDate,  P.Cost,   P.ProjectDescription,  C.Name AS ClientName,  F.Name AS FreelancerName FROM PROJECTS P JOIN USERS C ON P.ClientID = C.UserID LEFT JOIN USERS F ON P.FreelancerID = F.UserID where ProjectID like '{this.txtSearch.Text}%' or Title like '{this.txtSearch.Text}%';";
            this.LoadProjects(query);
        }

        private void load_Clientname(string query = "select * from USERS where UserID = '1';")
        {

            try
            {
                var DT = Main.DB.ExecuteQueryTable(query);
                this.cmbprojectn.DataSource = DT;
                this.cmbprojectn.DisplayMember = "Username";
                this.cmbprojectn.ValueMember = "UserTypeID";


            }
            catch (Exception ex) { MessageBox.Show($"ERROR {ex.Message}"); }
        }


        private void load_Freelancername(string query = "select * from USERS where UserTypeID = '2';")
        {

            try
            {
                var DT = Main.DB.ExecuteQueryTable(query);
                this.cmbProjectm.DataSource = DT;
                this.cmbProjectm.DisplayMember = "Username";
                this.cmbProjectm.ValueMember = "UserTypeID";


            }
            catch (Exception ex) { MessageBox.Show($"ERROR {ex.Message}"); }
        }





        internal void Clearall()
        {
            this.txtProjectID.Clear();
            this.cmbprojectn.SelectedIndex = -1;
            this.cmbProjectm.SelectedIndex = -1;
            this.cmbProjectL.SelectedIndex = -1;
            this.txtTitle.Clear();
            this.txtDescription.Clear();
            this.txtHours.Clear();
            this.txtCost.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clearall();
        }

        private void dgvProjects_DoubleClick(object sender, EventArgs e)
        {
            this.txtProjectID.Text = this.dgvProjects.CurrentRow.Cells["ProjectID"].Value.ToString();
            this.cmbprojectn.Text = this.dgvProjects.CurrentRow.Cells["ClientID"].Value.ToString();
            this.cmbProjectm.Text = this.dgvProjects.CurrentRow.Cells["FreelancerID"].Value.ToString();
            this.cmbProjectL.Text = this.dgvProjects.CurrentRow.Cells["ProjectStatus"].Value.ToString();
            this.txtTitle.Text = this.dgvProjects.CurrentRow.Cells["Title"].Value.ToString();
            this.txtDescription.Text = this.dgvProjects.CurrentRow.Cells["ProjectDescription"].Value.ToString();
            this.txtHours.Text = this.dgvProjects.CurrentRow.Cells["ProjectHours"].Value.ToString();
            this.txtCost.Text = this.dgvProjects.CurrentRow.Cells["Cost"].Value.ToString();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.txtProjectID.Text = this.dgvProjects.CurrentRow.Cells["ProjectID"].Value.ToString();
            if (MessageBox.Show("Are you sure you want to delete this project?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string query = $"DELETE FROM PROJECTS WHERE ProjectID = {this.txtProjectID.Text};";
                    var response = Main.DB.ExecuteDMLQuery(query);
                    dgvProjects.DataSource = response;
                    this.LoadProjects();
                    MessageBox.Show("Project deleted successfully!");
                    this.Clearall();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting projects: " + ex.Message);
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Check if ProjectID field has a value to determine create vs update mode
            bool isUpdateMode = !string.IsNullOrEmpty(txtProjectID.Text.Trim());
            
            if (isUpdateMode)
            {
                UpdateProject();
            }
            else
            {
                CreateProject();
            }
        }

        private void CreateProject()
        {
            try
            {
                string query = $@"INSERT INTO PROJECTS (ClientName, FreelancerName, Title, ProjectDescription, 
                                 ProjectStatus, ProjectHours, StartDate, Cost) 
                                 VALUES ({cmbprojectn.SelectedValue.ToString()}, {cmbProjectm.SelectedValue.ToString()}, '{txtTitle.Text}', 
                                 '{txtDescription.Text}', '{cmbProjectL.Text}', {txtHours.Text}, 
                                 '{DateTime.Now:yyyy-MM-dd}', {txtCost.Text})";
                
                Main.DB.ExecuteDMLQuery(query);
                MessageBox.Show("Project created successfully!");
                LoadProjects();
                Clearall();
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
                string query = $@"UPDATE PROJECTS SET 
                                 ClientID = {cmbprojectn.SelectedValue.ToString()},
                                 FreelancerID = {cmbProjectm.SelectedValue.ToString()},
                                 Title = '{txtTitle.Text}',
                                 ProjectDescription = '{txtDescription.Text}',
                                 ProjectStatus = '{cmbProjectL.Text}',
                                 ProjectHours = {txtHours.Text},
                                 Cost = {txtCost.Text}
                                 WHERE ProjectID = {txtProjectID.Text}";
                
                Main.DB.ExecuteDMLQuery(query);
                MessageBox.Show("Project updated successfully!");
                LoadProjects();
                Clearall(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating project: " + ex.Message);
            }
        }
    }
}

