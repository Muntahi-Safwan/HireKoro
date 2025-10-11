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
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            Main.auth.Login(email, password);
            
        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            Main.ForgotPasswordPage = new ForgotPassword();
            Main.ChangeWindow(Main.ForgotPasswordPage);
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            Main.ChangeWindow(Main.WelcomePage);
        }

        private void btnSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Main.ChangeWindow(Main.SignUpPage);
        }
    }
}
