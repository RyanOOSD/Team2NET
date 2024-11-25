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
            btnSignIn = new Button();
            picLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // btnManagePackages
            // 
            btnManagePackages.Location = new Point(114, 410);
            btnManagePackages.Margin = new Padding(3, 4, 3, 4);
            btnManagePackages.Name = "btnManagePackages";
            btnManagePackages.Size = new Size(146, 31);
            btnManagePackages.TabIndex = 0;
            btnManagePackages.Text = "Manage Packages";
            btnManagePackages.UseVisualStyleBackColor = true;
            // 
            // btnManageAgents
            // 
            btnManageAgents.Location = new Point(114, 449);
            btnManageAgents.Margin = new Padding(3, 4, 3, 4);
            btnManageAgents.Name = "btnManageAgents";
            btnManageAgents.Size = new Size(146, 31);
            btnManageAgents.TabIndex = 1;
            btnManageAgents.Text = "Manage Agents";
            btnManageAgents.UseVisualStyleBackColor = true;
            btnManageAgents.Click += btnManageAgents_Click;
            // 
            // btnManageProducts
            // 
            btnManageProducts.Location = new Point(114, 487);
            btnManageProducts.Margin = new Padding(3, 4, 3, 4);
            btnManageProducts.Name = "btnManageProducts";
            btnManageProducts.Size = new Size(146, 31);
            btnManageProducts.TabIndex = 2;
            btnManageProducts.Text = "Manage Products";
            btnManageProducts.UseVisualStyleBackColor = true;
            // 
            // lblAgentID
            // 
            lblAgentID.AutoSize = true;
            lblAgentID.Location = new Point(75, 231);
            lblAgentID.Name = "lblAgentID";
            lblAgentID.Size = new Size(71, 20);
            lblAgentID.TabIndex = 3;
            lblAgentID.Text = "Agent ID:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(146, 221);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(114, 27);
            textBox1.TabIndex = 4;
            // 
            // lblPIN
            // 
            lblPIN.AutoSize = true;
            lblPIN.Location = new Point(106, 301);
            lblPIN.Name = "lblPIN";
            lblPIN.Size = new Size(35, 20);
            lblPIN.TabIndex = 5;
            lblPIN.Text = "PIN:";
            // 
            // txtPIN
            // 
            txtPIN.Location = new Point(146, 290);
            txtPIN.Margin = new Padding(3, 4, 3, 4);
            txtPIN.Name = "txtPIN";
            txtPIN.Size = new Size(114, 27);
            txtPIN.TabIndex = 6;
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(159, 329);
            btnSignIn.Margin = new Padding(3, 4, 3, 4);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(86, 31);
            btnSignIn.TabIndex = 7;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = true;
            // 
            // picLogo
            // 
            picLogo.Location = new Point(85, 20);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(210, 176);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 8;
            picLogo.TabStop = false;
            // 
            // frmOptionPicker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(371, 539);
            Controls.Add(picLogo);
            Controls.Add(btnSignIn);
            Controls.Add(txtPIN);
            Controls.Add(lblPIN);
            Controls.Add(textBox1);
            Controls.Add(lblAgentID);
            Controls.Add(btnManageProducts);
            Controls.Add(btnManageAgents);
            Controls.Add(btnManagePackages);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmOptionPicker";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Travel Experts";
            Load += frmOptionPicker_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
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
        private Button btnSignIn;
        private PictureBox picLogo;
    }
}
