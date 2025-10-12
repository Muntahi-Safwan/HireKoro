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
    public partial class ChatBubble : UserControl
    {
        public ChatBubble()
        {
            InitializeComponent();
        }
        public ChatBubble(String Message,String Name, string Time) : this()
        {
            this.lblMessage.Text = Message;
            this.lblName.Text = Name;
            this.lblTime.Text = Time;
        }
    }
}
