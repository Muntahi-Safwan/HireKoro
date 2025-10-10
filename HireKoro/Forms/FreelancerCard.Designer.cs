namespace HireKoro.Forms
{
    partial class FreelancerCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblFreelancerName = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblSkills = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblHourlyRate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(17, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(76, 63);
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // lblFreelancerName
            // 
            this.lblFreelancerName.AutoSize = true;
            this.lblFreelancerName.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreelancerName.ForeColor = System.Drawing.Color.White;
            this.lblFreelancerName.Location = new System.Drawing.Point(3, 74);
            this.lblFreelancerName.Name = "lblFreelancerName";
            this.lblFreelancerName.Size = new System.Drawing.Size(61, 19);
            this.lblFreelancerName.TabIndex = 1;
            this.lblFreelancerName.Text = "John Doe";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.lblRating.Font = new System.Drawing.Font("Poppins", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.lblRating.Location = new System.Drawing.Point(7, 129);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(50, 14);
            this.lblRating.TabIndex = 2;
            this.lblRating.Text = "Rating: 4/5";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Poppins Thin", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(6, 90);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(103, 14);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "I am a Professional UI/UX ";
            // 
            // lblSkills
            // 
            this.lblSkills.AutoSize = true;
            this.lblSkills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.lblSkills.Font = new System.Drawing.Font("Poppins Medium", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkills.ForeColor = System.Drawing.Color.White;
            this.lblSkills.Location = new System.Drawing.Point(6, 108);
            this.lblSkills.Name = "lblSkills";
            this.lblSkills.Size = new System.Drawing.Size(66, 14);
            this.lblSkills.TabIndex = 5;
            this.lblSkills.Text = "Skills: UI/UX";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(208)))), ((int)(((byte)(253)))));
            this.lblDetails.Font = new System.Drawing.Font("Poppins", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(37)))), ((int)(((byte)(44)))));
            this.lblDetails.Location = new System.Drawing.Point(49, 152);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(55, 14);
            this.lblDetails.TabIndex = 7;
            this.lblDetails.Text = "View Details";
            this.lblDetails.Click += new System.EventHandler(this.lblDetails_Click);
            // 
            // lblHourlyRate
            // 
            this.lblHourlyRate.BackColor = System.Drawing.Color.Transparent;
            this.lblHourlyRate.Font = new System.Drawing.Font("Poppins SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHourlyRate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblHourlyRate.Location = new System.Drawing.Point(9, 147);
            this.lblHourlyRate.Name = "lblHourlyRate";
            this.lblHourlyRate.Size = new System.Drawing.Size(29, 25);
            this.lblHourlyRate.TabIndex = 8;
            this.lblHourlyRate.Text = "$40";
            // 
            // FreelancerCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(13)))), ((int)(((byte)(9)))), ((int)(((byte)(54)))));
            this.Controls.Add(this.lblHourlyRate);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblSkills);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblFreelancerName);
            this.Controls.Add(this.guna2PictureBox1);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "FreelancerCard";
            this.Size = new System.Drawing.Size(112, 175);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label lblFreelancerName;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblSkills;
        private System.Windows.Forms.Label lblDetails;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHourlyRate;
    }
}
