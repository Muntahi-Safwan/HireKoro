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
    public partial class AdminReviews : UserControl
    {
        public AdminReviews()
        {
            InitializeComponent();
            this.LoadReviews();

        }

        internal void LoadReviews(string query = "SELECT R.ReviewID,U.Name, P.Title,R.Rating,R.Comment FROM REVIEWS AS R,PROJECTS AS P,Users as U WHERE R.ProjectID= P.ProjectID AND R.ReviewerID=U.UserID")
        {
            try
            {

                var response = Main.DB.ExecuteQueryTable(query);
                dgvReviews.DataSource = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading projects: " + ex.Message);
            }
        }




    }
}
