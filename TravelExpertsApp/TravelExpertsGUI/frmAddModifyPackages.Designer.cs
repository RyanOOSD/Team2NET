namespace TravelExpertsGUI
{
    partial class frmAddModifyPackages
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPkgName = new Label();
            txtPkgName = new TextBox();
            dtpPkgStartDate = new DateTimePicker();
            lblPkgStartDate = new Label();
            dtpPkgEndDate = new DateTimePicker();
            lblPkgEndDate = new Label();
            lblPkgDesc = new Label();
            txtPkgDesc = new TextBox();
            lblPkgBasePrice = new Label();
            txtPkgBasePrice = new TextBox();
            lblAgencyCommission = new Label();
            txtAgencyCommission = new TextBox();
            btnSubmit = new Button();
            btnCancel = new Button();
            lblPkgID = new Label();
            txtPkgID = new TextBox();
            SuspendLayout();
            // 
            // lblPkgName
            // 
            lblPkgName.AutoSize = true;
            lblPkgName.Location = new Point(43, 67);
            lblPkgName.Name = "lblPkgName";
            lblPkgName.Size = new Size(89, 15);
            lblPkgName.TabIndex = 0;
            lblPkgName.Text = "Package Name:";
            // 
            // txtPkgName
            // 
            txtPkgName.Location = new Point(138, 59);
            txtPkgName.Name = "txtPkgName";
            txtPkgName.Size = new Size(211, 23);
            txtPkgName.TabIndex = 1;
            // 
            // dtpPkgStartDate
            // 
            dtpPkgStartDate.Location = new Point(138, 102);
            dtpPkgStartDate.Name = "dtpPkgStartDate";
            dtpPkgStartDate.Size = new Size(211, 23);
            dtpPkgStartDate.TabIndex = 2;
            // 
            // lblPkgStartDate
            // 
            lblPkgStartDate.AutoSize = true;
            lblPkgStartDate.Location = new Point(71, 110);
            lblPkgStartDate.Name = "lblPkgStartDate";
            lblPkgStartDate.Size = new Size(61, 15);
            lblPkgStartDate.TabIndex = 3;
            lblPkgStartDate.Text = "Start Date:";
            // 
            // dtpPkgEndDate
            // 
            dtpPkgEndDate.Location = new Point(138, 148);
            dtpPkgEndDate.Name = "dtpPkgEndDate";
            dtpPkgEndDate.Size = new Size(211, 23);
            dtpPkgEndDate.TabIndex = 4;
            // 
            // lblPkgEndDate
            // 
            lblPkgEndDate.AutoSize = true;
            lblPkgEndDate.Location = new Point(75, 154);
            lblPkgEndDate.Name = "lblPkgEndDate";
            lblPkgEndDate.Size = new Size(57, 15);
            lblPkgEndDate.TabIndex = 5;
            lblPkgEndDate.Text = "End Date:";
            // 
            // lblPkgDesc
            // 
            lblPkgDesc.AutoSize = true;
            lblPkgDesc.Location = new Point(62, 199);
            lblPkgDesc.Name = "lblPkgDesc";
            lblPkgDesc.Size = new Size(70, 15);
            lblPkgDesc.TabIndex = 6;
            lblPkgDesc.Text = "Description:";
            // 
            // txtPkgDesc
            // 
            txtPkgDesc.Location = new Point(138, 196);
            txtPkgDesc.Multiline = true;
            txtPkgDesc.Name = "txtPkgDesc";
            txtPkgDesc.Size = new Size(211, 54);
            txtPkgDesc.TabIndex = 7;
            // 
            // lblPkgBasePrice
            // 
            lblPkgBasePrice.AutoSize = true;
            lblPkgBasePrice.Location = new Point(69, 278);
            lblPkgBasePrice.Name = "lblPkgBasePrice";
            lblPkgBasePrice.Size = new Size(63, 15);
            lblPkgBasePrice.TabIndex = 8;
            lblPkgBasePrice.Text = "Base Price:";
            // 
            // txtPkgBasePrice
            // 
            txtPkgBasePrice.Location = new Point(138, 270);
            txtPkgBasePrice.Name = "txtPkgBasePrice";
            txtPkgBasePrice.Size = new Size(100, 23);
            txtPkgBasePrice.TabIndex = 9;
            // 
            // lblAgencyCommission
            // 
            lblAgencyCommission.AutoSize = true;
            lblAgencyCommission.Location = new Point(12, 325);
            lblAgencyCommission.Name = "lblAgencyCommission";
            lblAgencyCommission.Size = new Size(120, 15);
            lblAgencyCommission.TabIndex = 10;
            lblAgencyCommission.Text = "Agency Commission:";
            // 
            // txtAgencyCommission
            // 
            txtAgencyCommission.Location = new Point(138, 317);
            txtAgencyCommission.Name = "txtAgencyCommission";
            txtAgencyCommission.Size = new Size(100, 23);
            txtAgencyCommission.TabIndex = 11;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(138, 373);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 12;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(274, 373);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblPkgID
            // 
            lblPkgID.AutoSize = true;
            lblPkgID.Location = new Point(64, 20);
            lblPkgID.Name = "lblPkgID";
            lblPkgID.Size = new Size(68, 15);
            lblPkgID.TabIndex = 14;
            lblPkgID.Text = "Package ID:";
            // 
            // txtPkgID
            // 
            txtPkgID.Enabled = false;
            txtPkgID.Location = new Point(138, 12);
            txtPkgID.Name = "txtPkgID";
            txtPkgID.ReadOnly = true;
            txtPkgID.Size = new Size(63, 23);
            txtPkgID.TabIndex = 15;
            txtPkgID.TextAlign = HorizontalAlignment.Center;
            // 
            // frmAddModifyPackages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(361, 408);
            Controls.Add(txtPkgID);
            Controls.Add(lblPkgID);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(txtAgencyCommission);
            Controls.Add(lblAgencyCommission);
            Controls.Add(txtPkgBasePrice);
            Controls.Add(lblPkgBasePrice);
            Controls.Add(txtPkgDesc);
            Controls.Add(lblPkgDesc);
            Controls.Add(lblPkgEndDate);
            Controls.Add(dtpPkgEndDate);
            Controls.Add(lblPkgStartDate);
            Controls.Add(dtpPkgStartDate);
            Controls.Add(txtPkgName);
            Controls.Add(lblPkgName);
            Name = "frmAddModifyPackages";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddModifyPackages";
            Load += frmAddModifyPackages_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPkgName;
        private TextBox txtPkgName;
        private DateTimePicker dtpPkgStartDate;
        private Label lblPkgStartDate;
        private DateTimePicker dtpPkgEndDate;
        private Label lblPkgEndDate;
        private Label lblPkgDesc;
        private TextBox txtPkgDesc;
        private Label lblPkgBasePrice;
        private TextBox txtPkgBasePrice;
        private Label lblAgencyCommission;
        private TextBox txtAgencyCommission;
        private Button btnSubmit;
        private Button btnCancel;
        private Label lblPkgID;
        private TextBox txtPkgID;
    }
}