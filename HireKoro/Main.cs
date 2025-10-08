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
using Guna.UI2.WinForms;

namespace HireKoro
{
    public partial class Main : Form
    {
        internal static Panel MainPanel { get;  set; }
        internal static Panel SidePanel { get; set; }
        internal static Guna2HtmlLabel TopLabelText { get; set; }


        // Pages
        internal static UserControl WelcomePage { get; set; }
        internal static UserControl SignInPage { get; set; }
        internal static UserControl SignUpPage { get; set; }
        internal static UserControl FreelancerRegisterPage { get; set; }
        internal static UserControl ClientRegisterPage { get; set; }
        internal static UserControl ClientHomePage { get; set; }
        internal static UserControl ProfilePage { get; set;  }
        internal static UserControl AdminProjectsPage { get; set; }
        internal static UserControl AdminTasksPage { get; set; }
        internal static UserControl AdminUsersPage { get; set; }
        internal static UserControl AdminReviewsPage { get; set; }
        internal static UserControl AdminInvoicesPage { get; set; }

        // Data Access Object
        internal static DataAccess DB { get; set; }

        public Main()
        {
            InitializeComponent();
            DraggableWindow.MakePanelDraggable(this.TopPanel, this);
            DB = new DataAccess();
            MainPanel = this.pnlMainPanel;
            SidePanel = this.pnlSidePanel;
            TopLabelText = this.lblTopText;
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

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ProfilePage = new FreelancerProfilePage();
            ChangeWindow(ProfilePage);
            SidePanel.Visible = true;
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            AdminProjectsPage = new AdminProjects();
            ChangeWindow(AdminProjectsPage);
            Main.TopLabelText.Text = "Admin - Projects";
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            AdminTasksPage = new AdminTasksPage();
            ChangeWindow(AdminTasksPage);
            Main.TopLabelText.Text = "Admin - Tasks";
        }
    }
}
