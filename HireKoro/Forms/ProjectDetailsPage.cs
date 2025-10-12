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
    public partial class ProjectDetailsPage : UserControl
    {
        string projectId { get; set; }
        string title { get; set; }
        string status { get; set; }
        string description { get; set; }
        DateTime startDate { get; set; }
        float hours { get; set; }
        float cost { get; set; }
        public ProjectDetailsPage(string id)
        {
            InitializeComponent();
            this.projectId = id;
            this.loadProject(id);
        }
        internal void loadProject(string projectId)
        {
            try
            {
                string query = $"SELECT * FROM Projects WHERE ProjectID = {projectId}";
                var response = Main.DB.ExecuteQueryTable(query);
                if (response != null)
                {
                    txtProjectName.Text = response.Rows[0]["title"].ToString();
                    cmbStatus.Text = response.Rows[0]["ProjectStatus"].ToString();
                    txtProjectDescription.Text = response.Rows[0]["ProjectDescription"].ToString();
                    dtpStartDate.Value = DateTime.Parse(response.Rows[0]["StartDate"].ToString());
                    txtCost.Text = response.Rows[0]["cost"].ToString();
                    txtHours.Text = response.Rows[0]["ProjectHours"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.title = txtProjectName.Text;
            this.description = txtProjectDescription.Text;
            this.hours = float.Parse(txtHours.Text);
            this.status = cmbStatus.Text;
            this.startDate = dtpStartDate.Value;
            this.cost = float.Parse(txtCost.Text);
            try
            {

                string query = $@"UPDATE PROJECTS SET 
                                 Title = '{this.title}',
                                 ProjectDescription = '{this.description}',
                                 ProjectStatus = '{this.status}',
                                 ProjectHours = {this.hours},
                                 Cost = {this.cost}
                                 WHERE ProjectID = {this.projectId}";
                var response = Main.DB.ExecuteDMLQuery(query);
                if (response > 0)
                {
                    MessageBox.Show("Project Updated Successfully!");
                    loadProject(this.projectId);
                }
                else
                {
                    MessageBox.Show("Failed to update project.");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this project?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string query = $"DELETE FROM PROJECTS WHERE ProjectID = {this.projectId}";
                    var response = Main.DB.ExecuteDMLQuery(query);
                    if (response > 0)
                    {
                        MessageBox.Show("Project Deleted Successfully!");
                        Main.MyProjectPage = new MyProjects();
                        Main.ChangeWindow(Main.MyProjectPage);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete project.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
