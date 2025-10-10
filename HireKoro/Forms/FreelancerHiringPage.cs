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
    public partial class FreelancerHiringPage : UserControl
    {
        private string freelancerId { get; set; }
        public FreelancerHiringPage()
        {
            InitializeComponent();
        }
        public FreelancerHiringPage(string id) : this()
        {
            loadUser(id);
            this.freelancerId = id;
        }
        internal void loadUser(string id)
        {
            try
            {
                string query = $"Select * FROM USERS WHERE UserID={id}";
                var response = Main.DB.ExecuteQueryTable(query);
                if (response.Rows.Count > 0)
                {
                    this.lblName.Text = response.Rows[0]["Name"].ToString();
                    this.lblUsername.Text = response.Rows[0]["Username"].ToString();
                    this.lblHour.Text = $"${response.Rows[0]["HourlyRate"].ToString()}/hr";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal void HireFreelancer(string clientId, string freelancerId, string projectTitle, string projectDescription, DateTime startDate, float hours, float cost)
        {
            try
            {
                string query = $"INSERT INTO PROJECTS (ClientID, FreelancerID, Title, ProjectDescription, StartDate, ProjectHours, ProjectStatus, Cost) VALUES ({clientId}, {freelancerId}, '{projectTitle}', '{projectDescription}', '{startDate.ToString("yyyy-MM-dd")}', {hours}, 'Ongoing', {cost})";
                int response = Main.DB.ExecuteDMLQuery(query);
                if (response > 0)
                {
                    MessageBox.Show("Freelancer hired successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to hire freelancer.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string clientId = Main.CurrentUserId;
            string freelancerId = this.freelancerId;
            string projectTitle = this.txtProjectName.Text;
            string projectDescription = this.txtProjectDescription.Text;
            DateTime startDate = this.dtpStartDate.Value;
            float hours = float.Parse(this.txtHours.Text);
            float cost = hours * float.Parse(this.lblHour.Text.Replace("$", "").Replace("/hr", ""));
            var confirmResult = MessageBox.Show($"Are you sure to hire this freelancer for ${cost}?", "Confirm Hire", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                HireFreelancer(clientId, freelancerId, projectTitle, projectDescription, startDate, hours, cost);
            }
        }

        private void txtHours_TextChanged(object sender, EventArgs e)
        {
            this.txtCost.Text = (float.Parse(this.txtHours.Text) * float.Parse(this.lblHour.Text.Replace("$", "").Replace("/hr", ""))).ToString();
        }
    }
}
