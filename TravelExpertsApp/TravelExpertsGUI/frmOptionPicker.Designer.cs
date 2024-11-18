namespace TravelExpertsGUI
{
    partial class frmOptionPicker
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnManagePackages = new Button();
            btnManageAgents = new Button();
            btnManageProducts = new Button();
            lblAgentID = new Label();
            textBox1 = new TextBox();
            lblPIN = new Label();
            txtPIN = new TextBox();
            SuspendLayout();
            // 
            // btnManagePackages
            // 
            btnManagePackages.Location = new Point(78, 174);
            btnManagePackages.Name = "btnManagePackages";
            btnManagePackages.Size = new Size(128, 23);
            btnManagePackages.TabIndex = 0;
            btnManagePackages.Text = "Manage Packages";
            btnManagePackages.UseVisualStyleBackColor = true;
            // 
            // btnManageAgents
            // 
            btnManageAgents.Location = new Point(78, 203);
            btnManageAgents.Name = "btnManageAgents";
            btnManageAgents.Size = new Size(128, 23);
            btnManageAgents.TabIndex = 1;
            btnManageAgents.Text = "Manage Agents";
            btnManageAgents.UseVisualStyleBackColor = true;
            // 
            // btnManageProducts
            // 
            btnManageProducts.Location = new Point(78, 232);
            btnManageProducts.Name = "btnManageProducts";
            btnManageProducts.Size = new Size(128, 23);
            btnManageProducts.TabIndex = 2;
            btnManageProducts.Text = "Manage Products";
            btnManageProducts.UseVisualStyleBackColor = true;
            // 
            // lblAgentID
            // 
            lblAgentID.AutoSize = true;
            lblAgentID.Location = new Point(44, 65);
            lblAgentID.Name = "lblAgentID";
            lblAgentID.Size = new Size(56, 15);
            lblAgentID.TabIndex = 3;
            lblAgentID.Text = "Agent ID:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(106, 57);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 4;
            // 
            // lblPIN
            // 
            lblPIN.AutoSize = true;
            lblPIN.Location = new Point(71, 123);
            lblPIN.Name = "lblPIN";
            lblPIN.Size = new Size(29, 15);
            lblPIN.TabIndex = 5;
            lblPIN.Text = "PIN:";
            // 
            // txtPIN
            // 
            txtPIN.Location = new Point(106, 115);
            txtPIN.Name = "txtPIN";
            txtPIN.Size = new Size(100, 23);
            txtPIN.TabIndex = 6;
            // 
            // frmOptionPicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(285, 272);
            Controls.Add(txtPIN);
            Controls.Add(lblPIN);
            Controls.Add(textBox1);
            Controls.Add(lblAgentID);
            Controls.Add(btnManageProducts);
            Controls.Add(btnManageAgents);
            Controls.Add(btnManagePackages);
            Name = "frmOptionPicker";
            Text = "Travel Experts";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnManagePackages;
        private Button btnManageAgents;
        private Button btnManageProducts;
        private Label lblAgentID;
        private TextBox textBox1;
        private Label lblPIN;
        private TextBox txtPIN;
    }
}
