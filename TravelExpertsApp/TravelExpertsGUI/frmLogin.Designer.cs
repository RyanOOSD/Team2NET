namespace TravelExpertsGUI
{
    partial class frmLogin
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
            panel1 = new Panel();
            label1 = new Label();
            picBoxLogo = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            txtBoxUsername = new TextBox();
            txtBoxPassword = new TextBox();
            btnLogin = new Button();
            picBoxPassword = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxPassword).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(picBoxLogo);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(574, 73);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Bright", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(172, 22);
            label1.Name = "label1";
            label1.Size = new Size(204, 31);
            label1.TabIndex = 1;
            label1.Text = "Travel Xperts";
            // 
            // picBoxLogo
            // 
            picBoxLogo.Image = Properties.Resources.logo;
            picBoxLogo.Location = new Point(92, 5);
            picBoxLogo.Name = "picBoxLogo";
            picBoxLogo.Size = new Size(65, 65);
            picBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picBoxLogo.TabIndex = 0;
            picBoxLogo.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(85, 141);
            label2.Name = "label2";
            label2.Size = new Size(149, 23);
            label2.TabIndex = 1;
            label2.Text = "Agent ID / Email : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(138, 199);
            label3.Name = "label3";
            label3.Size = new Size(96, 23);
            label3.TabIndex = 2;
            label3.Text = "Password : ";
            // 
            // txtBoxUsername
            // 
            txtBoxUsername.Location = new Point(240, 140);
            txtBoxUsername.Name = "txtBoxUsername";
            txtBoxUsername.PlaceholderText = "Enter Email or Agent ID";
            txtBoxUsername.Size = new Size(186, 27);
            txtBoxUsername.TabIndex = 3;
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.Location = new Point(240, 198);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PlaceholderText = "Enter Password";
            txtBoxPassword.Size = new Size(186, 27);
            txtBoxPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(128, 128, 255);
            btnLogin.Location = new Point(240, 278);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(119, 29);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // picBoxPassword
            // 
            picBoxPassword.BackColor = Color.White;
            picBoxPassword.Location = new Point(391, 199);
            picBoxPassword.Name = "picBoxPassword";
            picBoxPassword.Size = new Size(35, 23);
            picBoxPassword.SizeMode = PictureBoxSizeMode.Zoom;
            picBoxPassword.TabIndex = 2;
            picBoxPassword.TabStop = false;
            picBoxPassword.Click += picBoxPassword_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 416);
            Controls.Add(picBoxPassword);
            Controls.Add(btnLogin);
            Controls.Add(txtBoxPassword);
            Controls.Add(txtBoxUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "frmLogin";
            Text = "frmLogin";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxPassword).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox picBoxLogo;
        private Label label2;
        private Label label3;
        private TextBox txtBoxUsername;
        private TextBox txtBoxPassword;
        private Button btnLogin;
        private PictureBox picBoxPassword;
    }
}