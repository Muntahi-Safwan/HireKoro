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
    public partial class MessageContainer : UserControl
    {
        internal string receverID {  get; set; }
        public MessageContainer()
        {
            InitializeComponent();
        }
        public MessageContainer(String ReceverID, String Name , String Message, String Time) :this()
        {
            this.lblName.Text = Name;
            this.lblTime.Text = Time;
            this.receverID = ReceverID;
        }

        private void pnlMessages_Click(object sender, EventArgs e)
        {
            MessagesPage.ReceverID = receverID;
            MessagesPage.ReceverName.Text = this.lblName.Text;
            MessagesPage.Chats();
        }
    }
}
