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
    public partial class ReviewCard : UserControl
    {
        public ReviewCard()
        {
            InitializeComponent();
        }
        public ReviewCard(string id, string reviewerName, string reviewText, String profileImg) : this()
        {
            this.lblName.Text = reviewerName;
            this.lblComment.Text = reviewText;
        }
    }
}
