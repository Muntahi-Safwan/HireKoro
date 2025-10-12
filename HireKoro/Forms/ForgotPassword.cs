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
    public partial class ForgotPassword : UserControl
    {
        public ForgotPassword()
        {
            InitializeComponent();
            txtNewPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Main.SignInPage = new Login();
            Main.ChangeWindow(Main.SignInPage);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string newPassword = txtNewPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;

                // Validate input
                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Please enter your email address.", "Validation Error");
                    txtEmail.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    MessageBox.Show("Please enter a new password.", "Validation Error");
                    txtNewPassword.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(confirmPassword))
                {
                    MessageBox.Show("Please confirm your new password.", "Validation Error");
                    txtConfirmPassword.Focus();
                    return;
                }


                // Check if passwords match
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("New password and confirm password do not match.", "Validation Error");
                    txtConfirmPassword.Focus();
                    return;
                }

                // Validate password strength
                if (newPassword.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters long.", "Validation Error");
                    txtNewPassword.Focus();
                    return;
                }

                bool success = Main.auth.forgotPassword(email, newPassword);

                if (success)
                {
                    ClearForm();
                    Main.SignInPage = new Login();
                    Main.ChangeWindow(Main.SignInPage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error");
            }
        }

        private void ClearForm()
        {
            txtEmail.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }
    }
}
