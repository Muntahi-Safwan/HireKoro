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
    public partial class FreelancerRegister : UserControl
    {
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
                Main.FreelancerTaskPage = new FreelancerTaskPage();
                Main.ChangeWindow(Main.FreelancerTaskPage);
                Main.SidePanel.Visible = true;
            }
        }
    }
}
