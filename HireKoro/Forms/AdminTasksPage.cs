using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace HireKoro.Forms
{
    public partial class AdminTasksPage : UserControl
    {
        public AdminTasksPage()
        {
            InitializeComponent();
            this.LoadTasks();
            this.load_ProjectName();
        }

        void LoadTasks(string query = " SELECT T.TaskID, T.NAME, T.Description, T.Status, T.Deadline, T.Priority, T.IsCompleted, P.Title FROM TASKS AS T, PROJECTS P WHERE T.ProjectID = P.ProjectID")
        {
            try
            {
                var response = Main.DB.ExecuteQueryTable(query);
                dgvTasks.DataSource = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message);
            }
        }
        internal void ClearALL()
        {
            this.txtTaskID.Clear();
            this.cmbProject.SelectedIndex = -1;
            this.txtDescription.Clear();
            this.txtName.Clear();
            this.cmbStatus.SelectedIndex = -1;
            this.dtpDeadline.Value = DateTime.Today;
            this.cmbPriority.SelectedIndex = -1;
            this.cmbisCompleated.SelectedIndex = -1;


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearALL();
        }
        private void load_ProjectName(string query = "select  * from PROJECTS")
        {

            try
            {
                var DT = Main.DB.ExecuteQueryTable(query);
                this.cmbProject.DataSource = DT;
                this.cmbProject.DisplayMember = "Title";
                this.cmbProject.ValueMember = "ProjectID";


            }
            catch (Exception ex) { MessageBox.Show($"ERROR {ex.Message}"); }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = $"SELECT T.TaskID, T.NAME, T.Description, T.Status, T.Deadline, T.Priority, T.IsCompleted, P.Title FROM TASKS AS T, PROJECTS P WHERE T.ProjectID = P.ProjectID  and ( TaskID like '{this.txtSearch.Text}%' or Name like '{this.txtSearch.Text}%');";
            this.LoadTasks(query);
        }

        private void dgvTasks_DoubleClick(object sender, EventArgs e)
        {
            this.txtTaskID.Text = this.dgvTasks.CurrentRow.Cells["TaskID"].Value.ToString();
            this.txtName.Text = this.dgvTasks.CurrentRow.Cells["TaskName"].Value.ToString();
            this.cmbStatus.Text = this.dgvTasks.CurrentRow.Cells["TaskStatus"].Value.ToString();
            this.txtDescription.Text = this.dgvTasks.CurrentRow.Cells["TaskDescription"].Value.ToString();
            this.dtpDeadline.Text = this.dgvTasks.CurrentRow.Cells["TaskDeadline"].Value.ToString();
            this.cmbisCompleated.Text = this.dgvTasks.CurrentRow.Cells["isCompleted"].Value.ToString();
            this.cmbPriority.Text = this.dgvTasks.CurrentRow.Cells["Priority"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.txtTaskID.Text = this.dgvTasks.CurrentRow.Cells["TaskID"].Value.ToString();
            try
            {
                string query = $"DELETE FROM TASKS WHERE TaskID = {this.txtTaskID.Text};";
                var response = Main.DB.ExecuteDMLQuery(query);
                dgvTasks.DataSource = response;
                this.LoadTasks();
                MessageBox.Show("Project deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting projects: " + ex.Message);
            }

        }






        private void CreateProject()
        {
            try
            {
                string query = $@"INSERT INTO Tasks (ProjectID, Name, Status, 
                                 Description, Deadline, Priority, IsCompleted ) 
                                 VALUES ( '{cmbProject.SelectedValue.ToString()}', '{txtName.Text}', 
                                 '{cmbStatus.Text}', '{txtDescription.Text}', '{dtpDeadline.Value.ToString("yyyy-MM-dd HH:mm:ss")}', '{cmbPriority.Text}', '{cmbisCompleated.Text}')";

                Main.DB.ExecuteDMLQuery(query);
                MessageBox.Show("Project created successfully!");
                LoadTasks();
                ClearALL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating project: " + ex.Message);
            }
        }

        private void UpdateProject()
        {
            try
            {
                string query = $@"UPDATE Tasks SET 
                                
                                 ProjectID = '{cmbProject.SelectedValue.ToString()}',
                                 Name = '{txtName.Text}',
                                 Status = '{cmbStatus.Text}',
                                 Description = '{txtDescription.Text}',
                                 Deadline = '{dtpDeadline.Value}',
                                 Priority = '{cmbPriority.Text}',
                                 IsCompleted = '{cmbisCompleated.Text}'
                                 WHERE TaskID = {txtTaskID.Text}";

                Main.DB.ExecuteDMLQuery(query);
                MessageBox.Show("INVOICES updated successfully!");
                LoadTasks();
                ClearALL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating project: " + ex.Message);
            }
        }

        

        private void cmbprojectn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.load_ProjectName($"select  * from PROJECTS where Title like '{this.cmbProject.Text}%'");

            }
        }

        private void cmbprojectn_TextChanged(object sender, EventArgs e)
        {
            if (this.cmbProject.Text == "")
            {
                this.load_ProjectName();

            }
        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {

            bool isUpdateMode = !string.IsNullOrEmpty(txtTaskID.Text.Trim());

            if (isUpdateMode)
            {
                UpdateProject();
            }
            else
            {
                CreateProject();
            }
        }
    }
}
