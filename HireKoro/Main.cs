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
        internal static string CurrentUserId { get; set; }
        internal static string userRole { get; set; }
        internal static Panel MainPanel { get;  set; }
        internal static Panel SidePanel { get; set; }
        internal static Guna2HtmlLabel TopLabelText { get; set; }


        // Pages
        internal static UserControl WelcomePage { get; set; }
        internal static UserControl SignInPage { get; set; }
        internal static UserControl SignUpPage { get; set; }
        internal static UserControl FreelancerRegisterPage { get; set; }
        internal static UserControl FreelancerTaskPage { get; set; }
        internal static UserControl FreelancerDetailsPage { get; set; }
        internal static UserControl FreelancerHiringPage { get; set; }
        internal static UserControl ClientRegisterPage { get; set; }
        internal static UserControl ClientHomePage { get; set; }
        internal static UserControl ProfilePage { get; set;  }
        internal static UserControl AdminProjectsPage { get; set; }
        internal static UserControl AdminTasksPage { get; set; }
        internal static UserControl AdminUsersPage { get; set; }
        internal static UserControl AdminReviewsPage { get; set; }
        internal static UserControl AdminInvoicesPage { get; set; }
        internal static UserControl ForgotPasswordPage { get; set; }
        

        // Data Access Object
        internal static DataAccess DB { get; set; }

        // Auth Object
        internal static Auth auth { get; set; }

        public Main()
        {
            InitializeComponent();
            DraggableWindow.MakePanelDraggable(this.TopPanel, this);
            DB = new DataAccess();
            auth = new Auth();
            CurrentUserId = "1";
            MainPanel = this.pnlMainPanel;
            SidePanel = this.pnlSidePanel;
            TopLabelText = this.lblTopText;
            WelcomePage = new Welcome();
            this.sidebarBtnReset();
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
            auth.Logout();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ProfilePage = new FreelancerProfilePage();
            ChangeWindow(ProfilePage);
            btnProfile.ForeColor = Color.FromArgb(121, 208, 2532);
            SidePanel.Visible = true;
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            AdminProjectsPage = new AdminProjects();
            ChangeWindow(AdminProjectsPage);
            btnProjects.ForeColor = Color.FromArgb(121, 208, 2532);
            Main.TopLabelText.Text = "Admin - Projects";
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            AdminReviewsPage = new AdminReviews();
            ChangeWindow(AdminReviewsPage);
            btnReviews.ForeColor = Color.FromArgb(121, 208, 2532);
            Main.TopLabelText.Text = " Admin - Reviews";
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            AdminInvoicesPage = new AdminInvoices();
            ChangeWindow(AdminInvoicesPage);
            btnInvoices.ForeColor = Color.FromArgb(121, 208, 2532);
            Main.TopLabelText.Text = " Admin - Invoices";
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            AdminUsersPage = new AdminUsers();
            ChangeWindow(AdminUsersPage);
            btnUsers.ForeColor = Color.FromArgb(121, 208, 2532);
            Main.TopLabelText.Text = " Admin - Users";
        }

        private void btnAdminTasks_Click(object sender, EventArgs e)
        {
            AdminTasksPage = new AdminTasksPage();
            ChangeWindow(AdminTasksPage);
            btnAdminTasks.ForeColor = Color.FromArgb(121, 208, 2532);
            Main.TopLabelText.Text = "Admin - Tasks";
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            FreelancerTaskPage = new FreelancerTaskPage();
            ChangeWindow(FreelancerTaskPage);
            btnTask.ForeColor = Color.FromArgb(121, 208, 2532);
            Main.TopLabelText.Text = "My Tasks";
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ClientHomePage = new ClientHomePage();
            ChangeWindow(ClientHomePage);
            btnHome.ForeColor = Color.FromArgb(121, 208, 2532);
            Main.TopLabelText.Text = "Home";
        }

        public void sidebarBtnReset()
        {
            this.btnAdminTasks.ForeColor = this.btnHome.ForeColor = this.btnInvoices.ForeColor = Color.White;
            this.btnMyProjects.ForeColor = this.btnProfile.ForeColor = this.btnMessages.ForeColor = Color.White;
            this.btnDashboard.ForeColor = this.btnProjects.ForeColor = this.btnUsers.ForeColor = Color.White;
            this.btnLogs.ForeColor = this.btnReviews.ForeColor = this.btnTask.ForeColor = Color.White;
        }

        private void btnMyProjects_Click(object sender, EventArgs e)
        {
            btnMyProjects.ForeColor = Color.FromArgb(121, 208, 2532);
        }
    }
}
