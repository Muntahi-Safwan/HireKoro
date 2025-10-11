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
    public partial class FreelancerHiredSuccesfullyPage : UserControl
    {
        public FreelancerHiredSuccesfullyPage()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Main.ClientHomePage = new ClientHomePage();
            Main.ChangeWindow(Main.ClientHomePage);
            Main.TopLabelText.Text = "Client - Home";
        }
    }
}
