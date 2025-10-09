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
    public partial class AdminProjects : UserControl
    {
        public AdminProjects()
        {
            InitializeComponent();
            this.LoadProjects();
        }

        internal void LoadProjects()
        {
            try
            {
                string query = "SELECT P.ProjectID, P.Title, P.ProjectStatus, P.ProjectHours,  P.StartDate,  P.Cost,   P.ProjectDescription,  C.Name AS ClientName,  F.Name AS FreelancerName FROM PROJECTS P JOIN USERS C ON P.ClientID = C.UserID LEFT JOIN USERS F ON P.FreelancerID = F.UserID;";
                var response = Main.DB.ExecuteQueryTable(query);
                dgvProjects.DataSource = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading projects: " + ex.Message);
            }
        }
    }
}

