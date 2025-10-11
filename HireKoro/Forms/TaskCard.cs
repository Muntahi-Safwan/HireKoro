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
    public partial class TaskCard : UserControl
    {
        public TaskCard()
        {
            InitializeComponent();
        }
        public TaskCard(string taskId, string taskName, string taskDescrption, string status, DateTime deadline): this()
        {
            this.lblName.Text = taskName;
            this.lblDescription.Text = taskDescrption;
            this.lblDeadline.Text = deadline.ToShortDateString();
            this.btnStatus.Text = status;
        }
    }
}
