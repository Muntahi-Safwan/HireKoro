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
        public MessageContainer()
        {
            InitializeComponent();
        }
        public MessageContainer(String Name , String Message, String Time) :this()
        {
            this.lblName.Text = Name;
            this.lblMessage.Text = Message;
            this.lblTime.Text = Time;
        }
    }
}
