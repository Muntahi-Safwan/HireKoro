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
        internal void Clearall()
        {
            this.txtReviewID.Clear();
            this.txtProjectName.Clear();
            this.txtReviewTitle.Clear();
            this.txtRating.Clear();
            this.txtComment.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clearall();
        }

        private void dgvReviews_DoubleClick(object sender, EventArgs e)
        {
            this.txtReviewID.Text = this.dgvReviews.CurrentRow.Cells["ReviewID"].Value.ToString();
            this.txtProjectName.Text = this.dgvReviews.CurrentRow.Cells["ProjectID"].Value.ToString();
            this.txtReviewTitle.Text = this.dgvReviews.CurrentRow.Cells["Title"].Value.ToString();
            this.txtRating.Text = this.dgvReviews.CurrentRow.Cells["Rating"].Value.ToString();
            this.txtComment.Text = this.dgvReviews.CurrentRow.Cells["Comment"].Value.ToString();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            // Check if ProjectID field has a value to determine create vs update mode
            bool isUpdateMode = !string.IsNullOrEmpty(txtReviewID.Text.Trim());

            if (isUpdateMode)
            {
                UpdateReview();
            }
            else
            {
                CreateReview();
            }
        }

        private void CreateReview()
        {
            try
            {
                string query = $@"insert into REVIEWS (ProjectID,ReviewerID,Rating,Comment)VALUES ( '{txtProjectName.Text}', '{txtReviewTitle.Text}', 
                                 '{txtRating.Text}', '{txtComment.Text}')";

                Main.DB.ExecuteDMLQuery(query);
                MessageBox.Show("Review created successfully!");
                LoadReviews();
                Clearall();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating Review: " + ex.Message);
            }
        }

        private void UpdateReview()
        {
            try
            {
                string query = $@"UPDATE Reviews SET 
                                
                                 Name = '{txtProjectName.Text}',
                                 Title = '{txtReviewTitle.Text}',
                                 Rating = '{txtRating.Text}',
                                 Comment = '{txtComment.Text}',
                                 WHERE ReviewID = {txtReviewID.Text}";

                Main.DB.ExecuteDMLQuery(query);
                MessageBox.Show("Review updated successfully!");
                LoadReviews();
                Clearall();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Review: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.txtReviewID.Text = this.dgvReviews.CurrentRow.Cells["ReviewID"].Value.ToString();
            try
            {
                string query = $"DELETE FROM PROJECTS WHERE ReviewID = {this.txtReviewID.Text};";
                var response = Main.DB.ExecuteDMLQuery(query);
                dgvReviews.DataSource = response;
                this.LoadReviews();
                MessageBox.Show("Review deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting Reviews: " + ex.Message);
            }
        }
    }
}
