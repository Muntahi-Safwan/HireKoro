namespace HireKoro.Forms
{
    partial class MessageContainer
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
            this.pnlMessages = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMessages
            // 
            this.pnlMessages.BackColor = System.Drawing.Color.Transparent;
            this.pnlMessages.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.pnlMessages.BorderRadius = 12;
            this.pnlMessages.BorderThickness = 1;
            this.pnlMessages.Controls.Add(this.lblTime);
            this.pnlMessages.Controls.Add(this.lblName);
            this.pnlMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessages.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.pnlMessages.Location = new System.Drawing.Point(0, 0);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Size = new System.Drawing.Size(229, 73);
            this.pnlMessages.TabIndex = 0;
            this.pnlMessages.Click += new System.EventHandler(this.pnlMessages_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTime.Location = new System.Drawing.Point(97, 54);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(27, 12);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "time";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTime.Click += new System.EventHandler(this.pnlMessages_Click);
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(16, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(198, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            this.lblName.Click += new System.EventHandler(this.pnlMessages_Click);
            // 
            // MessageContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.pnlMessages);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Name = "MessageContainer";
            this.Size = new System.Drawing.Size(229, 73);
            this.pnlMessages.ResumeLayout(false);
            this.pnlMessages.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMessages;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTime;
    }
}
