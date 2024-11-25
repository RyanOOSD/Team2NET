namespace TravelExpertsGUI
{
    partial class frmAgents
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
            btnManageAgents = new Button();
            btnManageAgencies = new Button();
            label1 = new Label();
            label2 = new Label();
            btnAddLoc = new Button();
            txtAgentID = new TextBox();
            cboAgencyLocation = new ComboBox();
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label12 = new Label();
            label11 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            btnAgentEdit = new Button();
            btnAgentDelete = new Button();
            btnAgentAdd = new Button();
            label1OR = new Label();
            label2OR = new Label();
            btnAgencyEdit = new Button();
            btnAgencyDelete = new Button();
            txtFName = new TextBox();
            txtMiddle = new TextBox();
            txtLName = new TextBox();
            txtAgentPhone = new TextBox();
            txtEmail = new TextBox();
            txtPosition = new TextBox();
            cboAgentLocation = new ComboBox();
            cboCity = new ComboBox();
            txtFax = new TextBox();
            txtAgencyPhone = new TextBox();
            txtPostal = new TextBox();
            txtProvince = new TextBox();
            txtAddress = new TextBox();
            btnGetAgent = new Button();
            btnGetAgency = new Button();
            picAgents = new PictureBox();
            picAgencies = new PictureBox();
            gbAgent = new GroupBox();
            btnAgentAddSave = new Button();
            gbManageAgent = new GroupBox();
            gbManageAgency = new GroupBox();
            gbAgency = new GroupBox();
            btnAddLocSave = new Button();
            ((System.ComponentModel.ISupportInitialize)picAgents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAgencies).BeginInit();
            gbAgent.SuspendLayout();
            gbManageAgent.SuspendLayout();
            gbManageAgency.SuspendLayout();
            gbAgency.SuspendLayout();
            SuspendLayout();
            // 
            // btnManageAgents
            // 
            btnManageAgents.Location = new Point(177, 24);
            btnManageAgents.Name = "btnManageAgents";
            btnManageAgents.Size = new Size(208, 29);
            btnManageAgents.TabIndex = 0;
            btnManageAgents.Text = "Manage Agents";
            btnManageAgents.UseVisualStyleBackColor = true;
            btnManageAgents.Click += btnManageAgents_Click;
            // 
            // btnManageAgencies
            // 
            btnManageAgencies.Location = new Point(713, 24);
            btnManageAgencies.Name = "btnManageAgencies";
            btnManageAgencies.Size = new Size(208, 29);
            btnManageAgencies.TabIndex = 1;
            btnManageAgencies.Text = "Manage Agencies";
            btnManageAgencies.UseVisualStyleBackColor = true;
            btnManageAgencies.Click += btnManageAgencies_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 27);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 2;
            label1.Text = "Agent ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 29);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 3;
            label2.Text = "Select Location:";
            // 
            // btnAddLoc
            // 
            btnAddLoc.Location = new Point(768, 134);
            btnAddLoc.Name = "btnAddLoc";
            btnAddLoc.Size = new Size(151, 29);
            btnAddLoc.TabIndex = 6;
            btnAddLoc.Text = "Add New Agency";
            btnAddLoc.UseVisualStyleBackColor = true;
            btnAddLoc.Click += btnAddLoc_Click;
            // 
            // txtAgentID
            // 
            txtAgentID.Location = new Point(102, 24);
            txtAgentID.Name = "txtAgentID";
            txtAgentID.Size = new Size(125, 27);
            txtAgentID.TabIndex = 7;
            // 
            // cboAgencyLocation
            // 
            cboAgencyLocation.FormattingEnabled = true;
            cboAgencyLocation.Location = new Point(131, 26);
            cboAgencyLocation.Name = "cboAgencyLocation";
            cboAgencyLocation.Size = new Size(123, 28);
            cboAgencyLocation.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 32);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 9;
            label3.Text = "First Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 252);
            label5.Name = "label5";
            label5.Size = new Size(82, 20);
            label5.TabIndex = 10;
            label5.Text = "Last Name:";
            label5.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 218);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 11;
            label4.Text = "Middle Initial:";
            label4.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 138);
            label6.Name = "label6";
            label6.Size = new Size(53, 20);
            label6.TabIndex = 12;
            label6.Text = "Phone:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(33, 181);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 13;
            label7.Text = "Email:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(33, 218);
            label8.Name = "label8";
            label8.Size = new Size(64, 20);
            label8.TabIndex = 14;
            label8.Text = "Position:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(33, 257);
            label9.Name = "label9";
            label9.Size = new Size(69, 20);
            label9.TabIndex = 15;
            label9.Text = "Location:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(39, 34);
            label10.Name = "label10";
            label10.Size = new Size(65, 20);
            label10.TabIndex = 16;
            label10.Text = "Address:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(538, 249);
            label12.Name = "label12";
            label12.Size = new Size(68, 20);
            label12.TabIndex = 17;
            label12.Text = "Province:";
            label12.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(538, 215);
            label11.Name = "label11";
            label11.Size = new Size(37, 20);
            label11.TabIndex = 18;
            label11.Text = "City:";
            label11.Visible = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(39, 140);
            label13.Name = "label13";
            label13.Size = new Size(90, 20);
            label13.TabIndex = 19;
            label13.Text = "Postal Code:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(39, 183);
            label14.Name = "label14";
            label14.Size = new Size(53, 20);
            label14.TabIndex = 20;
            label14.Text = "Phone:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(39, 220);
            label15.Name = "label15";
            label15.Size = new Size(33, 20);
            label15.TabIndex = 21;
            label15.Text = "Fax:";
            // 
            // btnAgentEdit
            // 
            btnAgentEdit.Enabled = false;
            btnAgentEdit.Location = new Point(33, 301);
            btnAgentEdit.Name = "btnAgentEdit";
            btnAgentEdit.Size = new Size(100, 29);
            btnAgentEdit.TabIndex = 22;
            btnAgentEdit.Text = "Edit";
            btnAgentEdit.UseVisualStyleBackColor = true;
            // 
            // btnAgentDelete
            // 
            btnAgentDelete.Enabled = false;
            btnAgentDelete.Location = new Point(139, 301);
            btnAgentDelete.Name = "btnAgentDelete";
            btnAgentDelete.Size = new Size(100, 29);
            btnAgentDelete.TabIndex = 23;
            btnAgentDelete.Text = "Delete";
            btnAgentDelete.UseVisualStyleBackColor = true;
            // 
            // btnAgentAdd
            // 
            btnAgentAdd.Location = new Point(248, 135);
            btnAgentAdd.Name = "btnAgentAdd";
            btnAgentAdd.Size = new Size(151, 29);
            btnAgentAdd.TabIndex = 24;
            btnAgentAdd.Text = "Add New Agent";
            btnAgentAdd.UseVisualStyleBackColor = true;
            btnAgentAdd.Click += btnAgentAdd_Click;
            // 
            // label1OR
            // 
            label1OR.AutoSize = true;
            label1OR.Location = new Point(301, 111);
            label1OR.Name = "label1OR";
            label1OR.Size = new Size(29, 20);
            label1OR.TabIndex = 25;
            label1OR.Text = "OR";
            label1OR.Visible = false;
            // 
            // label2OR
            // 
            label2OR.AutoSize = true;
            label2OR.Location = new Point(826, 111);
            label2OR.Name = "label2OR";
            label2OR.Size = new Size(29, 20);
            label2OR.TabIndex = 26;
            label2OR.Text = "OR";
            label2OR.Visible = false;
            // 
            // btnAgencyEdit
            // 
            btnAgencyEdit.Enabled = false;
            btnAgencyEdit.Location = new Point(39, 301);
            btnAgencyEdit.Name = "btnAgencyEdit";
            btnAgencyEdit.Size = new Size(100, 29);
            btnAgencyEdit.TabIndex = 27;
            btnAgencyEdit.Text = "Edit";
            btnAgencyEdit.UseVisualStyleBackColor = true;
            // 
            // btnAgencyDelete
            // 
            btnAgencyDelete.Enabled = false;
            btnAgencyDelete.Location = new Point(145, 301);
            btnAgencyDelete.Name = "btnAgencyDelete";
            btnAgencyDelete.Size = new Size(100, 29);
            btnAgencyDelete.TabIndex = 28;
            btnAgencyDelete.Text = "Delete";
            btnAgencyDelete.UseVisualStyleBackColor = true;
            // 
            // txtFName
            // 
            txtFName.Location = new Point(155, 29);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(125, 27);
            txtFName.TabIndex = 29;
            // 
            // txtMiddle
            // 
            txtMiddle.Location = new Point(155, 63);
            txtMiddle.Name = "txtMiddle";
            txtMiddle.Size = new Size(125, 27);
            txtMiddle.TabIndex = 30;
            // 
            // txtLName
            // 
            txtLName.Location = new Point(155, 97);
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(125, 27);
            txtLName.TabIndex = 31;
            // 
            // txtAgentPhone
            // 
            txtAgentPhone.Location = new Point(155, 135);
            txtAgentPhone.Name = "txtAgentPhone";
            txtAgentPhone.Size = new Size(125, 27);
            txtAgentPhone.TabIndex = 32;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(155, 178);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 33;
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(155, 211);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(125, 27);
            txtPosition.TabIndex = 34;
            // 
            // cboAgentLocation
            // 
            cboAgentLocation.FormattingEnabled = true;
            cboAgentLocation.Location = new Point(155, 249);
            cboAgentLocation.Name = "cboAgentLocation";
            cboAgentLocation.Size = new Size(151, 28);
            cboAgentLocation.TabIndex = 35;
            // 
            // cboCity
            // 
            cboCity.FormattingEnabled = true;
            cboCity.Location = new Point(151, 65);
            cboCity.Name = "cboCity";
            cboCity.Size = new Size(151, 28);
            cboCity.TabIndex = 42;
            // 
            // txtFax
            // 
            txtFax.Location = new Point(151, 213);
            txtFax.Name = "txtFax";
            txtFax.Size = new Size(125, 27);
            txtFax.TabIndex = 41;
            // 
            // txtAgencyPhone
            // 
            txtAgencyPhone.Location = new Point(151, 180);
            txtAgencyPhone.Name = "txtAgencyPhone";
            txtAgencyPhone.Size = new Size(125, 27);
            txtAgencyPhone.TabIndex = 40;
            // 
            // txtPostal
            // 
            txtPostal.Location = new Point(151, 137);
            txtPostal.Name = "txtPostal";
            txtPostal.Size = new Size(125, 27);
            txtPostal.TabIndex = 39;
            // 
            // txtProvince
            // 
            txtProvince.Location = new Point(151, 99);
            txtProvince.Name = "txtProvince";
            txtProvince.ReadOnly = true;
            txtProvince.Size = new Size(125, 27);
            txtProvince.TabIndex = 38;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(151, 31);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(125, 27);
            txtAddress.TabIndex = 36;
            // 
            // btnGetAgent
            // 
            btnGetAgent.Location = new Point(248, 79);
            btnGetAgent.Name = "btnGetAgent";
            btnGetAgent.Size = new Size(151, 29);
            btnGetAgent.TabIndex = 43;
            btnGetAgent.Text = "Get Agent";
            btnGetAgent.UseVisualStyleBackColor = true;
            btnGetAgent.Click += btnGetAgent_Click;
            // 
            // btnGetAgency
            // 
            btnGetAgency.Location = new Point(768, 79);
            btnGetAgency.Name = "btnGetAgency";
            btnGetAgency.Size = new Size(151, 29);
            btnGetAgency.TabIndex = 44;
            btnGetAgency.Text = "Get Agency";
            btnGetAgency.UseVisualStyleBackColor = true;
            // 
            // picAgents
            // 
            picAgents.Location = new Point(16, 68);
            picAgents.Name = "picAgents";
            picAgents.Size = new Size(500, 500);
            picAgents.SizeMode = PictureBoxSizeMode.Zoom;
            picAgents.TabIndex = 45;
            picAgents.TabStop = false;
            // 
            // picAgencies
            // 
            picAgencies.Location = new Point(559, 68);
            picAgencies.Name = "picAgencies";
            picAgencies.Size = new Size(500, 500);
            picAgencies.SizeMode = PictureBoxSizeMode.Zoom;
            picAgencies.TabIndex = 46;
            picAgencies.TabStop = false;
            // 
            // gbAgent
            // 
            gbAgent.Controls.Add(btnAgentAddSave);
            gbAgent.Controls.Add(txtFName);
            gbAgent.Controls.Add(label3);
            gbAgent.Controls.Add(label5);
            gbAgent.Controls.Add(label4);
            gbAgent.Controls.Add(label6);
            gbAgent.Controls.Add(label7);
            gbAgent.Controls.Add(label8);
            gbAgent.Controls.Add(label9);
            gbAgent.Controls.Add(btnAgentEdit);
            gbAgent.Controls.Add(cboAgentLocation);
            gbAgent.Controls.Add(btnAgentDelete);
            gbAgent.Controls.Add(txtPosition);
            gbAgent.Controls.Add(txtMiddle);
            gbAgent.Controls.Add(txtEmail);
            gbAgent.Controls.Add(txtLName);
            gbAgent.Controls.Add(txtAgentPhone);
            gbAgent.Location = new Point(68, 213);
            gbAgent.Name = "gbAgent";
            gbAgent.Size = new Size(390, 348);
            gbAgent.TabIndex = 47;
            gbAgent.TabStop = false;
            gbAgent.Text = "Agent Details:";
            gbAgent.Visible = false;
            // 
            // btnAgentAddSave
            // 
            btnAgentAddSave.Enabled = false;
            btnAgentAddSave.Location = new Point(245, 301);
            btnAgentAddSave.Name = "btnAgentAddSave";
            btnAgentAddSave.Size = new Size(100, 29);
            btnAgentAddSave.TabIndex = 36;
            btnAgentAddSave.Text = "Add";
            btnAgentAddSave.UseVisualStyleBackColor = true;
            // 
            // gbManageAgent
            // 
            gbManageAgent.Controls.Add(btnGetAgent);
            gbManageAgent.Controls.Add(label1OR);
            gbManageAgent.Controls.Add(btnAgentAdd);
            gbManageAgent.Controls.Add(txtAgentID);
            gbManageAgent.Controls.Add(label1);
            gbManageAgent.Location = new Point(68, 71);
            gbManageAgent.Name = "gbManageAgent";
            gbManageAgent.Size = new Size(390, 118);
            gbManageAgent.TabIndex = 48;
            gbManageAgent.TabStop = false;
            gbManageAgent.Text = "Manage Agent:";
            gbManageAgent.Visible = false;
            // 
            // gbManageAgency
            // 
            gbManageAgency.Controls.Add(btnGetAgency);
            gbManageAgency.Controls.Add(label2OR);
            gbManageAgency.Controls.Add(cboAgencyLocation);
            gbManageAgency.Controls.Add(btnAddLoc);
            gbManageAgency.Controls.Add(label2);
            gbManageAgency.Location = new Point(592, 71);
            gbManageAgency.Name = "gbManageAgency";
            gbManageAgency.Size = new Size(437, 119);
            gbManageAgency.TabIndex = 49;
            gbManageAgency.TabStop = false;
            gbManageAgency.Text = "Manage Agency:";
            gbManageAgency.Visible = false;
            // 
            // gbAgency
            // 
            gbAgency.BackColor = SystemColors.Control;
            gbAgency.Controls.Add(btnAddLocSave);
            gbAgency.Controls.Add(cboCity);
            gbAgency.Controls.Add(txtFax);
            gbAgency.Controls.Add(txtAgencyPhone);
            gbAgency.Controls.Add(txtPostal);
            gbAgency.Controls.Add(txtProvince);
            gbAgency.Controls.Add(txtAddress);
            gbAgency.Controls.Add(btnAgencyDelete);
            gbAgency.Controls.Add(btnAgencyEdit);
            gbAgency.Controls.Add(label15);
            gbAgency.Controls.Add(label14);
            gbAgency.Controls.Add(label13);
            gbAgency.Controls.Add(label11);
            gbAgency.Controls.Add(label12);
            gbAgency.Controls.Add(label10);
            gbAgency.Location = new Point(592, 213);
            gbAgency.Name = "gbAgency";
            gbAgency.Size = new Size(437, 348);
            gbAgency.TabIndex = 50;
            gbAgency.TabStop = false;
            gbAgency.Text = "Location Details:";
            gbAgency.Visible = false;
            // 
            // btnAddLocSave
            // 
            btnAddLocSave.Enabled = false;
            btnAddLocSave.Location = new Point(251, 301);
            btnAddLocSave.Name = "btnAddLocSave";
            btnAddLocSave.Size = new Size(100, 29);
            btnAddLocSave.TabIndex = 37;
            btnAddLocSave.Text = "Add";
            btnAddLocSave.UseVisualStyleBackColor = true;
            // 
            // frmAgents
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 518);
            Controls.Add(btnGetAgency);
            Controls.Add(btnGetAgent);
            Controls.Add(cboCity);
            Controls.Add(txtFax);
            Controls.Add(txtAgencyPhone);
            Controls.Add(txtPostal);
            Controls.Add(txtProvince);
            Controls.Add(txtAddress);
            Controls.Add(cboAgentLocation);
            Controls.Add(txtPosition);
            Controls.Add(txtEmail);
            Controls.Add(txtAgentPhone);
            Controls.Add(txtLName);
            Controls.Add(txtMiddle);
            Controls.Add(txtFName);
            Controls.Add(btnAgencyDelete);
            Controls.Add(btnAgencyEdit);
            Controls.Add(label2OR);
            Controls.Add(label1OR);
            Controls.Add(btnAgentAdd);
            Controls.Add(btnAgentDelete);
            Controls.Add(btnAgentEdit);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(cboAgencyLocation);
            Controls.Add(txtAgentID);
            Controls.Add(btnAddLoc);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnManageAgencies);
            Controls.Add(btnManageAgents);
            Controls.Add(picAgents);
            Controls.Add(picAgencies);
            Name = "frmAgents";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Agencies and Agents";
            Load += frmAgents_Load;
            ((System.ComponentModel.ISupportInitialize)picAgents).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAgencies).EndInit();
            gbAgent.ResumeLayout(false);
            gbAgent.PerformLayout();
            gbManageAgent.ResumeLayout(false);
            gbManageAgent.PerformLayout();
            gbManageAgency.ResumeLayout(false);
            gbManageAgency.PerformLayout();
            gbAgency.ResumeLayout(false);
            gbAgency.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnManageAgents;
        private Button btnManageAgencies;
        private Label label1;
        private Label label2;
        private Button btnAddLoc;
        private TextBox txtAgentID;
        private ComboBox cboAgencyLocation;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label12;
        private Label label11;
        private Label label13;
        private Label label14;
        private Label label15;
        private Button btnAgentEdit;
        private Button btnAgentDelete;
        private Button btnAgentAdd;
        private Label label1OR;
        private Label label2OR;
        private Button btnAgencyEdit;
        private Button btnAgencyDelete;
        private TextBox txtFName;
        private TextBox txtMiddle;
        private TextBox txtLName;
        private TextBox txtAgentPhone;
        private TextBox txtEmail;
        private TextBox txtPosition;
        private ComboBox cboAgentLocation;
        private ComboBox cboCity;
        private TextBox txtFax;
        private TextBox txtAgencyPhone;
        private TextBox txtPostal;
        private TextBox txtProvince;
        private TextBox txtAddress;
        private Button btnGetAgent;
        private Button btnGetAgency;
        private PictureBox picAgents;
        private PictureBox picAgencies;
        private GroupBox gbAgent;
        private GroupBox gbManageAgent;
        private GroupBox gbManageAgency;
        private GroupBox gbAgency;
        private Button btnAgentAddSave;
        private Button btnAddLocSave;
    }
}