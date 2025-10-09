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

        internal void LoadReviews()
        {
            try
            {
                string query = "SELECTS * FROM REVIEWS";
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
