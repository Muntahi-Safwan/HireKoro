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
            Main.SidePanel.Visible = false;
            Main.ChangeWindow(Main.WelcomePage);
            Main.TopLabelText.Text = "HireKoro";
        }
    }
}