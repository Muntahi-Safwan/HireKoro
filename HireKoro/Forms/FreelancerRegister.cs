using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HireKoro.Forms
{
    public partial class FreelancerRegister : UserControl
    {
        internal static string destinationFilePath { set; get; }
        public FreelancerRegister()
        {
            InitializeComponent();
        }
        private void btnFreelancerCreate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Main.SignInPage = new Login();
            Main.ChangeWindow(Main.SignInPage);
        }

        private void btnFreelanceRegister_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text == "" || this.txtEmail.Text == "" || this.txtPassword.Text == "" || this.txtUserName.Text == "" || this.txtSkills.Text == "" || this.txtDescription.Text == "")
            {
                MessageBox.Show("Fill All The Field First");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtHourlyRate.Text))
            {
                MessageBox.Show("Hourly Rate cannot be empty!");
                return;
            }

            float hourlyRate;
            if (!float.TryParse(txtHourlyRate.Text, out hourlyRate))
            {
                MessageBox.Show("Hourly Rate must be a valid number!");
                return;
            }
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string username = txtUserName.Text;
            string skills = txtSkills.Text;
            string description = txtDescription.Text;
            float HourlyRate = float.Parse(txtHourlyRate.Text);
           
            bool registerFreelancer = Main.auth.signUpFreelancer(email, password, name, username, skills, description, HourlyRate);
            if (registerFreelancer)
            {
                Main.SignInPage = new Login();
                Main.ChangeWindow(Main.SignInPage);
                MessageBox.Show("Freelancer Registered Successfully");
                Main.TopLabelText.Text = "Sign In";
            }
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            Main.WelcomePage = new Welcome();
            Main.ChangeWindow(Main.WelcomePage);
        }

        
    }
}
