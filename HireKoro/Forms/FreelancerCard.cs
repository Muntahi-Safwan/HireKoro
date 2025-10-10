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
    public partial class FreelancerCard : UserControl
    {
        string freelancerId { set; get; }
        string freelancerName { set; get; }
        string description { set; get; }
        string skills { set; get; }
        //string rating { set; get; }
        float hourlyRate { set; get; }


        public FreelancerCard()
        {
            InitializeComponent();
        }
        public FreelancerCard(string id, string name, string description, string skills, float hourlyRate)
        {
            InitializeComponent();
            this.freelancerId = id;
            this.lblFreelancerName.Text = name;
            this.lblDescription.Text = description;
            this.lblSkills.Text = skills;
            //this.lblRating.Text = rate;
            this.lblHourlyRate.Text = $"${hourlyRate}/hr";
        }

        private void lblDetails_Click(object sender, EventArgs e)
        {
            Main.FreelancerDetailsPage = new FreelancerDetailsPage(freelancerId);
            Main.ChangeWindow(Main.FreelancerDetailsPage);

        }
    }
}
