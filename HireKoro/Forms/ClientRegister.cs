using HireKoro.Utilities;
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
    public partial class ClientRegister : UserControl
    {
        public ClientRegister()
        {
            InitializeComponent();
        }

        private void btnClientCreate_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text==""|| this.txtEmail.Text==""||this.txtPassword.Text==""||this.txtUserName.Text=="")
            {
                MessageBox.Show("Fill All The Field First");
                return;
            }
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string username = txtUserName.Text;
            bool registerClient = Main.auth.signUpClient(email, password, name, username);  
            if (!registerClient)
            {
                MessageBox.Show("Registration failed. Please try again.", "Error");
            } else
            {
                MessageBox.Show("Registration successful! Welcome to HireKoro.", "Success");
                Main.ClientHomePage = new ClientHomePage();
                Main.ChangeWindow(Main.ClientHomePage);
                Main.SidePanel.Visible = true;
            }
        }

        private void btnsignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Main.SignInPage = new Login();
            Main.ChangeWindow(Main.SignInPage);
        }
    }
}
