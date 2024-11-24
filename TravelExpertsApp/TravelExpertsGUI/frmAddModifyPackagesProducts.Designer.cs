namespace TravelExpertsGUI
{
    partial class frmAddModifyPackagesProducts
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
            lblSelectedPkg = new Label();
            cmbSelectedProduct = new ComboBox();
            lblSelectedProduct = new Label();
            btnSubmit = new Button();
            btnCancel = new Button();
            cmbSelectedPackage = new ComboBox();
            SuspendLayout();
            // 
            // lblSelectedPkg
            // 
            lblSelectedPkg.AutoSize = true;
            lblSelectedPkg.Location = new Point(12, 30);
            lblSelectedPkg.Name = "lblSelectedPkg";
            lblSelectedPkg.Size = new Size(54, 15);
            lblSelectedPkg.TabIndex = 0;
            lblSelectedPkg.Text = "Package:";
            // 
            // cmbSelectedProduct
            // 
            cmbSelectedProduct.FormattingEnabled = true;
            cmbSelectedProduct.Location = new Point(72, 71);
            cmbSelectedProduct.Name = "cmbSelectedProduct";
            cmbSelectedProduct.Size = new Size(155, 23);
            cmbSelectedProduct.TabIndex = 2;
            // 
            // lblSelectedProduct
            // 
            lblSelectedProduct.AutoSize = true;
            lblSelectedProduct.Location = new Point(14, 79);
            lblSelectedProduct.Name = "lblSelectedProduct";
            lblSelectedProduct.Size = new Size(52, 15);
            lblSelectedProduct.TabIndex = 3;
            lblSelectedProduct.Text = "Product:";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(71, 125);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(152, 125);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbSelectedPackage
            // 
            cmbSelectedPackage.FormattingEnabled = true;
            cmbSelectedPackage.Location = new Point(72, 22);
            cmbSelectedPackage.Name = "cmbSelectedPackage";
            cmbSelectedPackage.Size = new Size(155, 23);
            cmbSelectedPackage.TabIndex = 6;
            // 
            // frmAddModifyPackagesProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(239, 160);
            Controls.Add(cmbSelectedPackage);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(lblSelectedProduct);
            Controls.Add(cmbSelectedProduct);
            Controls.Add(lblSelectedPkg);
            Name = "frmAddModifyPackagesProducts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddModifyPackagesProducts";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSelectedPkg;
        private TextBox txtSelectedPkg;
        private ComboBox cmbSelectedProduct;
        private Label lblSelectedProduct;
        private Button btnSubmit;
        private Button btnCancel;
        private ComboBox cmbSelectedPackage;
    }
}