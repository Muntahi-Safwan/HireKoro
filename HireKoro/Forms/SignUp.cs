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
    public partial class SignUp : UserControl
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnFreelancerSelect_Click(object sender, EventArgs e)
        {
            Main.FreelancerRegisterPage = new FreelancerRegister();
            Main.ChangeWindow(Main.FreelancerRegisterPage);
        }

        private void btnClientSelect_Click(object sender, EventArgs e)
        {
            Main.ClientRegisterPage = new ClientRegister();
            Main.ChangeWindow(Main.ClientRegisterPage);
        }
    }
}
