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
            this.loadCompletedTasks(Main.CurrentUserId);
            this.loadOngoingTasks(Main.CurrentUserId);
        }
        public void loadCompletedTasks(string freelancerId)
        {
            try
            {
                string query = $@"
                SELECT 
                    T.TaskID,
                    T.Name AS TaskName,
                    T.Status,
                    T.Deadline,
                    T.Description AS TaskDescription,
                    P.ProjectID
                FROM Tasks T
                JOIN Projects P ON T.ProjectID = P.ProjectID
                WHERE 
                    P.FreelancerID = {freelancerId}
                    AND T.Status = 'Completed'
                ORDER BY P.Title;
                ";
                var response = Main.DB.ExecuteQueryTable(query);
                this.flpTasksCompleted.Controls.Clear();
                if (response.Rows.Count > 0)
                {
                    foreach (DataRow row in response.Rows)
                    {
                        string taskId = row["TaskID"].ToString();
                        string taskName = row["TaskName"].ToString();
                        string taskDescription = row["TaskDescription"].ToString();
                        string status = row["Status"].ToString();
                        DateTime deadline = DateTime.Parse(row["Deadline"].ToString());
                        TaskCard card = new TaskCard(taskId, taskName, taskDescription, status, deadline);
                        this.flpTasksCompleted.Controls.Add(card);
                    }
                }
                else
                {
                    Label noTasksLabel = new Label();
                    noTasksLabel.Text = "No Completed tasks.";
                    noTasksLabel.Font = new Font("Segoe UI", 16, FontStyle.Italic);
                    noTasksLabel.ForeColor = Color.White;
                    noTasksLabel.AutoSize = true;
                    noTasksLabel.Margin = new Padding(10);
                    this.flpTasksCompleted.Controls.Add(noTasksLabel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void loadOngoingTasks(string freelancerId)
        {
            try
            {
                string query = $@"
                SELECT 
                    T.TaskID,
                    T.Name AS TaskName,
                    T.Status,
                    T.Deadline,
                    T.Description AS TaskDescription,
                    P.ProjectID
                FROM Tasks T
                JOIN Projects P ON T.ProjectID = P.ProjectID
                WHERE 
                    P.FreelancerID = {freelancerId}
                    AND T.Status = 'In Progress'
                ORDER BY P.Title;
                ";
                var response = Main.DB.ExecuteQueryTable(query);
                this.flpTasksOngoing.Controls.Clear();
                if (response.Rows.Count > 0)
                {
                    foreach (DataRow row in response.Rows)
                    {
                        string taskId = row["TaskID"].ToString();
                        string taskName = row["TaskName"].ToString();
                        string taskDescription = row["TaskDescription"].ToString();
                        string status = row["Status"].ToString();
                        DateTime deadline = DateTime.Parse(row["Deadline"].ToString());
                        TaskCard card = new TaskCard(taskId, taskName, taskDescription, status, deadline);
                        this.flpTasksOngoing.Controls.Add(card);
                    }
                }
                else
                {
                    Label noTasksLabel = new Label();
                    noTasksLabel.Text = "No Ongoing tasks.";
                    noTasksLabel.Font = new Font("Segoe UI", 16, FontStyle.Italic);
                    noTasksLabel.ForeColor = Color.White;
                    noTasksLabel.AutoSize = true;
                    noTasksLabel.Margin = new Padding(10);
                    this.flpTasksOngoing.Controls.Add(noTasksLabel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
