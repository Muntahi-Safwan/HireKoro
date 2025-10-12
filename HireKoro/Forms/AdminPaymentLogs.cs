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
    public partial class AdminPaymentLogs : UserControl
    {
        public AdminPaymentLogs()
        {
            
            InitializeComponent();
            LoadPaymentLogs();
        }

        internal void LoadPaymentLogs(string query = "select * from PaymentLog")
        {
            try
            {
                
                var response = Main.DB.ExecuteQueryTable(query);
                dgvPayment.DataSource = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading projects: " + ex.Message);
            }
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            Main.AdminProjectLogPage = new AdminProjectLogs();
            Main.ChangeWindow(Main.AdminProjectLogPage);
        }
    }
}
