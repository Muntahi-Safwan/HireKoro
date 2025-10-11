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
        public ProjectCard()
        {
            InitializeComponent();
        }
        public ProjectCard(string id, string title,string status, string description, DateTime startDate, float hours): this()
        {
            this.lblProjectName.Text = title;
            this.lblStatus.Text = status;
            this.lblDescription.Text = description;
            this.lblHours.Text = $"Hours: {hours} hr";
            this.lblStartDate.Text = $"Start Date: {startDate.ToShortDateString()}";
        }
    }
}
