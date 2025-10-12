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
    public partial class ClientHomePage : UserControl
    {
        public ClientHomePage()
        {
            InitializeComponent();
        }

        private void ClientHomePage_Load(object sender, EventArgs e)
        {
           this.LoadFreelancers();
             
        }

        private void txtSearchCP_TextChanged(object sender, EventArgs e)
        {
            string query = $"Select * from Users where UserTypeID ='2' and (UserID like '{this.txtSearchCP.Text}%' or Name like '{this.txtSearchCP.Text}%')";
            this.LoadFreelancers(query);
        }

        private void LoadFreelancers(string query = "Select * FROM USERS WHERE UserTypeID=2")
        {
            try
            {
               
                var response = Main.DB.ExecuteQueryTable(query);
                int count = 0;
                while (count < response.Rows.Count)
                {
                    count++;
                    FreelancerCard freelancerCard = new FreelancerCard(
                        response.Rows[count - 1]["UserID"].ToString(),
                        response.Rows[count - 1]["Name"].ToString(),
                        response.Rows[count - 1]["Description"].ToString(),
                        response.Rows[count - 1]["Skills"].ToString(),
                        //response.Rows[count - 1]["Rating"].ToString(),
                        float.Parse(response.Rows[count - 1]["HourlyRate"].ToString())
                    );
                    flowPanel.Controls.Add(freelancerCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
