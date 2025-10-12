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
    public partial class MyProjects : UserControl
    {
        public MyProjects()
        {
            InitializeComponent();
            LoadProjects(Main.CurrentUserId);
        }

        internal void LoadProjects(string id)
        {
            try
            {
                string query = $"Select * FROM PROJECTS WHERE ClientId={id}";
                var response = Main.DB.ExecuteQueryTable(query);
                int count = 0;
                while (count < response.Rows.Count)
                {
                    string projectId = response.Rows[count]["ProjectID"].ToString();
                    string title = response.Rows[count]["Title"].ToString();
                    string status = response.Rows[count]["ProjectStatus"].ToString();
                    string description = response.Rows[count]["ProjectDescription"].ToString();

                    DateTime startDate = DateTime.Parse(response.Rows[count]["StartDate"].ToString());
                    float hours = float.Parse(response.Rows[count]["ProjectHours"].ToString());

                    ProjectCard projectCard = new ProjectCard(projectId, title, status, description, startDate, hours, true);
                    
                    flpProjects.Controls.Add(projectCard);
                    count++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
