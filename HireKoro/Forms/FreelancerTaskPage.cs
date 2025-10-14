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
        private string selectedTaskId = "";

        public FreelancerTaskPage()
        {
            InitializeComponent();
            this.LoadFreelancerProjects();
            this.SetupStatusComboBox();
            this.SetupPriorityComboBox();
            this.loadCompletedTasks(Main.CurrentUserId);
            this.loadOngoingTasks(Main.CurrentUserId);
            this.WireUpEvents();
        }

        private void WireUpEvents()
        {
            
            this.guna2Button2.Click += btnCreate_Click; 
            this.guna2Button3.Click += btnDelete_Click;
            
            this.guna2TextBox3.ReadOnly = true;
            this.guna2TextBox3.Click += (sender, e) => ShowDateTimePicker();
        }

        private void ShowDateTimePicker()
        {
            using (Form dateForm = new Form())
            {
                dateForm.Size = new Size(300, 200);
                dateForm.Text = "Select Deadline";
                dateForm.StartPosition = FormStartPosition.CenterParent;
                
                DateTimePicker dtp = new DateTimePicker();
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                dtp.Location = new Point(20, 20);
                dtp.Size = new Size(250, 30);
                dtp.Value = DateTime.Now.AddDays(7);
                
                Button okBtn = new Button();
                okBtn.Text = "OK";
                okBtn.Location = new Point(100, 80);
                okBtn.Size = new Size(80, 30);
                okBtn.Click += (s, e) => {
                    this.guna2TextBox3.Text = dtp.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    dateForm.Close();
                };
                
                dateForm.Controls.Add(dtp);
                dateForm.Controls.Add(okBtn);
                dateForm.ShowDialog();
            }
        }

        private void SetupStatusComboBox()
        {
            this.cmbprojectn.Items.Clear();
            this.cmbprojectn.Items.AddRange(new string[] { "Pending", "In Progress", "Completed", "On Hold" });
            this.cmbprojectn.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void SetupPriorityComboBox()
        {
            this.cmbprojectm.Items.Clear();
            this.cmbprojectm.Items.AddRange(new string[] { "Low", "Medium", "High", "Critical" });
            this.cmbprojectm.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadFreelancerProjects()
        {
            try
            {
                string query = $"SELECT ProjectID, Title FROM PROJECTS WHERE FreelancerID = {Main.CurrentUserId}";
                var response = Main.DB.ExecuteQueryTable(query);
                
                this.cmbprojectk.DataSource = response;
                this.cmbprojectk.DisplayMember = "Title";
                this.cmbprojectk.ValueMember = "ProjectID";
                this.cmbprojectk.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading projects: " + ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool isUpdateMode = !string.IsNullOrEmpty(selectedTaskId);

            if (isUpdateMode)
            {
                UpdateTask();
            }
            else
            {
                CreateTask();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedTaskId))
            {
                UpdateTask();
            }
            else
            {
                MessageBox.Show("Please select a task to update first.", "No Task Selected");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedTaskId))
            {
                MessageBox.Show("Please select a task to delete first.", "No Task Selected");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure you want to delete this task?", 
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (confirmResult == DialogResult.Yes)
            {
                DeleteTask();
            }
        }

        private void CreateTask()
        {
            try
            {
                // Validate inputs
                if (!ValidateInputs())
                    return;

                string query = $@"INSERT INTO Tasks (ProjectID, Name, Status, Description, Deadline, Priority, IsCompleted) 
                                 VALUES ({cmbprojectk.SelectedValue}, '{guna2TextBox1.Text.Replace("'", "''")}', 
                                        '{cmbprojectn.Text}', '{guna2TextBox2.Text.Replace("'", "''")}', 
                                        '{guna2TextBox3.Text}', '{cmbprojectm.Text}', 
                                        '{(cmbprojectn.Text == "Completed" ? "True" : "False")}')";

                int result = Main.DB.ExecuteDMLQuery(query);
                
                if (result > 0)
                {
                    MessageBox.Show("Task created successfully!", "Success");
                    RefreshTaskLists();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to create task.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating task: " + ex.Message, "Error");
            }
        }

        private void UpdateTask()
        {
            try
            {
                // Validate inputs
                if (!ValidateInputs())
                    return;

                if (string.IsNullOrEmpty(selectedTaskId))
                {
                    MessageBox.Show("No task selected for update.", "Error");
                    return;
                }

                string query = $@"UPDATE Tasks SET 
                                 ProjectID = {cmbprojectk.SelectedValue},
                                 Name = '{guna2TextBox1.Text.Replace("'", "''")}',
                                 Status = '{cmbprojectn.Text}',
                                 Description = '{guna2TextBox2.Text.Replace("'", "''")}',
                                 Deadline = '{guna2TextBox3.Text}',
                                 Priority = '{cmbprojectm.Text}',
                                 IsCompleted = '{(cmbprojectn.Text == "Completed" ? "True" : "False")}'
                                 WHERE TaskID = {selectedTaskId}";

                int result = Main.DB.ExecuteDMLQuery(query);
                
                if (result > 0)
                {
                    MessageBox.Show("Task updated successfully!", "Success");
                    RefreshTaskLists();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to update task.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating task: " + ex.Message, "Error");
            }
        }

        private void DeleteTask()
        {
            try
            {
                string query = $"DELETE FROM Tasks WHERE TaskID = {selectedTaskId}";
                int result = Main.DB.ExecuteDMLQuery(query);
                
                if (result > 0)
                {
                    MessageBox.Show("Task deleted successfully!", "Success");
                    RefreshTaskLists();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete task.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting task: " + ex.Message, "Error");
            }
        }

        private bool ValidateInputs()
        {
            if (cmbprojectk.SelectedValue == null)
            {
                MessageBox.Show("Please select a project.", "Validation Error");
                cmbprojectk.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                MessageBox.Show("Please enter a task name.", "Validation Error");
                guna2TextBox1.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text))
            {
                MessageBox.Show("Please enter a task description.", "Validation Error");
                guna2TextBox2.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox3.Text))
            {
                MessageBox.Show("Please set a deadline.", "Validation Error");
                return false;
            }

            if (cmbprojectm.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a priority.", "Validation Error");
                cmbprojectm.Focus();
                return false;
            }

            if (cmbprojectn.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status.", "Validation Error");
                cmbprojectn.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            selectedTaskId = "";
            cmbprojectk.SelectedIndex = -1;
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            cmbprojectm.SelectedIndex = -1;
            cmbprojectn.SelectedIndex = -1;
            guna2Button2.Text = "Create";
        }

        private void RefreshTaskLists()
        {
            this.loadCompletedTasks(Main.CurrentUserId);
            this.loadOngoingTasks(Main.CurrentUserId);
        }

        public void PopulateTaskForm(string taskId, string projectId, string taskName, string description, 
            string status, string priority, DateTime deadline)
        {
            try
            {
                selectedTaskId = taskId;
                
                cmbprojectk.SelectedValue = projectId;
                
                guna2TextBox1.Text = taskName;
                guna2TextBox2.Text = description;
                guna2TextBox3.Text = deadline.ToString("yyyy-MM-dd HH:mm:ss");
                
                cmbprojectn.Text = status;
                cmbprojectm.Text = priority;
                
                guna2Button2.Text = "Update";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error populating form: " + ex.Message, "Error");
            }
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
                    T.Priority,
                    P.ProjectID,
                    P.Title AS ProjectTitle
                FROM Tasks T
                JOIN Projects P ON T.ProjectID = P.ProjectID
                WHERE 
                    P.FreelancerID = {freelancerId}
                    AND T.Status = 'Completed'
                ORDER BY T.Deadline DESC;
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
                        string priority = row["Priority"].ToString();
                        string projectId = row["ProjectID"].ToString();
                        DateTime deadline = DateTime.Parse(row["Deadline"].ToString());
                        
                        TaskCard card = new TaskCard(taskId, taskName, taskDescription, status, deadline);
                        
                        card.Click += (sender, e) => PopulateTaskForm(taskId, projectId, taskName, 
                            taskDescription, status, priority, deadline);
                        
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
                MessageBox.Show("Error loading completed tasks: " + ex.Message);
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
                    T.Priority,
                    P.ProjectID,
                    P.Title AS ProjectTitle
                FROM Tasks T
                JOIN Projects P ON T.ProjectID = P.ProjectID
                WHERE 
                    P.FreelancerID = {freelancerId}
                    AND T.Status IN ('Pending', 'In Progress', 'On Hold')
                ORDER BY T.Deadline ASC;
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
                        string priority = row["Priority"].ToString();
                        string projectId = row["ProjectID"].ToString();
                        DateTime deadline = DateTime.Parse(row["Deadline"].ToString());
                        
                        TaskCard card = new TaskCard(taskId, taskName, taskDescription, status, deadline);
                        
                        card.Click += (sender, e) => PopulateTaskForm(taskId, projectId, taskName, 
                            taskDescription, status, priority, deadline);
                        
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
                MessageBox.Show("Error loading ongoing tasks: " + ex.Message);
            }
        }
    }
}