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
    public partial class FreelancerTaskPage : UserControl
    {
        public FreelancerTaskPage()
        {
            InitializeComponent();
        }
        public void loadTasks(string freelancerId)
        {
            try
            {
                string query1 = $"Select * FROM Tasks WHERE FreelancerID={freelancerId}";
                var response = Main.DB.ExecuteQueryTable(query);
                this.flpTasksCompleted\.Controls.Clear();
                if (response.Rows.Count > 0)
                {
                    foreach (DataRow row in response.Rows)
                    {
                        ProjectCard card = new ProjectCard(row["ProjectID"].ToString(), row["Title"].ToString(), row["ProjectStatus"].ToString(), row["ProjectDescription"].ToString(), Convert.ToDateTime(row["StartDate"]), float.Parse(row["ProjectHours"].ToString()));
                        this.flowTasks.Controls.Add(card);
                    }
                }
                else
                {
                    Label noTasksLabel = new Label();
                    noTasksLabel.Text = "No tasks assigned.";
                    noTasksLabel.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                    noTasksLabel.ForeColor = Color.Gray;
                    noTasksLabel.AutoSize = true;
                    noTasksLabel.Margin = new Padding(10);
                    this.flowTasks.Controls.Add(noTasksLabel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
