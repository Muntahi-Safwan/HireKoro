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
                string query = "Select * FROM USERS WHERE UserTypeID=2\r\n";
                var response = Main.DB.ExecuteQueryTable(query);
                int count = 0;
                while(count < response.Rows.Count)
                {
                    count++;
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
