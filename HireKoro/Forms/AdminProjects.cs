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

        internal void Clearall()
        {
            this.txtProjectID.Clear();
            this.txtClientID.Clear();
            this.txtFreelancerID.Clear();
            this.txtStatus.Clear();
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
            this.txtClientID.Text = this.dgvProjects.CurrentRow.Cells["ClientID"].Value.ToString();
            this.txtFreelancerID.Text = this.dgvProjects.CurrentRow.Cells["FreelancerID"].Value.ToString();
            this.txtStatus.Text = this.dgvProjects.CurrentRow.Cells["ProjectStatus"].Value.ToString();
            this.txtTitle.Text = this.dgvProjects.CurrentRow.Cells["Title"].Value.ToString();
            this.txtDescription.Text = this.dgvProjects.CurrentRow.Cells["ProjectDescription"].Value.ToString();
            this.txtHours.Text = this.dgvProjects.CurrentRow.Cells["ProjectHours"].Value.ToString();
            this.txtCost.Text = this.dgvProjects.CurrentRow.Cells["Cost"].Value.ToString();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.txtProjectID.Text = this.dgvProjects.CurrentRow.Cells["ProjectID"].Value.ToString();
            try
            {
                string query = $"DELETE FROM PROJECTS WHERE ProjectID = {this.txtProjectID.Text};";
                var response = Main.DB.ExecuteDMLQuery(query);
                dgvProjects.DataSource = response;
                this.LoadProjects();
                MessageBox.Show("Project deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting projects: " + ex.Message);
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
                string query = $@"INSERT INTO PROJECTS (ClientID, FreelancerID, Title, ProjectDescription, 
                                 ProjectStatus, ProjectHours, StartDate, Cost) 
                                 VALUES ({txtClientID.Text}, {txtFreelancerID.Text}, '{txtTitle.Text}', 
                                 '{txtDescription.Text}', '{txtStatus.Text}', {txtHours.Text}, 
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
                                 ClientID = {txtClientID.Text},
                                 FreelancerID = {txtFreelancerID.Text},
                                 Title = '{txtTitle.Text}',
                                 ProjectDescription = '{txtDescription.Text}',
                                 ProjectStatus = '{txtStatus.Text}',
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

