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
    public partial class FreelancerDetailsPage : UserControl
    {
        private string freelancerId { get; set; }
        public FreelancerDetailsPage()
        {
            InitializeComponent();
        }
        public FreelancerDetailsPage(string id)
        {
            InitializeComponent();
            loadUser(id);
            LoadProjects(id);
            LoadReviews(id);
            this.freelancerId = id;
        }
        internal void loadUser(string id)
        {
            try
            {
                string query = $"Select * FROM USERS WHERE UserID={id}";
                var response = Main.DB.ExecuteQueryTable(query);
                if (response.Rows.Count > 0)
                {
                    this.lblName.Text = response.Rows[0]["Name"].ToString();
                    this.lblDescription.Text = response.Rows[0]["description"].ToString();
                    this.lblUsername.Text = response.Rows[0]["Username"].ToString();
                    this.lblSkills.Text = response.Rows[0]["Skills"].ToString();
                    this.lblHourlyRate.Text = $"${response.Rows[0]["HourlyRate"].ToString()}/hr";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal void LoadProjects(string id)
        {
            try
            {
                string query = $"Select * FROM PROJECTS WHERE FreelancerID={id}";
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
                    
                    ProjectCard projectCard = new ProjectCard(projectId, title, status, description, startDate, hours);
                    flpProjects.Controls.Add(projectCard);
                    count++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal void LoadReviews(string id)
        {
            try
            {
                string query = $"SELECT R.ReviewID,R.Comment, U.Name AS ReviewerName, U.ProfileImg FROM Reviews R JOIN Projects P ON R.ProjectID = P.ProjectID JOIN Users U ON R.ReviewerID = U.UserID WHERE (P.FreelancerID = 3) ORDER BY R.ReviewID DESC;";
                var response = Main.DB.ExecuteQueryTable(query);
                int count = 0;
                while (count < response.Rows.Count)
                {
                    ReviewCard reviewCard = new ReviewCard(
                        response.Rows[count]["ReviewID"].ToString(),
                        response.Rows[count]["ReviewerName"].ToString(),
                        response.Rows[count]["Comment"].ToString(),
                        response.Rows[count]["ProfileImg"].ToString()
                        );
                    flpReviews.Controls.Add(reviewCard);
                    count++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHire_Click(object sender, EventArgs e)
        {
            Main.FreelancerHiringPage = new FreelancerHiringPage(freelancerId);
            Main.ChangeWindow(Main.FreelancerHiringPage);
        }
    }
}
