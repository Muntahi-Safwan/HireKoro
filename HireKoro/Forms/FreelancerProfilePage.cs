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

                this.txtName.Text = response.Rows[0]["Name"].ToString();
                this.txtDescription.Text = response.Rows[0]["Description"].ToString();
                this.txtUsername.Text = response.Rows[0]["username"].ToString();
                this.txtDescription.Text = response.Rows[0]["Description"].ToString();
                this.txtDescription.Text = response.Rows[0]["Description"].ToString();


            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        
    }
}
