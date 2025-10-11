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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Main.ClientHomePage = new ClientHomePage();
            Main.ChangeWindow(Main.ClientHomePage);
            Main.SidePanel.Visible = true;
        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            Main.ForgotPasswordPage = new ForgotPassword();
            Main.ChangeWindow(Main.ForgotPasswordPage);
        }
    }
}
