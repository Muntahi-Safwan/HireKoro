namespace HireKoro.Forms
{
    partial class PaymentPage
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
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnPayment = new Guna.UI2.WinForms.Guna2Button();
            this.txtExpiry = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCVC = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCardNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHolderName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.guna2Panel1);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(22)))), ((int)(((byte)(26)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(58)))), ((int)(((byte)(82)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(929, 661);
            this.guna2GradientPanel1.TabIndex = 7;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.guna2Panel1.BorderRadius = 12;
            this.guna2Panel1.Controls.Add(this.btnPayment);
            this.guna2Panel1.Controls.Add(this.txtExpiry);
            this.guna2Panel1.Controls.Add(this.txtCVC);
            this.guna2Panel1.Controls.Add(this.label8);
            this.guna2Panel1.Controls.Add(this.label7);
            this.guna2Panel1.Controls.Add(this.label6);
            this.guna2Panel1.Controls.Add(this.txtCardNumber);
            this.guna2Panel1.Controls.Add(this.label9);
            this.guna2Panel1.Controls.Add(this.txtHolderName);
            this.guna2Panel1.Controls.Add(this.lblDueDate);
            this.guna2Panel1.Controls.Add(this.lblIssueDate);
            this.guna2Panel1.Controls.Add(this.lblAmount);
            this.guna2Panel1.Controls.Add(this.lblProjectName);
            this.guna2Panel1.Controls.Add(this.lblInvoiceID);
            this.guna2Panel1.Location = new System.Drawing.Point(54, 21);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(821, 619);
            this.guna2Panel1.TabIndex = 1;
            // 
            // btnPayment
            // 
            this.btnPayment.BorderRadius = 12;
            this.btnPayment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPayment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPayment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(208)))), ((int)(((byte)(253)))));
            this.btnPayment.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.btnPayment.ForeColor = System.Drawing.Color.Black;
            this.btnPayment.Location = new System.Drawing.Point(60, 526);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(160, 44);
            this.btnPayment.TabIndex = 74;
            this.btnPayment.Text = "Make Payment";
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // txtExpiry
            // 
            this.txtExpiry.BackColor = System.Drawing.Color.Transparent;
            this.txtExpiry.BorderRadius = 12;
            this.txtExpiry.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtExpiry.DefaultText = "  12/03/25";
            this.txtExpiry.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtExpiry.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtExpiry.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtExpiry.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtExpiry.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.txtExpiry.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtExpiry.Font = new System.Drawing.Font("Poppins", 12F);
            this.txtExpiry.ForeColor = System.Drawing.Color.White;
            this.txtExpiry.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtExpiry.Location = new System.Drawing.Point(60, 435);
            this.txtExpiry.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.PlaceholderText = "Number Of Hours";
            this.txtExpiry.SelectedText = "";
            this.txtExpiry.Size = new System.Drawing.Size(256, 56);
            this.txtExpiry.TabIndex = 73;
            // 
            // txtCVC
            // 
            this.txtCVC.BackColor = System.Drawing.Color.Transparent;
            this.txtCVC.BorderRadius = 12;
            this.txtCVC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCVC.DefaultText = "  \r\n000";
            this.txtCVC.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCVC.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCVC.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCVC.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCVC.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.txtCVC.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCVC.Font = new System.Drawing.Font("Poppins", 12F);
            this.txtCVC.ForeColor = System.Drawing.Color.White;
            this.txtCVC.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCVC.Location = new System.Drawing.Point(340, 435);
            this.txtCVC.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtCVC.Name = "txtCVC";
            this.txtCVC.PlaceholderText = "Number Of Hours";
            this.txtCVC.SelectedText = "";
            this.txtCVC.Size = new System.Drawing.Size(256, 56);
            this.txtCVC.TabIndex = 72;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.label8.Location = new System.Drawing.Point(336, 406);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 23);
            this.label8.TabIndex = 71;
            this.label8.Text = "CVC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.label7.Location = new System.Drawing.Point(59, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 23);
            this.label7.TabIndex = 70;
            this.label7.Text = "Expiry Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.label6.Location = new System.Drawing.Point(59, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 23);
            this.label6.TabIndex = 69;
            this.label6.Text = "VISA / MasterCard Card Number";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtCardNumber.BorderRadius = 12;
            this.txtCardNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCardNumber.DefaultText = "  0000 0000 0000 0000";
            this.txtCardNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCardNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCardNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCardNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCardNumber.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.txtCardNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCardNumber.Font = new System.Drawing.Font("Poppins", 12F);
            this.txtCardNumber.ForeColor = System.Drawing.Color.White;
            this.txtCardNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCardNumber.Location = new System.Drawing.Point(60, 330);
            this.txtCardNumber.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.PlaceholderText = "Short Project Description";
            this.txtCardNumber.SelectedText = "";
            this.txtCardNumber.Size = new System.Drawing.Size(536, 70);
            this.txtCardNumber.TabIndex = 68;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.label9.Location = new System.Drawing.Point(59, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 23);
            this.label9.TabIndex = 67;
            this.label9.Text = "Card Holder Name";
            // 
            // txtHolderName
            // 
            this.txtHolderName.BackColor = System.Drawing.Color.Transparent;
            this.txtHolderName.BorderRadius = 12;
            this.txtHolderName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHolderName.DefaultText = "   John Doe";
            this.txtHolderName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtHolderName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtHolderName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHolderName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHolderName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.txtHolderName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHolderName.Font = new System.Drawing.Font("Poppins", 12F);
            this.txtHolderName.ForeColor = System.Drawing.Color.White;
            this.txtHolderName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHolderName.Location = new System.Drawing.Point(60, 239);
            this.txtHolderName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtHolderName.Name = "txtHolderName";
            this.txtHolderName.PlaceholderText = "Name Of The Project";
            this.txtHolderName.SelectedText = "";
            this.txtHolderName.Size = new System.Drawing.Size(536, 56);
            this.txtHolderName.TabIndex = 66;
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDate.Font = new System.Drawing.Font("Poppins Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.ForeColor = System.Drawing.Color.White;
            this.lblDueDate.Location = new System.Drawing.Point(56, 163);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(239, 34);
            this.lblDueDate.TabIndex = 24;
            this.lblDueDate.Text = "Due Date: 12/07/2025";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblIssueDate.Font = new System.Drawing.Font("Poppins Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.ForeColor = System.Drawing.Color.White;
            this.lblIssueDate.Location = new System.Drawing.Point(55, 129);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(253, 34);
            this.lblIssueDate.TabIndex = 23;
            this.lblIssueDate.Text = "Issue Date: 12/07/2025";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblAmount.Font = new System.Drawing.Font("Poppins Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.White;
            this.lblAmount.Location = new System.Drawing.Point(56, 97);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(168, 34);
            this.lblAmount.TabIndex = 22;
            this.lblAmount.Text = "Amount: $1250";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.BackColor = System.Drawing.Color.Transparent;
            this.lblProjectName.Font = new System.Drawing.Font("Poppins Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.ForeColor = System.Drawing.Color.White;
            this.lblProjectName.Location = new System.Drawing.Point(56, 66);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(162, 34);
            this.lblProjectName.TabIndex = 21;
            this.lblProjectName.Text = "Project Name:";
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.BackColor = System.Drawing.Color.Transparent;
            this.lblInvoiceID.Font = new System.Drawing.Font("Poppins", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceID.ForeColor = System.Drawing.Color.White;
            this.lblInvoiceID.Location = new System.Drawing.Point(50, 12);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.Size = new System.Drawing.Size(198, 56);
            this.lblInvoiceID.TabIndex = 20;
            this.lblInvoiceID.Text = "Invoice ID: ";
            // 
            // PaymentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "PaymentPage";
            this.Size = new System.Drawing.Size(929, 661);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblInvoiceID;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblAmount;
        private Guna.UI2.WinForms.Guna2TextBox txtExpiry;
        private Guna.UI2.WinForms.Guna2TextBox txtCVC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtCardNumber;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtHolderName;
        private Guna.UI2.WinForms.Guna2Button btnPayment;
    }
}
