using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private string projectID { get; set; }
        public FreelancerHiringPage()
        {
            InitializeComponent();
            txtCost.Text = "0.00";
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
                string query = $"INSERT INTO PROJECTS (ClientID, FreelancerID, Title, ProjectDescription, StartDate, ProjectHours, ProjectStatus, Cost) OUTPUT inserted.ProjectID VALUES ({clientId}, {freelancerId}, '{projectTitle}', '{projectDescription}', '{startDate.ToString("yyyy-MM-dd")}', {hours}, 'Ongoing', {cost})";
                var response = Main.DB.ExecuteQueryTable(query);
                this.projectID = response.Rows[0][0].ToString();
                if (response.Rows.Count != 0)
                {
                    MessageBox.Show("Freelancer hired successfully!");
                    Main.DB.ExecuteDMLQuery($"INSERT INTO PROJECTLOG (ProjectID, Status, Comment) Values ('{this.projectID}', 'Created', 'New Project Created and Hired'); ");
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
            try
            {
                string clientId = Main.CurrentUserId;
                string freelancerId = this.freelancerId;
                string projectTitle = this.txtProjectName.Text;
                string projectDescription = this.txtProjectDescription.Text;
                DateTime startDate = this.dtpStartDate.Value;
                
                if (!float.TryParse(this.txtHours.Text, out float hours))
                {
                    MessageBox.Show("Please enter a valid number of hours.", "Invalid Input");
                    return;
                }
                
                float cost = hours * float.Parse(this.lblHour.Text.Replace("$", "").Replace("/hr", ""));
                var confirmResult = MessageBox.Show($"Are you sure to hire this freelancer for ${cost:F2}?", "Confirm Hire", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    HireFreelancer(clientId, freelancerId, projectTitle, projectDescription, startDate, hours, cost);
                    Main.FreelancerHiredSuccesfully = new FreelancerHiredSuccesfullyPage();
                    Main.ChangeWindow(Main.FreelancerHiredSuccesfully);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtHours_TextChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }

        private void txtHours_TextChanged_1(object sender, EventArgs e)
        {
            CalculateCost();
        }

        private void CalculateCost()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtHours.Text))
                {
                    if (float.TryParse(txtHours.Text, out float hours))
                    {
                        string hourlyRateText = lblHour.Text.Replace("$", "").Replace("/hr", "");
                        
                        if (float.TryParse(hourlyRateText, out float hourlyRate))
                        {
                            float totalCost = hours * hourlyRate;
                            txtCost.Text = totalCost.ToString("F2"); 
                        }
                        else
                        {
                            txtCost.Text = "0.00";
                        }
                    }
                    else
                    {
                        txtCost.Text = "0.00";
                    }
                }
                else
                {
                    txtCost.Text = "0.00";
                }
            }
            catch (Exception)
            {
                
                txtCost.Text = "0.00";
            }
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}

