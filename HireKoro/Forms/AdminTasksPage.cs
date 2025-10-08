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
    public partial class AdminTasksPage : UserControl
    {
        public AdminTasksPage()
        {
            InitializeComponent();
            this.LoadTasks();
        }

        void LoadTasks()
        {
            try
            {
                string query = "SELECT T.TaskID, T.NAME, T.Description, T.Status, T.Deadline, T.Priority, T.IsCompleted, P.Title FROM TASKS AS T, PROJECTS P WHERE T.ProjectID = P.ProjectID;\r\n";
                var response = Main.DB.ExecuteQueryTable(query);
                dgvTasks.DataSource = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message);
            }
        }
    }
}
