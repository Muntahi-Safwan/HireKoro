using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HireKoro.Forms;

namespace HireKoro.Utilities
{
    internal class Auth
    {
        // Register New Client
        internal bool signUpClient(string email, string password, string name, string username)
        {
            string hashPassword = PasswordHelper.HashPassword(password);
            try
            {
                // First check if email or username already exists
                string checkQuery = $"SELECT COUNT(*) FROM USERS WHERE Email='{email.Replace("'", "''")}' OR Username='{username.Replace("'", "''")}'";
                var checkResult = Main.DB.ExecuteQueryTable(checkQuery);

                if (checkResult.Rows.Count > 0 && Convert.ToInt32(checkResult.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Email or Username already exists. Please choose different credentials.", "Registration Failed");
                    return false;
                }

                string insertQuery = $@"INSERT INTO USERS (Name, Username, Email, PasswordHash, UserTypeID) 
                                       VALUES ('{name.Replace("'", "''")}', '{username.Replace("'", "''")}', 
                                              '{email.Replace("'", "''")}', '{hashPassword}', 1)";

                int result = Main.DB.ExecuteDMLQuery(insertQuery);

                if (result > 0)
                {
                    MessageBox.Show("Registration Successful! Welcome to HireKoro.", "Your One Stop Solution for freelance works");
                    return true;
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.", "Registration Failed");
                    return false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Registration error: " + exception.Message, "Error");
                return false;
            }
        }

        // Register New Freelancer
        internal bool signUpFreelancer(string email, string password, string name, string username, string skills, string description, float HourlyRate)
        {
            string hashPassword = PasswordHelper.HashPassword(password);
            try
            {
                // Email or username already exists
                string checkQuery = $"SELECT COUNT(*) FROM USERS WHERE Email='{email.Replace("'", "''")}' OR Username='{username.Replace("'", "''")}'";
                var checkResult = Main.DB.ExecuteQueryTable(checkQuery);

                if (checkResult.Rows.Count > 0 && Convert.ToInt32(checkResult.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Email or Username already exists. Please choose different credentials.", "Registration Failed");
                    return false;
                }

                // Insert new freelancer
                string insertQuery = $@"INSERT INTO USERS (Name, Username, Email, PasswordHash, UserTypeID, Skills, Description, HourlyRate, ProfileImg) 
                                       VALUES ('{name.Replace("'", "''")}', '{username.Replace("'", "''")}', 
                                              '{email.Replace("'", "''")}', '{hashPassword}', 2, 
                                              '{skills.Replace("'", "''")}', '{description.Replace("'", "''")}', {HourlyRate}, 'dummyUrl')";

                int result = Main.DB.ExecuteDMLQuery(insertQuery);

                if (result > 0)
                {
                    MessageBox.Show("Registration successful! Welcome to HireKoro.", "Complete Task and Easily Manage Everything");
                    return true;
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.", "Registration Failed");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Registration error: " + e.Message, "Error");
                return false;
            }
        }

        // User Login
        internal bool Login(string email, string password)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter both email and password.", "Login Failed");
                    return false;
                }

                // Query to get user by email
                string query = $"SELECT UserID, PasswordHash, UserTypeID, Name FROM USERS WHERE Email='{email.Replace("'", "''")}'";
                var response = Main.DB.ExecuteQueryTable(query);

                if (response.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed");
                    return false;
                }

                // Get user data
                var userRow = response.Rows[0];
                string hashedPassword = userRow["PasswordHash"].ToString();
                string userId = userRow["UserID"].ToString();
                int userTypeId = Convert.ToInt32(userRow["UserTypeID"]);
                string userName = userRow["Name"].ToString();

                // Verify password
                if (PasswordHelper.VerifyPassword(password, hashedPassword))
                {
                    Main.CurrentUserId = userId;
                    NavigateToUserDashboard(userTypeId, userName);

                    MessageBox.Show($"Welcome back, {userName}!", "Login Successful");
                    return true;
                }
                else
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message, "Error");
                return false;
            }
        }

