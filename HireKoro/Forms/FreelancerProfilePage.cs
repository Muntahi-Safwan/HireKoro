using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HireKoro.Utilities;

namespace HireKoro.Forms
{
    public partial class FreelancerProfilePage : UserControl
    {
        public FreelancerProfilePage()
        {
            InitializeComponent();
            this.loadUserInfo(Main.CurrentUserId);  
        }

        public void loadUserInfo(string userId)
        {
            try
            {
                string query = $"SELECT * FROM USERS WHERE USERID={userId}";
                var response = Main.DB.ExecuteQueryTable(query);
                if(response.Rows.Count == 0)
                {
                    MessageBox.Show("User Not Found", "Sorry the user was not found in the database or there might be some issue in connection");
                    return;
                }

                this.txtName.Text = response.Rows[0]["Name"]?.ToString() ?? "";
                this.txtDescription.Text = response.Rows[0]["Description"]?.ToString() ?? "";
                this.txtUsername.Text = response.Rows[0]["username"]?.ToString() ?? "";
                this.txtEmail.Text = response.Rows[0]["Email"]?.ToString() ?? "";
                this.txtSkills.Text = response.Rows[0]["Skills"]?.ToString() ?? "";
                this.txtHourlyRate.Text = response.Rows[0]["HourlyRate"]?.ToString() ?? "";

            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            string name = this.txtName.Text.Trim();
            string description = this.txtDescription.Text.Trim();
            string email = this.txtEmail.Text.Trim();
            string skills = this.txtSkills.Text.Trim();
            string hourlyRate = this.txtHourlyRate.Text.Trim();
            string userId = Main.CurrentUserId;

            if (!string.IsNullOrEmpty(hourlyRate) && !decimal.TryParse(hourlyRate, out _))
            {
                MessageBox.Show("Please enter a valid hourly rate.", "Validation Error");
                return;
            }

            try
            {
                string query = $@"UPDATE USERS SET 
                                Name='{name.Replace("'", "''")}', 
                                Description='{description.Replace("'", "''")}', 
                                Email='{email.Replace("'", "''")}', 
                                Skills='{skills.Replace("'", "''")}', 
                                HourlyRate={(string.IsNullOrEmpty(hourlyRate) ? "NULL" : hourlyRate)} 
                                WHERE UserID={userId}";

                int response = Main.DB.ExecuteDMLQuery(query);
                if(response == 1)
                {
                    MessageBox.Show("Profile Updated Successfully", "Success");
                } else
                {
                    MessageBox.Show("Profile Update Failed", "Failed");
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message, "Error");
            }
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                string currentPassword = txtCurrentPassword.Text;
                string newPassword = txtNewPassword.Text;

                // Validate input
                if (string.IsNullOrWhiteSpace(currentPassword))
                {
                    MessageBox.Show("Please enter your current password.", "Validation Error");
                    txtCurrentPassword.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    MessageBox.Show("Please enter a new password.", "Validation Error");
                    txtNewPassword.Focus();
                    return;
                }

                bool success = Main.auth.UpdatePassword(currentPassword, newPassword);

                if (success)
                {
                    txtCurrentPassword.Clear();
                    txtNewPassword.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error");
            }
        }
    }
}
