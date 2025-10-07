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
using HireKoro.Forms;

namespace HireKoro
{
    public partial class Main : Form
    {
        internal static Panel MainPanel { get;  set; }
        internal static Panel SidePanel { get; set; }



        // Pages
        internal static UserControl WelcomePage { get; set; }
        internal static UserControl SignInPage { get; set; }
        internal static UserControl ClientHomePage { get; set; }

        public Main()
        {
            InitializeComponent();
            DraggableWindow.MakePanelDraggable(this.TopPanel, this);

            MainPanel = this.pnlMainPanel;
            SidePanel = this.pnlSidePanel;
            WelcomePage = new Welcome();
            ChangeWindow(WelcomePage);

        }

        // Change Window
        internal static void ChangeWindow(UserControl NextPage)
        {
            NextPage.Dock = DockStyle.Fill;
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(NextPage);
            NextPage.Show();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            ChangeWindow(WelcomePage);
            SidePanel.Visible = false;
        }
    }
}
