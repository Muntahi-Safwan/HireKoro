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
        public ProjectDetailsPage()
        {
            InitializeComponent();
        }
        internal void loadProject(string projectId)
        {
            try
            {
                string query = $"SELECT * FROM Projects WHERE id = {projectId}";
                var response = Main.DB.ExecuteQueryTable(query);
                if (response != null)
                {
                    txtProjectName.Text = response.Rows[0]["title"].ToString();
                    cmbStatus.Text = response.Rows[0]["ProjectStatus"].ToString();
                    txtProjectDescription.Text = response.Rows[0]["ProjectDescription"].ToString();
                    txtHours.Text = response.Rows[0]["hours"].ToString();
                    dtpStartDate.Value = DateTime.Parse(response.Rows[0]["StartDate"].ToString());
                    txtCost.Text = response.Rows[0]["cost"].ToString();
                    txtHours.Text = response.Rows[0]["hours"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        internal void LoadProjects(string id)
        {
            try
            {
                string query = $"Select * FROM PROJECTS WHERE FreelancerID={id}";
                var response = Main.DB.ExecuteQueryTable(query);
                int count = 0;
                while (count < response.Rows.Count)
                {
                    string projectId = response.Rows[count]["ProjectID"].ToString();
                    string title = response.Rows[count]["Title"].ToString();
                    string status = response.Rows[count]["ProjectStatus"].ToString();
                    string description = response.Rows[count]["ProjectDescription"].ToString();

                    DateTime startDate = DateTime.Parse(response.Rows[count]["StartDate"].ToString());
                    float hours = float.Parse(response.Rows[count]["ProjectHours"].ToString());
                    count++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
