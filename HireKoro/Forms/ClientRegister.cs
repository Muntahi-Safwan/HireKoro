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
    public partial class ClientRegister : UserControl
    {
        public ClientRegister()
        {
            InitializeComponent();
        }

        private void btnClientCreate_Click(object sender, EventArgs e)
        {
            Main.ClientHomePage = new ClientHomePage();
            Main.ChangeWindow(Main.ClientHomePage);
            Main.SidePanel.Visible = true;
        }
    }
}
