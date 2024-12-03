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
            cmbProducts = new ComboBox();
            lblSelectedProduct = new Label();
            btnSubmit = new Button();
            btnCancel = new Button();
            cmbPackages = new ComboBox();
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
            // cmbProducts
            // 
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(70, 71);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(277, 23);
            cmbProducts.TabIndex = 2;
            cmbProducts.Format += cmbProducts_Format;
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
            btnSubmit.Location = new Point(70, 125);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(272, 125);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cmbPackages
            // 
            cmbPackages.FormattingEnabled = true;
            cmbPackages.Location = new Point(72, 22);
            cmbPackages.Name = "cmbPackages";
            cmbPackages.Size = new Size(155, 23);
            cmbPackages.TabIndex = 6;
            // 
            // frmAddModifyPackagesProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(359, 160);
            Controls.Add(cmbPackages);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(lblSelectedProduct);
            Controls.Add(cmbProducts);
            Controls.Add(lblSelectedPkg);
            Name = "frmAddModifyPackagesProducts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddModifyPackagesProducts";
            Load += frmAddModifyPackagesProducts_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSelectedPkg;
        private ComboBox cmbProducts;
        private Label lblSelectedProduct;
        private Button btnSubmit;
        private Button btnCancel;
        private ComboBox cmbPackages;
    }
}