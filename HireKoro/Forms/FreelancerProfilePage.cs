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
    public partial class FreelancerProfilePage : UserControl
    {
        public FreelancerProfilePage()
        {
            InitializeComponent();
            this.loadUserInfo(Main.CurrentUserId);  
        }

        public void loadUserInfo(string userId)
        {
            try
            {
                string query = $"SELECT * FROM USERS WHERE USERID={userId}";
                var response = Main.DB.ExecuteQueryTable(query);
                if(response.Rows.Count == 0)
                {
                    MessageBox.Show("User Not Found", "Sorry the user was not found in the database or there might be some issue in connection");
                    return;
                }

                this.txtName.Text = response.Rows[0]["Name"].ToString() ;
                this.txtDescription.Text = response.Rows[0]["Description"].ToString();
                this.txtUsername.Text = response.Rows[0]["username"].ToString();
                this.txtEmail.Text = response.Rows[0]["Email"].ToString();
                this.txtSkills.Text = response.Rows[0]["Skills"].ToString();
                this.txtHourlyRate.Text = response.Rows[0]["HourlyRate"].ToString();


            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = this.txtName.Text;
            string description = this.txtDescription.Text;
            string email = this.txtEmail.Text;
            string skills = this.txtSkills.Text;
            string hourlyRate = this.txtHourlyRate.Text;
            string userId = Main.CurrentUserId;
            try
            {
                string query = $"UPDATE USERS SET Name='{name}', Description='{description}', Email={email}, Skills='{skills}', HourlyRate={hourlyRate} WHERE UserID={userId}";
                int response = Main.DB.ExecuteDMLQuery(query);
                if(response == 1)
                {
                    MessageBox.Show("Profile Updated Successfully", "Success");
                } else
                {
                    MessageBox.Show("Profile Update Failed", "Failed");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
