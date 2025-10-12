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
    public partial class ProjectCard : UserControl
    {
        string projectId { get; set; }
        public ProjectCard()
        {
            InitializeComponent();
        }
        public ProjectCard(string id, string title,string status, string description, DateTime startDate, float hours, bool details=false): this()
        {
            this.projectId = id;
            this.lblProjectName.Text = title;
            this.lblStatus.Text = status;
            this.lblDescription.Text = description;
            this.lblHours.Text = $"Hours: {hours} hr";
            this.lblStartDate.Text = $"Start Date: {startDate.ToShortDateString()}";
            if (details)
            {
                btnDetails.Visible = true;
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            Main.ProjectDetailsPage = new ProjectDetailsPage(projectId);
            Main.ChangeWindow(Main.ProjectDetailsPage);
        }
    }
}