        // Individual User Dashboard 
        private void NavigateToUserDashboard(int userTypeId, string userName)
        {
            switch (userTypeId)
            {
                case 1: // Client
                    Main.ClientHomePage = new ClientHomePage();
                    Main.userRole = "Client";
                    Main.ChangeWindow(Main.ClientHomePage);
                    Main.TopLabelText.Text = $"Welcome, {userName}";
                    Main.SidePanel.Visible = true;
                    break;

                case 2: // Freelancer
                    Main.FreelancerTaskPage = new FreelancerTaskPage();
                    Main.userRole = "Freelancer";
                    Main.ChangeWindow(Main.FreelancerTaskPage);
                    Main.TopLabelText.Text = $"Welcome, {userName}";
                    Main.SidePanel.Visible = true;
                    break;

                case 3: // Admin 
                    Main.AdminProjectsPage = new AdminProjects();
                    Main.ChangeWindow(Main.AdminProjectsPage);
                    Main.userRole = "Admin";
                    Main.TopLabelText.Text = $"Admin Dashboard - {userName}";
                    Main.SidePanel.Visible = true;
                    break;
            }
        }
        
        // User Logout
        internal void Logout()
        {
            Main.CurrentUserId = null;
            Main.userRole = null;
            Main.SidePanel.Visible = false;
            Main.ChangeWindow(Main.WelcomePage);
            Main.TopLabelText.Text = "HireKoro";
        }

        // Update Password 
        internal bool UpdatePassword(string currentPassword, string newPassword)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword))
                {
                    MessageBox.Show("Please enter both current and new password.", "Update Failed");
                    return false;
                }

                if (string.IsNullOrEmpty(Main.CurrentUserId))
                {
                    MessageBox.Show("No user is currently logged in.", "Update Failed");
                    return false;
                }

                // Current Password
                string query = $"SELECT PasswordHash FROM USERS WHERE UserID={Main.CurrentUserId}";
                var response = Main.DB.ExecuteQueryTable(query);

                if (response.Rows.Count == 0)
                {
                    MessageBox.Show("User not found.", "Update Failed");
                    return false;
                }

                string currentHashedPassword = response.Rows[0]["PasswordHash"].ToString();

                // Verify current password
                if (!PasswordHelper.VerifyPassword(currentPassword, currentHashedPassword))
                {
                    MessageBox.Show("Current password is incorrect.", "Update Failed");
                    return false;
                }

                // Validate new password strength
                if (newPassword.Length < 6)
                {
                    MessageBox.Show("New password must be at least 6 characters long.", "Update Failed");
                    return false;
                }

                // Hash new password and update
                string newHashedPassword = PasswordHelper.HashPassword(newPassword);
                string updateQuery = $"UPDATE USERS SET PasswordHash='{newHashedPassword}' WHERE UserID={Main.CurrentUserId}";

                int result = Main.DB.ExecuteDMLQuery(updateQuery);

                if (result > 0)
                {
                    MessageBox.Show("Password updated successfully!", "Update Successful");
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed to update password. Please try again.", "Update Failed");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating password: " + ex.Message, "Error");
                return false;
            }
        }

        // Forgot Password 
        internal bool forgotPassword(string email, string newPassword)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(newPassword))
                {
                    MessageBox.Show("Please enter both email and new password.", "Reset Failed");
                    return false;
                }

                // Check Email
                string checkQuery = $"SELECT UserID, Name FROM USERS WHERE Email='{email.Replace("'", "''")}'";
                var response = Main.DB.ExecuteQueryTable(checkQuery);

                if (response.Rows.Count == 0)
                {
                    MessageBox.Show("No account found with this email address.", "Reset Failed");
                    return false;
                }

                // Validate new password strength
                if (newPassword.Length < 6)
                {
                    MessageBox.Show("New password must be at least 6 characters long.", "Reset Failed");
                    return false;
                }

                // Get user details
                string userId = response.Rows[0]["UserID"].ToString();
                string userName = response.Rows[0]["Name"].ToString();

                // Hash new password and update
                string newHashedPassword = PasswordHelper.HashPassword(newPassword);
                string updateQuery = $"UPDATE USERS SET PasswordHash='{newHashedPassword}' WHERE UserID={userId}";

                int result = Main.DB.ExecuteDMLQuery(updateQuery);

                if (result > 0)
                {
                    MessageBox.Show($"Password reset successfully for {userName}! You can now login with your new password.", "Reset Successful");
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed to reset password. Please try again.", "Reset Failed");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting password: " + ex.Message, "Error");
                return false;
            }
        }
    }
}