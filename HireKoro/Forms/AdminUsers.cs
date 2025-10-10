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
    public partial class AdminUsers : UserControl
    {
        public AdminUsers()
        {
            InitializeComponent();
            this.LoadUsers();
            this.load_USER_TYPE();
        }
        internal void LoadUsers(string query = "Select * from Users")

        {
            try
            {
                var response = Main.DB.ExecuteQueryTable(query);
                dgvUsers.DataSource = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading projects: " + ex.Message);
            }
        }

       

        internal void Clearall()
        {
            this.txtUserID.Clear();
            this.cmbprojectn.SelectedIndex = -1;
            this.txtUsername.Clear();
            this.txtemail.Clear();
            this.txtPasswordHash.Clear();
            this.txtname.Clear();
            this.txtProfilelmg.Clear();
            this.txtdescription.Clear();   
            this.txtHourlyrate.Clear();
            this.txtSkills.Clear();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clearall();
        }

        private void load_USER_TYPE(string query = "select  * from USER_TYPES")
        {

            try
            {
                var DT = Main.DB.ExecuteQueryTable(query);
                this.cmbprojectn.DataSource = DT;
                this.cmbprojectn.DisplayMember = "TypeName";
                this.cmbprojectn.ValueMember = "UserTypeID";


            }
            catch (Exception ex) { MessageBox.Show($"ERROR {ex.Message}"); }
        }

        private void dgvUsers_DoubleClick(object sender, EventArgs e)
        {
            this.txtUserID.Text = this.dgvUsers.CurrentRow.Cells["UserID"].Value.ToString();
            this.txtUsername.Text = this.dgvUsers.CurrentRow.Cells["Username"].Value.ToString();
            this.txtemail.Text = this.dgvUsers.CurrentRow.Cells["Email"].Value.ToString();
            this.txtPasswordHash.Text = this.dgvUsers.CurrentRow.Cells["PasswordHash"].Value.ToString();
            this.txtname.Text = this.dgvUsers.CurrentRow.Cells["Nameu"].Value.ToString();
            this.txtProfilelmg.Text = this.dgvUsers.CurrentRow.Cells["ProfileImg"].Value.ToString();
            this.txtdescription.Text = this.dgvUsers.CurrentRow.Cells["Description"].Value.ToString();
            this.txtHourlyrate.Text = this.dgvUsers.CurrentRow.Cells["HourlyRate"].Value.ToString();
            this.txtSkills.Text = this.dgvUsers.CurrentRow.Cells["Skills"].Value.ToString();



        }

        private void txtScearch_TextChanged(object sender, EventArgs e)
        {
            string query = $"Select * from Users where UserID like '{this.txtScearch.Text}%' or Name like '{this.txtScearch.Text}%'";
            this.LoadUsers(query);
        }

        
        private void CreateProject()
        {
            try
            {
                string query = $@"INSERT INTO USERS (UserTypeID, Username, Email, 
                                 PasswordHash, Name,ProfileImg,Description,HourlyRate,Skills,CreatedAt) 
                                 VALUES ('{cmbprojectn.SelectedValue.ToString()}','{txtUsername.Text}', 
                                 '{txtemail.Text}','{txtPasswordHash.Text}','{txtname.Text}', '{txtProfilelmg.Text}','{txtdescription.Text}','{txtHourlyrate.Text}','{txtSkills.Text}','{DateTime.Now:yyyy-MM-dd}')";

                Main.DB.ExecuteDMLQuery(query);
                MessageBox.Show("Project created successfully!");
                LoadUsers();
                Clearall();
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
                string query = $@"UPDATE USERS SET 
                                
                                 UserTypeID = '{cmbprojectn.SelectedValue.ToString()}',
                                 Username = '{txtUsername.Text}',
                                 Email= '{txtemail.Text}',
                                 PasswordHash = '{txtPasswordHash.Text}',
                                 Name = '{txtname.Text}',
                                 ProfileImg ='{txtProfilelmg.Text}',
                                 Description= '{txtdescription.Text}',
                                 HourlyRate='{txtHourlyrate.Text}',
                                 skills='{txtSkills.Text}'
                                 WHERE UserID = '{txtUserID.Text}'";

                Main.DB.ExecuteDMLQuery(query);
                MessageBox.Show("Project updated successfully!");
                LoadUsers();
                Clearall();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating project: " + ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool isUpdateMode = !string.IsNullOrEmpty(txtUserID.Text.Trim());

            if (isUpdateMode)
            {
                UpdateProject();
            }
            else
            {
                CreateProject();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.txtUserID.Text = this.dgvUsers.CurrentRow.Cells["UserID"].Value.ToString();
            try
            {
                string query = $"DELETE FROM USERS WHERE UserID = {this.txtUserID.Text};";
                var response = Main.DB.ExecuteDMLQuery(query);
                dgvUsers.DataSource = response;
                this.LoadUsers();
                MessageBox.Show("USERS deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting projects: " + ex.Message);
            }
        }
    }
}
