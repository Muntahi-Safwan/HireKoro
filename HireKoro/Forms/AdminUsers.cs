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
        }
        internal void LoadUsers()
        {
            try
            {
                string query = "Select * from Users";
                var response = Main.DB.ExecuteQueryTable(query);
                dgvUsers.DataSource = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading projects: " + ex.Message);
            }
        }
    }
}
