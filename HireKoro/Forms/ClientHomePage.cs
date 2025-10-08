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
            try
            {
                string query = "Select COUNT(*) FROM USERS WHERE UserTypeID=2";
                var response = Main.DB.ExecuteQuery(query);
                int count = 0;
                foreach (DataRow row in response.Rows)
                {
                    count++;
                }
                for (int i = 0; i < count; i++)
                {
                    FreelancerCard freelancerCard = new FreelancerCard();
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
